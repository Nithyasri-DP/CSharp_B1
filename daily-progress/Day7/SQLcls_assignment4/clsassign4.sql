use assignment;

Select * from Emp;
Select * from Dept;

--assign4 queries
--1)unique depts of Emp table
	Select Deptno from Emp GROUP BY Deptno;
		   	  
--2)name nd salary of who earns 1500+ 
	Select Ename, Salary from Emp
	where Salary > 1500 AND Deptno IN (10, 30);

--3)ppl whose salary is not equal to 1000, 3000, or 5000
	Select Ename, Job, Salary from Emp WHERE Job IN ('Manager', 'Analyst')
	AND Salary NOT IN (1000, 3000, 5000);

--4)ppl whose comm is higher than their salary incr by 10%
	Select Ename, Job, Comm from Emp 
	WHERE Salary*1.1 < Comm;

/*5)Display the name of all employees who have two Ls in their name and are in  
department 30 or their manager is 7782. */
	Select Ename from Emp 
	WHERE (Ename LIKE '%L%L%' AND Deptno = 30) OR Mgr_ID = 7782;

/*6)Display the names of employees with experience of over 30 years and under 
40 yrs. */
	Select Ename, DATEDIFF(YEAR, HIREDATE, GETDATE())From Emp
	WHERE DATEDIFF(YEAR, Hiredate, GETDATE()) BETWEEN 31 AND 39;
	
/*7)Retrieve the names of departments in ascending order and their employees in  
descending order.*/
	SELECT D.Deptname, E.Ename, E.Salary FROM Dept D
	LEFT JOIN Emp E ON D.Deptno = E.Deptno
	ORDER BY D.Deptname ASC, E.Ename DESC;

--8)Experience of Miller
	Select Ename, DATEDIFF(YEAR, Hiredate, GETDATE()) 
	from Emp WHERE Ename = 'Miller';

/*9)Display all employee information where ename contains 5 or 
more characters*/
	Select * from Emp
	WHERE LEN(Ename) >= 5;

/*10)Copy empno, ename of all employees from emp table who work for dept 10 
into a new table called emp10 */
	create table emp10
	(
	Empname varchar(10),
	Empno int PRIMARY KEY
	);

--inserting values from dept number 10
	INSERT INTO emp10 (Empno, Empname) SELECT Empno, Ename
	FROM Emp WHERE Deptno = 10;

--displaying values
	select * from emp10;