# Write your MySQL query statement below
SELECT
	id,
	IFNULL(IF(MOD(id, 2) = 1, LEAD(student) OVER (), LAG(student) OVER ()), student) as student
FROM seat