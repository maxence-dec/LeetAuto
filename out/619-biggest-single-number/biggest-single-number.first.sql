# Write your MySQL query statement below
select max(num) as num
from (
    select a.num
    from MyNumbers a
    cross join MyNumbers b
    where a.num = b.num
    group by a.num
    having count(b.num) = 1
) as temp
;