# Write your MySQL query statement below

with first_consec_log_in as (
    select a.player_id, min(a.event_date) as event_date
    from Activity a
    inner join Activity b
        on a.player_id = b.player_id
        and date_add(a.event_date, INTERVAL 1 day) = b.event_date
    group by a.player_id
),
day_sign_up as (
    select player_id, min(event_date) as event_date
    from Activity
    group by player_id
)

select round(count(a.player_id) / (select count(distinct player_id) from Activity), 2) as fraction
from first_consec_log_in a
    inner join day_sign_up b
        on a.player_id = b.player_id
        and a.event_date = b.event_date
;