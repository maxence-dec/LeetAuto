with
cte as(
        select t.request_at, count(t.status) as totalTrip, sum(t.status<>'completed') as canceledTrip
    from
        Trips as t
        inner join Users as u on t.client_id = u.users_id or t.driver_id = u.users_id
    where
        u.role <> 'partner'
        and u.banned = 'No'
        and exists (select 1 from Users as uSub where uSub.users_id = t.client_id and uSub.banned = 'No')
        and exists (select 1 from Users as uSub where uSub.users_id = t.driver_id and uSub.banned = 'No')
        and t.request_at between '2013-10-01'and '2013-10-03'
    group by t.request_at
)
select
    cte.request_at as 'Day', ROUND( cte.canceledTrip*1.00 / cte.totalTrip, 2) as  'Cancellation Rate'
from
    cte