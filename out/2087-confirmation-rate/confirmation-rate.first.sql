# Write your MySQL query statement below
select a.user_id
    , round(count(CASE WHEN b.action = 'confirmed' THEN 1 ELSE NULL END) / count(*), 2) as confirmation_rate
from Signups a
left outer join Confirmations b on a.user_id = b.user_id
where 1=1
group by a.user_id
;