# Write your MySQL query statement below
select class
from Courses
where 1=1
group by class
having count(student)>=5
;