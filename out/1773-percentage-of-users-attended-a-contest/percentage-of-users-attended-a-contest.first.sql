# Write your MySQL query statement below

select a.contest_id
    , round(count(dIstinct a.user_id)/count(dIstinct b.user_id)*100, 2) as percentage
from Users b, Register a
group by a.contest_id
order by percentage desc, a.contest_id asc