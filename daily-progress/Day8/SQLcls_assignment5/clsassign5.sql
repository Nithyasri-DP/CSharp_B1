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

--assign5 queries
--1)finding emp who receive a higher salary than ID 7566 
	SELECT ename from Emp WHERE Salary > (Select Salary from Emp WHERE Empno = 7566);

--2)Employee with same designation as ID 7876, produce name, deptno & job
	SELECT Ename, Deptno, Job FROM Emp 
	WHERE JOB = (SELECT Job FROM Emp WHERE Empno = 7876);

--3)Emp report to manager, whose names start with B&C, produce first_name, empid, salary
--using self join to get manager name for clarity
	SELECT m.ename AS mgr_name, e.ename, e.empno, e.salary 
   	FROM Emp e JOIN Emp m ON e.mgr_id = m.empno 
	WHERE m.job = 'MANAGER' AND m.ename LIKE '[BC]%';


