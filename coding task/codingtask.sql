--CODING TASK
--Q1 TO 4
create database CareerHub;

use CareerHub;

--1) Companies Table
CREATE TABLE Companies 
(
    CompanyID INT PRIMARY KEY,
    CompanyName VARCHAR(50) NOT NULL,
    CompanyLocation VARCHAR(50)
);

--2) Jobs Table
CREATE TABLE Jobs 
(
    JobID INT PRIMARY KEY,
    CompanyID INT,
    JobTitle VARCHAR(50) NOT NULL,
    JobDescription TEXT,
    JobLocation VARCHAR(50),
    Salary DECIMAL(10,2),
    JobType VARCHAR(50),
    PostedDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CompanyID) REFERENCES Companies(CompanyID)
);

--3) Applicants Table
CREATE TABLE Applicants 
(
    ApplicantID INT PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100),
    Email VARCHAR(255) UNIQUE NOT NULL,
    Phone VARCHAR(15) UNIQUE,
    ApplicantResume TEXT
);

--4) Applications Table
CREATE TABLE Applications 
(
    ApplicationID INT PRIMARY KEY,
    JobID INT,
    ApplicantID INT,
    ApplicationDate DATETIME DEFAULT GETDATE(),
    CoverLetter TEXT,
    FOREIGN KEY (JobID) REFERENCES Jobs(JobID),
    FOREIGN KEY (ApplicantID) REFERENCES Applicants(ApplicantID)
);

-- Sample Data Insertion
--1) Companies Table
INSERT INTO Companies (CompanyID, CompanyName, CompanyLocation) 
	VALUES
	(1, 'Hexaware', 'Chennai'),
	(2, 'Accenture', 'Bangalore'),
	(3, 'TCS', 'Mumbai'),
	(4, 'Zoho', 'Chennai'),
	(5, 'CTS', 'Hyderabad');

--2) Jobs Table
INSERT INTO Jobs (JobID, CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) 
	VALUES
	(11, 1, 'Software Engineer', 'Develop applications', 'Chennai', 70000, 'Full-time', '2024-12-12'),
	(12, 1, 'Data Analyst', 'Analyze company data', 'Bangalore', 50000, 'Part-time', '2024-11-09'),
	(13, 2, 'Project Manager', 'Manage software', 'Mumbai', 90000, 'Contract', '2025-01-01'),
	(14, 3, 'DevOps Engineer', 'Ensure automation', 'Chennai', 85000, 'Full-time', '2024-10-10'),
	(15, 5, 'HR Manager', 'Handle recruitment', 'Mumbai', 65000, 'Full-time', '2024-09-14');

--3) Applicants Table
INSERT INTO Applicants (ApplicantID, FirstName, LastName, Email, Phone, ApplicantResume) 
	VALUES
	(101, 'Nithya', 'Sri', 'nithya.sri@example.com', '543210', 'Software developer skilled in Java and SQL'),
	(102, 'Lekha', 'Priya', 'lekha.priya@example.com', '876549', 'Data analyst in Python '),
	(103, 'Riya', 'Gowtham', 'riya.gowtham@example.com', '761098', 'DevOps engineer experienced in cloud'),
	(104, 'Anjana', 'Shetty', 'anjana.shetty@example.com', '543217', 'Project manager with experience'),
	(105, 'Pooja', 'Agarwal', 'pooja.agarwal@example.com', '543976', 'Employee recruiter');

--4) Applications Table
INSERT INTO Applications (ApplicationID, JobID, ApplicantID, ApplicationDate, CoverLetter)
	VALUES
	(21, 11, 101, '2024-12-13', 'I am interested in this role'),
	(22, 12, 102, '2024-11-10', 'Excited to apply'),
	(23, 13, 103, '2025-01-03', 'Applying for this position'),
	(24, 14, 102, '2024-10-11', 'My experience matches this role'),
	(25, 15, 104, '2024-09-15', 'Great opportunity');

---Displaying data
	SELECT * FROM Companies;
	SELECT * FROM Jobs;
	SELECT * FROM Applicants;
	SELECT * FROM Applications;

/* Q5: Write an SQL query to count the number of applications received for each job listing in the 
"Jobs" table. Display the job title and the corresponding application count. Ensure that it lists all 
jobs, even if they have no applications. */

	SELECT j.JobTitle, count(*) AS ApplicationCount	FROM Jobs j
	LEFT JOIN Applications a ON j.JobID = a.JobID
	GROUP BY j.JobTitle
	ORDER BY ApplicationCount;

/* Q6: Develop an SQL query that retrieves job listings from the "Jobs" table within a specified salary 
range. Allow parameters for the minimum and maximum salary values. Display the job title, 
company name, location, and salary for each matching job. */
--minsal = 50000 & maxsal = 90000

	SELECT j.JobTitle, c.CompanyName, j.JobLocation, j.Salary FROM Jobs j
	JOIN Companies c ON j.CompanyID = c.CompanyID
	WHERE j.Salary BETWEEN 50000 AND 90000
	ORDER BY j.Salary DESC;

/* Q7: Write an SQL query that retrieves the job application history for a specific applicant. Allow a 
parameter for the ApplicantID, and return a result set with the job titles, company names, and 
application dates for all the jobs the applicant has applied to. */

	SELECT j.JobTitle, c.CompanyName, a.ApplicationDate
	FROM Applications a
	JOIN Jobs j ON a.JobID = j.JobID
	JOIN Companies c ON j.CompanyID = c.CompanyID
	WHERE a.ApplicantID = 101 
	ORDER BY a.ApplicationDate;

/*Q8: Create an SQL query that calculates and displays the average salary offered by all companies for 
job listings in the "Jobs" table. Ensure that the query filters out jobs with a salary of zero. */

	SELECT AVG(Salary) AS average_salary
	FROM Jobs WHERE Salary > 0;

/*Q9: Write an SQL query to identify the company that has posted the most job listings. Display the 
company name along with the count of job listings they have posted. Handle ties if multiple 
companies have the same maximum count. */

	SELECT c.CompanyName, COUNT(j.JobID) AS job_count FROM Jobs j
	JOIN Companies c ON j.CompanyID = c.CompanyID
	GROUP BY c.CompanyName
	HAVING COUNT(j.JobID) = (SELECT MAX(job_count) 
    FROM (SELECT COUNT(JobID) AS job_count FROM Jobs 
	GROUP BY CompanyID)one);

/*Q10: Find the applicants who have applied for positions in companies located in 'CityX' and have at 
least 3 years of experience. */

--Taking CITYX as Chennai, and provided column dont have exp so altering table as below
	ALTER TABLE Applicants 
	ADD ExperienceYears INT;

--Updating Sample Data
	UPDATE Applicants 
	SET ExperienceYears = 5 
	WHERE ApplicantID = 101;

--Working with giv ques
	SELECT DISTINCT a.FirstName, a.LastName, a.ExperienceYears
	FROM Applications AS app
	JOIN Jobs j ON app.JobID = j.JobID
	JOIN Companies c ON j.CompanyID = c.CompanyID
	JOIN Applicants a ON app.ApplicantID = a.ApplicantID
	WHERE c.CompanyLocation = 'Chennai' AND a.ExperienceYears >= 3;

--Q11: Retrieve a list of distinct job titles with salaries between $60,000 and $80,000.

	SELECT DISTINCT JobTitle FROM Jobs
	WHERE Salary BETWEEN 60000 AND 80000;

--Q12: Find the jobs that have not received any applications. 

--in provided details there is no job has no applications so adding new data
	INSERT INTO Jobs VALUES (16, 4, 'Marketing', 'Sales Executive', 'Delhi', 75000, 'Full-time', '2024-12-20');

--working on query
	SELECT JobTitle FROM Jobs
	WHERE JobID NOT IN (SELECT JobID FROM Applications);

/*Q13: Retrieve a list of job applicants along with the companies they have applied to and the positions 
they have applied for. */

	SELECT a.FirstName, a.LastName, c.CompanyName, j.JobTitle AS AppliedPos
	FROM Applications app
	JOIN Applicants a ON app.ApplicantID = a.ApplicantID
	JOIN Jobs j ON app.JobID = j.JobID
	JOIN Companies c ON j.CompanyID = c.CompanyID;

/*Q14: Retrieve a list of companies along with the count of jobs they have posted, even if they have not 
received any applications. */

	SELECT c.CompanyName, COUNT(j.JobID) AS job_count
	FROM Companies c
	LEFT JOIN Jobs j ON c.CompanyID = j.CompanyID
	GROUP BY c.CompanyName
	ORDER BY job_count;

/*Q15: List all applicants along with the companies and positions they have applied for, including those 
who have not applied. */

	SELECT a.FirstName, a.LastName, c.CompanyName, j.JobTitle
	FROM Applicants a
	JOIN Applications app ON a.ApplicantID = app.ApplicantID
	JOIN Jobs j ON app.JobID = j.JobID
	JOIN Companies c ON j.CompanyID = c.CompanyID
	UNION
    SELECT a.FirstName, a.LastName, 'No Application' AS CompanyName, 'No Application' AS JobTitle
	FROM Applicants a
	WHERE a.ApplicantID NOT IN (SELECT ApplicantID FROM Applications);


/*Q16:  Find companies that have posted jobs with a salary higher than the average salary of all jobs.*/

	SELECT c.CompanyName FROM Companies c
	JOIN Jobs j ON c.CompanyID = j.CompanyID
	WHERE j.Salary > (SELECT AVG(Salary) FROM Jobs);

--Q17: Display a list of applicants with their names and a concatenated string of their city and state.

--adding state nd city to table
	ALTER TABLE Applicants
	ADD City VARCHAR(50), 
    State VARCHAR(50);

	--updating applicants
	UPDATE Applicants 
	SET City = 'Chennai', State = 'Tamil Nadu' 
	WHERE ApplicantID = 101

	--working on query
	SELECT FirstName,LastName, CONCAT(City, ', ', State) AS Location FROM Applicants;

/*Q18: Retrieve a list of jobs with titles containing either 'Developer' or 'Engineer'. */

	SELECT JobTitle FROM Jobs
	WHERE JobTitle LIKE '%Developer%' OR JobTitle LIKE '%Engineer%';

/*Q19:Retrieve a list of applicants and the jobs they have applied for, including those who have not 
applied and jobs without applicants. */

	SELECT a.FirstName, a.LastName, ISNULL(j.JobTitle, 'No Job Applied') AS JobTitle
	FROM Applicants a
	FULL JOIN Applications app ON a.ApplicantID = app.ApplicantID
	FULL JOIN Jobs j ON app.JobID = j.JobID;
	
/*Q20:  List all combinations of applicants and companies where the company is in a specific city and the 
applicant has more than 2 years of experience. For example: city=Chennai */

	SELECT a.FirstName, a.LastName, c.CompanyName, c.CompanyLocation, a.ExperienceYears
	FROM Applicants a
	CROSS JOIN Companies c
	WHERE c.CompanyLocation = 'Chennai' 
	AND a.ExperienceYears > 2;