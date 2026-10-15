# Write your MySQL query statement below

select start.machine_id, ROUND(AVG(end.timestamp - start.timestamp), 3) as processing_time
from Activity as start, Activity as end
where start.activity_type = 'start'
    and end.activity_type = 'end'
    and start.process_id = end.process_id
    and start.machine_id = end.machine_id
group by start.machine_id
order by start.machine_id asc
;