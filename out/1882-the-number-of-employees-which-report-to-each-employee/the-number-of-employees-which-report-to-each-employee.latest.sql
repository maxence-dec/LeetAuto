# Write your MySQL query statement below
select reports_to as employee_id
    ,(select name from Employees where employee_id = e.reports_to) as name
    ,count(employee_id) as reports_count
    ,round(avg(age),0) as average_age
from Employees as e
where reports_to is not NULL
group by reports_to
order by employee_id