--displaying Clients table
	select * from Clients;

--displaying Employees table
	select * from Employees;

--displaying Departments table
	select * from Departments;

--displaying Projects table
    select * from Projects;
	   
--displaying EmpProjectsTasks table
	select * from EmpProjectTasks;

	select * from EmpProjectTasks 
    ORDER BY Project_ID, TaskStartdate, TaskEnddate, Empno;