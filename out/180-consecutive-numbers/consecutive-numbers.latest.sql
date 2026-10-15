# Write your MySQL query statement below
select a.num as ConsecutiveNums
from Logs a
    inner join Logs b on a.num = b.num and a.id+1 = b.id
    inner join Logs c on b.num = c.num and b.id+1 = c.id
group by a.num
;