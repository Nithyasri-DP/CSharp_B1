use assignment;

--source table queries
--creating Emp table
	create table Emp(
	Empno int PRIMARY KEY,
    Ename varchar(15) NOT NULL,
    Job varchar(15),
    Mgr_ID int,
    Hiredate date,
    Salary int,
    Comm int,
    Deptno int,
	FOREIGN KEY (Mgr_ID) REFERENCES Emp(Empno)
	);

--creating dept table	   	  
	create table Dept(
	Deptno int PRIMARY KEY,
    Deptname varchar(15),
    Loc varchar(15)
	);

--making deptno as foreign key in Emp table
	alter table Emp
	ADD CONSTRAINT FK_Deptno FOREIGN KEY (Deptno) REFERENCES Dept(Deptno);

--inserting values into dept table first to get the primary key value of deptno which acts as a foreign key in Emp table
	insert into Dept(Deptno, Deptname, Loc) 
	values
	(10, 'ACCOUNTING', 'NEW YORK'),
	(20, 'RESEARCH', 'DALLAS'),
	(30, 'SALES', 'CHICAGO'),
	(40, 'OPERATIONS', 'BOSTON');


--inserting values into Emp table	   	  
	insert into Emp (Empno, Ename, Job, Mgr_ID, Hiredate, Salary, Comm, Deptno) 
	values
	(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
	(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
	(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
	(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
	(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
	(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
	(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
	(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
	(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
	(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
	(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
	(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
	(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
	(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

--displaying Emp table
	select * from Emp;

--displaying Dept table
	select * from Dept;

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