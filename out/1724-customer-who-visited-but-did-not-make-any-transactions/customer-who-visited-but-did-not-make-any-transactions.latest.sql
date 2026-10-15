# Write your MySQL query statement below
select customer_id, count(*) as count_no_trans
from Visits
left join Transactions on Transactions.visit_id = Visits.visit_id
where Transactions.transaction_id is NULL
group by customer_id
;