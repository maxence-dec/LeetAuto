# LeetCode's internal `lang` slug -> (output folder, file extension).
# Anything not listed here is skipped, per your instruction, rather than
# guessed at with an extension that might be wrong.

LANG_MAP = {
    "c":         ("c",      "c"),
    "cpp":       ("c++",    "cpp"),
    "rust":      ("rust",   "rs"),
    "mysql":     ("sql",    "sql"),
    "mssql":     ("sql",    "sql"),
    "oraclesql": ("sql",    "sql"),
    "python":    ("python", "py"),
    "python3":   ("python", "py"),
    "csharp":    ("c#",     "cs"),
    "java":      ("java",   "java"),
}