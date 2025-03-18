use assignment;

select * from Emp;
select * from Dept;

--1)retrive manager list
	Select Ename, job from Emp	Where Job = 'MANAGER';

--2)name nd sal for who earns 1000+
	Select Ename, Salary from Emp Where Salary > 1000;

--3)name nd sal except james
	Select Ename, Salary from Emp Where Ename != 'JAMES'; 
	
--4)names begin with s
	Select Ename from Emp Where Ename Like 'S%';

--5)finding names that has A in it
	Select Ename from Emp Where Ename Like '%A%';
	   
--6)letter L as 3rd char
	Select Ename from Emp Where Ename Like '__L%';

--7)daily salary of jones
	Select Ename, Salary, (Salary/30) 'Daily_salary' from Emp where Ename = 'JONES';

--8)cal tot monthly sal of all emps
	Select SUM(Salary) 'Total salary'from Emp;

--9)avg annual salary
	Select Ename, (Salary*12) 'tot sal', (Select AVG(Salary*12) 'Per annum' from Emp) from Emp; 

--10)name, job, sal, deptno except salesman from no.30
	Select Ename, Job, Salary, Deptno from Emp WHERE Job != 'SALESMAN' AND Deptno=30;