# Write your MySQL query statement below
select a.user_id
    , round(avg(if(b.action = 'confirmed', 1.00, 0)), 2) as confirmation_rate
from Signups a
left outer join Confirmations b on a.user_id = b.user_id
where 1=1
group by a.user_id
;