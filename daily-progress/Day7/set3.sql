use assignment;

Select * from Emp;
Select * from Dept;

--assign4 queries
--1)unique depts of Emp table
	Select Deptno from Emp GROUP BY Deptno;

--2)name nd salary of who earns 1500+ 
