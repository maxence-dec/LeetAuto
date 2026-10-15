# Write your MySQL query statement below
select a.product_id, COALESCE(round(sum(a.price*b.units)/sum(b.units),2), 0) as average_price
from Prices a
    left outer join UnitsSold b on a.product_id = b.product_id
        and b.purchase_date between a.start_date and a.end_date
where 1=1
group by a.product_id#, b.purchase_date, b.units
;