use assignment;

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

--1)listing employees names begin with A
	select * from Emp where Ename LIKE 'A%';
	   	 		 
--2)selecting employees who dont have manager
	select * from Emp where Mgr_ID is NULL;

--3)Employee name, num nd sal earns 1200-1400
	select Ename, Empno, Salary from Emp where Salary BETWEEN 1200 AND 1400;

--4)Rising 10% only to research dept
	select Empno, Ename, Salary, (Salary*1.10) 'Salary after rise' from Emp
	WHERE Deptno = (Select Deptno from Dept WHERE Deptname = 'RESEARCH');

--5)Clerks appointed
	select COUNT(*) 'Count value' from Emp WHERE Job = 'Clerk';

--6)avg salary for each job nd no of ppl appointed
	select Job, AVG(Salary)'Average Salary', COUNT(*) "No of Employees" FROM Emp GROUP BY Job;

--7)highest nd lowest salary
	select MAX(Salary) as Highest, MIN (Salary) as Lowest from Emp;

--8)dept doesnt have emp
	Select Dept. * from Dept 
	LEFT JOIN Emp ON Dept.Deptno = Emp.Deptno
	WHERE Emp.Deptno IS NULL;
	
--9)names nd salaries of those who earns 1200+
	Select Ename, Salary from Emp WHERE Job = 'ANALYST' AND Salary > 1200 AND Deptno = 20 
	ORDER BY Ename ASC;

--10)Each depts name, num with tot salary
	Select Dept.Deptname, Dept.Deptno, SUM(Emp.Salary) FROM Dept 
	INNER JOIN Emp ON Dept.Deptno = Emp.Deptno
	GROUP BY Dept.Deptname, Dept.Deptno;	

--11)salary of miller nd smith
	Select Ename, Salary from Emp WHERE Ename in ('MILLER' , 'SMITH');

--12)names begin with a nd m
	Select Ename from Emp WHERE Ename LIKE 'A%' OR Ename LIKE 'M%';

--13)yearly salary of smith
	Select Ename,Salary, (Salary*12)'Yearly salary' from Emp WHERE Ename = 'SMITH';

--14)name nd sal of ppl whose sal not in range of 1500 and 2850
	Select Ename, Salary from Emp WHERE Salary NOT BETWEEN 1500 AND 2850;

--15)managers who have more than 2Emp reporting them
	Select Mgr_id, COUNT(*) from Emp 
	WHERE Mgr_id IS NOT NULL 
	GROUP BY Mgr_id 
	HAVING COUNT(*) > 2;
	   	  	