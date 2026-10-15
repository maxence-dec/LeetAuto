# Write your MySQL query statement below
select teacher_id, count(distinct subject_id) as cnt
from Teacher
where 1=1
group by teacher_id
;