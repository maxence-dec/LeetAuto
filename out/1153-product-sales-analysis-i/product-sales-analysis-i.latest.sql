# Write your MySQL query statement below
select product_name, Sales.year, price
from Sales
inner join Product on Product.product_id = Sales.product_id
where 1=1
;