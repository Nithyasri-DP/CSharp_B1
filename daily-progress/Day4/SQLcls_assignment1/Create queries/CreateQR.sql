--creating client table
	create table Clients(
	Client_ID int PRIMARY KEY,
	Cname varchar(40) NOT NULL,
	CAddress varchar(30),
	Email varchar(30) UNIQUE,
	Phone numeric(10),
	Business varchar(20) NOT NULL
	);

--creating departments table first to make deptno as foreign key in employees table
	create table Departments(
	Deptno int PRIMARY KEY,
	Dname varchar(15) NOT NULL,
	Loc varchar(20)
	);
	   	  
--creating employees table
	create table Employees(
	Empno int PRIMARY KEY,
	Ename varchar(20) NOT NULL,
	Job varchar(15),
	Salary float(15) CHECK(Salary>0),
	Deptno int FOREIGN KEY REFERENCES Departments(Deptno)
	);

--creating projects table
	create table Projects(
	Project_ID int PRIMARY KEY,
	Descr varchar(30) NOT NULL,
	Startdate DATE,
	Planned_end_date DATE,
	Actual_end_date DATE,
	CHECK(Actual_end_date > Planned_end_date),
	Budget numeric(10) CHECK(Budget>0),
	Client_ID int FOREIGN KEY REFERENCES Clients(Client_ID),
	);

--creating EmpProjectTasks
	create table EmpProjectTasks
	(
	Project_ID int,
	Empno int,
	PRIMARY KEY(Project_ID, Empno),
	CONSTRAINT FK_Project FOREIGN KEY (Project_ID) REFERENCES Projects(Project_ID),
    CONSTRAINT FK_Employee FOREIGN KEY (Empno) REFERENCES Employees(Empno),
	TaskStartdate DATE,
	TaskEnddate DATE,
	Task varchar(25) NOT NULL,
	Status varchar(15) NOT NULL
	);