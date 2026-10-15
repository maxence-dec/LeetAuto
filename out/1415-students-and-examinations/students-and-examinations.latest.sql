# Write your MySQL query statement below

select a.student_id, a.student_name, b.subject_name, count(Examinations.student_id) as attended_exams
from Students a
cross join Subjects b
left outer join Examinations on Examinations.student_id = a.student_id and Examinations.subject_name = b.subject_name
where 1=1
group by a.student_id, b.subject_name
order by a.student_id, b.subject_name
;