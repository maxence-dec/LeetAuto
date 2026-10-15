# Write your MySQL query statement below
select DATE_FORMAT(trans_date,"%Y-%m") as month, country
    ,COUNT(id) AS trans_count
    ,SUM(state = 'approved') AS approved_count
    ,SUM(amount) AS trans_total_amount
    ,SUM((state = 'approved') * amount) AS approved_total_amount
from Transactions
where 1=1
group by 1, 2
;