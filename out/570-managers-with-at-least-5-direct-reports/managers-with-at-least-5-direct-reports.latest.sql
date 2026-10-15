# Write your MySQL query statement below
select a.name
from Employee a
cross join Employee b
where a.id = b.managerId
group by a.id
having count(a.id = b.managerId) >= 5
;