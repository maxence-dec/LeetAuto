#!/usr/bin/env python3

import json
import sys
import time
from pathlib import Path

import requests

import langue_map

SUBMISSIONS_URL = "https://leetcode.com/api/submissions/"
USER_AGENT = (
    "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 "
    "(KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36"
)
REQUEST_DELAY_SECONDS = 8

class SessionError(RuntimeError):
    """Config is malformed, or LeetCode rejected the configured cookies."""

def load_config(path):
    try:
        with open(path) as f:
            cfg = json.load(f)
    except FileNotFoundError:
        raise SessionError(f"config file not found: {path}")
    except json.JSONDecodeError as e:
        raise SessionError(f"config file is not valid JSON: {e}")

    session_cookie = cfg.get("cookies", {}).get("LEETCODE_SESSION", "").strip()
    if not session_cookie:
        raise SessionError("config.cookies.LEETCODE_SESSION is missing or empty")

    if not isinstance(cfg.get("latest_id"), int) or cfg["latest_id"] < 0:
        raise SessionError("config.latest_id must be present and a non-negative integer")

    return cfg


def save_config(path, cfg):
    with open(path, "w") as f:
        json.dump(cfg, f, indent=2)


def fetch_page(cookies, offset, limit):
    resp = requests.get(
        SUBMISSIONS_URL,
        params={"offset": offset, "limit": limit},
        headers={
            "Cookie": (
                f"LEETCODE_SESSION={cookies['LEETCODE_SESSION']}; "
                f"csrftoken={cookies.get('csrftoken', '')}"
            ),
            "User-Agent": USER_AGENT,
        },
        timeout=15,
    )

    if resp.status_code != 200:
        raise SessionError(
            f"LeetCode returned HTTP {resp.status_code} for offset={offset} "
            "— LEETCODE_SESSION is likely invalid or expired"
        )

    try:
        data = resp.json()
    except json.JSONDecodeError:
        raise SessionError(
            "response was not JSON (you likely got an HTML login page back) "
            "— LEETCODE_SESSION is invalid or expired"
        )

    if "submissions_dump" not in data:
        raise SessionError(f"unexpected response shape, no submissions_dump: {data}")

    return data


def write_code(target_path, ext, slug, tag, code):
    target_path.mkdir(parents=True, exist_ok=True)
    path = target_path / f"{slug}.{tag}.{ext}"
    path.write_text(code)
    return path


def process_submission(out_dir, sub):
    lang = sub["lang"]
    if lang not in langue_map.LANG_MAP:
        _, ext = lang, "txt"
    else:
        _, ext = langue_map.LANG_MAP[lang]
    slug = sub["title_slug"]

    target_path = Path(f"{out_dir}/{sub['question_id']}-{slug}")

    latest_path = target_path / f"{slug}.latest.{ext}"
    if not latest_path.exists():
        write_code(target_path, ext, slug, "latest", sub["code"])
    else:
        write_code(target_path, ext, slug, "first", sub["code"])

def process_dump(cookies, offset, limit, latest_id, out_dir):
    keep_processing = True
    data = fetch_page(cookies, offset, limit)
    dump = data["submissions_dump"]
    max_id = dump[0]["id"]
    for sub in dump:
        if latest_id == sub.get("id"):
            keep_processing = False
            break
        if sub.get("status_display") == "Accepted":
            process_submission(out_dir, sub)
    print(f"processed {len(dump)} submissions, offset now {offset}")
    keep_processing = keep_processing and data.get("has_next") and dump
    return max_id, keep_processing

def run(config_path, out_dir):
    cfg = load_config(config_path)
    cookies = cfg["cookies"]
    latest_id = cfg["latest_id"]
    offset = 0
    limit = 10

    (new_latest_id, keep_processing) = process_dump(cookies, offset, limit, latest_id, out_dir)
    cfg["latest_id"] = new_latest_id;
    save_config(config_path, cfg)

    while keep_processing:
        offset += 10
        _, keep_processing = process_dump(cookies, offset, limit, latest_id, out_dir)
        time.sleep(REQUEST_DELAY_SECONDS)

    print("done — no more submissions to fetch")


if __name__ == "__main__":
    config_path = "config.json"
    out_dir = "out"
    try:
        run(config_path, out_dir)
    except SessionError as e:
        print(f"error: {e}", file=sys.stderr)
        sys.exit(1)