# Write your MySQL query statement below

with mix as (
    select student_id, student_name, subject_name
    from Students a, Subjects b
    where 1=1
    group by a.student_id, b.subject_name
    order by a.student_id, b.subject_name
)
select mix.student_id, mix.student_name, mix.subject_name, count(Examinations.student_id) as attended_exams
from mix
left outer join Examinations on Examinations.student_id = mix.student_id and Examinations.subject_name = mix.subject_name
where 1=1
group by mix.student_id, mix.subject_name
order by mix.student_id, mix.subject_name
;