# Write your MySQL query statement below

select a.project_id, round(coalesce(avg(b.experience_years), 0.00),2) as average_years
from Project as a
inner join Employee as b on a.employee_id = b.employee_id
where 1=1
group by a.project_id
;