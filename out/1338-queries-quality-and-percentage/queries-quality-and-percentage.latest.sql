# Write your MySQL query statement below
select q.query_name
    , round(sum(q.rating/q.position)/count(q.position), 2) as quality
    , round(sum(if(q.rating < 3, 1.00, 0))/count(q.rating)*100, 2) as poor_query_percentage
from Queries q
where 1=1
group by q.query_name
;