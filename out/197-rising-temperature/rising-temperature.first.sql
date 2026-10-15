# Write your MySQL query statement below

select a.id
from Weather a
left join Weather b on b.recordDate = DATE_ADD(a.recordDate, INTERVAL -1 DAY)
where a.temperature > b.temperature
;