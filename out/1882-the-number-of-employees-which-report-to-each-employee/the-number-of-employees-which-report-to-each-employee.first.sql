# Write your MySQL query statement below

with managers as (
    select distinct reports_to as manager_id
    from Employees
    where reports_to is not NULL
)

select a.employee_id, a.name
    , (select count(employee_id) from Employees where reports_to = a.employee_id) as reports_count
    , (select round(avg(age),0) from Employees where reports_to = a.employee_id) as average_age
from Employees a
    left outer join managers b on a.employee_id = b.manager_id
where b.manager_id is not null
order by employee_id