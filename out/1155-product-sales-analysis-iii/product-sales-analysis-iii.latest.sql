# Write your MySQL query statement below

with first_year_selling as (
    select product_id, min(year) as first_year
    from Sales
    group by product_id
)

select a.product_id, b.first_year, a.quantity as quantity, price
from Sales as a
inner join first_year_selling as b
    on a.product_id = b.product_id
    and a.year = b.first_year
where 1=1
;