# Write your MySQL query statement below
select a.customer_id
from Customer as a
inner join Product as b on a.product_key = b.product_key
where 1=1
group by a.customer_id
having count(distinct a.product_key) = (select count(*) from Product)
;