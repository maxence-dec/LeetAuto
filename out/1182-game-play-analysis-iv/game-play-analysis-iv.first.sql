# Write your MySQL query statement below

with day_after_sign_up as (
    select a.player_id, min(a.event_date) as event_date
    from Activity a
    left outer join Activity b on date_add(a.event_date, INTERVAL 1 day) = b.event_date
    where a.player_id = b.player_id
    group by a.player_id
),
day_sign_up as (
    select player_id, min(event_date) as event_date
    from Activity
    where player_id = player_id
    group by player_id
)

select round(count(a.player_id) / (select count(distinct player_id) from Activity), 2) as fraction
from day_after_sign_up a
    inner join day_sign_up b 
        on a.player_id = b.player_id
        and a.event_date = b.event_date
;