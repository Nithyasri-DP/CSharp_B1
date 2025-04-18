--DATABASE DESIGN
create database SIS_DB;

use SIS_DB;

--TASK 1
--creating tables with given appropriate data
--1)STUDENTS TABLE

CREATE TABLE Students 
(
    student_id INT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50),
    date_of_birth DATE,
    email VARCHAR(50) UNIQUE,
    phone_number VARCHAR(15) UNIQUE
);

--creating teachers table secondly as the course table consists of foreign key
--2)TEACHER TABLE

CREATE TABLE Teacher 
(
    teacher_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100) UNIQUE
);

--3)COURSE TABLE

CREATE TABLE Courses
(
    course_id INT PRIMARY KEY,
    course_name VARCHAR(50),
    credits INT,
    teacher_id INT,
    FOREIGN KEY (teacher_id) REFERENCES Teacher (teacher_id)
);

--4)ENROLLMENTS TABLE

CREATE TABLE Enrollments 
(
    enrollment_id INT PRIMARY KEY,
    student_id INT,
    course_id INT,
    enrollment_date DATE,
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);

--5)PAYMENTS TABLE

CREATE TABLE Payments 
(
    payment_id INT PRIMARY KEY,
    student_id INT,
    amount DECIMAL(10,2),
    payment_date DATE,
    FOREIGN KEY (student_id) REFERENCES Students(student_id)
);

--inserting 10 elements for each table 
--1)STUDENTS TABLE

INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email, phone_number)
	VALUES 
	(101, 'Anu', 'Vidhya', '2000-05-15', 'anuvidhya@gmail.com', '48291'),
	(102, 'Banu', 'Priya', '2002-07-20', 'banupriya@yahoo.com', '75903'),
	(103, 'Charu', 'Mathi', '2001-03-10', 'charumathi@outlook.com', '63827'),
	(104, 'Diya', 'Kannan', '1998-11-25', 'diyakannan@gmail.com', '19274'),
	(105, 'Nila', 'Sri', '2004-06-30', 'nilasri@yahoo.com', '84629'),
	(106, 'Riya', 'Akash', '2003-01-12', 'riyaakash@outlook.com', '50718'),
	(107, 'Mrunal', 'Siksha', '1997-09-18', 'mrunalnisiksha@gmail.com', '93582'),
	(108, 'Niharika', 'Sumit', '1996-04-23', 'niharikasumit@yahoo.com', '21469'),
	(109, 'Lekha', 'Sri', '1995-12-05', 'lekhasri@outlook.com', '67035'),
	(110, 'Nithya', 'Vasudevan', '2004-02-29', 'nithyavasudevan@gmail.com', '38914');

--2)TEACHERS TABLE

INSERT INTO Teacher (teacher_id, first_name, last_name, email) 
	VALUES
	(51, 'Sathya', 'Kala', 'sathyakala@gmail.com'),
	(52, 'Jaya', 'Chitra', 'jayachitra@outlook.com'),
	(53, 'Aasha', 'Kumari', 'aashakumari@gmail.com'),
	(54, 'Jayanthi', 'Lakshmi', 'jayanthilakshmi@outlook.com'),
	(55, 'Pooja', 'Sri', 'poojasri@gmail.com'),
	(56, 'Bhava', 'Dharani', 'bhavadharani@outlook.com'),
	(57, 'Preethi', 'Karunya', 'preethikarunya@gmail.com'),
	(58, 'Yaazhini', 'Kannan', 'yaazhinnikannan@outlook.com'),
	(59, 'Keerthana', 'Varun', 'keerthanavarun@gmail.com'),
	(60, 'Sri', 'Lekha', 'srilekha@outlook.com');

--3)COURSES TABLE

INSERT INTO Courses (course_id, course_name, credits, teacher_id) 
	VALUES
	(11, 'Data Structures', 4, 51),
	(12, 'DBMS', 4, 52),
	(13, 'OOPS', 4, 53),
	(14, 'Cyber Security', 2, 54),
	(15, 'TOC', 1, 55),
	(16, 'AI', 4, 56),
	(17, 'ML', 4, 57),
	(18, 'Networks', 3, 59),
	(19, 'OS', 3, 58),
	(20, 'Software Engg', 3, 60);

--4)ENROLLMENT TABLE

INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) 
	VALUES
	(1, 101, 13, '2024-07-15'),
	(2, 102, 19, '2025-02-10'),
	(3, 103, 20, '2024-05-22'),
	(4, 104, 15, '2025-08-05'),
	(5, 105, 12, '2024-06-18'),
	(6, 106, 11, '2025-10-12'),
	(7, 107, 14, '2024-03-25'),
	(8, 108, 13, '2025-12-01'),
	(9, 109, 14, '2024-04-07'),
	(10, 110, 17, '2025-11-20');

--5)PAYMENTS TABLE

INSERT INTO Payments (payment_id, student_id, amount, payment_date) 
	VALUES
	(1, 101, 500.00, '2024-07-20'),
	(2, 102, 600.00, '2025-02-15'),
	(3, 103, 550.00, '2024-06-01'),
	(4, 104, 580.00, '2025-08-10'),
	(5, 105, 620.00, '2024-07-01'),
	(6, 106, 530.00, '2025-10-15'),
	(7, 107, 570.00, '2024-04-01'),
	(8, 108, 590.00, '2025-12-10'),
	(9, 109, 610.00, '2024-04-20'),
	(10, 110, 540.00, '2025-11-25');

--viewing all 5 tables

Select * from Students;
Select * from Teacher;
Select * from Courses;
Select * from Enrollments;
Select * from Payments;


--TASK 2
--SELECT, WHERE, BETWEEN, AND, LIKE
--1)inserting a new student in students table

INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email, phone_number) 
VALUES (111, 'John', 'Doe', '1995-08-15', 'john.doe@example.com', '30190');

/*2) Write an SQL query to enroll a student in a course. Choose an existing student and course and 
insert a record into the "Enrollments" table with the enrollment date. */

INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) 
VALUES (11, 101, 13, '2025-03-21');

/*3) Update the email address of a specific teacher in the "Teacher" table. Choose any teacher and 
modify their email address. */

	UPDATE Teacher 
	SET email = 'sathya@yahoo.com' 
	WHERE teacher_id = 51;
	   
/*4) Write an SQL query to delete a specific enrollment record from the "Enrollments" table. Select 
an enrollment record based on the student and course. */

	DELETE FROM Enrollments 
	WHERE student_id = 101 AND course_id = 13;
		
/*5) Update the "Courses" table to assign a specific teacher to a course. Choose any course and 
teacher from the respective tables. */

	UPDATE Courses 
	SET teacher_id = 55  
	WHERE course_id = 12;
	
/*6) Delete a specific student from the "Students" table and remove all their enrollment records 
from the "Enrollments" table. Be sure to maintain referential integrity. */

	DELETE FROM Enrollments 
	WHERE student_id = (SELECT student_id FROM Students WHERE student_id = 109);

	--Payments has a fkey in students,deleting student's payment is necessary here

	DELETE FROM Payments 
	WHERE student_id = 109;

--deleting a student record in student table

	DELETE FROM Students 
	WHERE student_id = 109;

/*7) Update the payment amount for a specific payment record in the "Payments" table. Choose any 
payment record and modify the payment amount. */

	UPDATE Payments 
	SET amount = 700.00 
	WHERE payment_id = 1;

--again viewing all 5 tables

Select * from Students;
Select * from Teacher;
Select * from Courses;
Select * from Enrollments;
Select * from Payments;


--TASK 3
--AGGREGATE FUNC, HAVING,ORDER BY, GROUPBY, JOIN
/*1) Write an SQL query to calculate the total payments made by a specific student. You will need to 
join the "Payments" table with the "Students" table based on the student's ID. */

	SELECT S.student_id, S.first_name, S.last_name, SUM(P.amount) AS total_payment 
	FROM Students S 
	LEFT JOIN Payments P ON S.student_id = P.student_id
	WHERE S.student_id = 105
	GROUP BY S.student_id, S.first_name, S.last_name;

/*2) Write an SQL query to retrieve a list of courses along with the count of students enrolled in each 
course. Use a JOIN operation between the "Courses" table and the "Enrollments" table. */

	SELECT C.course_id, C.course_name, COUNT(E.student_id) AS total_students 
	FROM Courses C 
	LEFT JOIN Enrollments E ON C.course_id = E.course_id 
	GROUP BY C.course_id, C.course_name 
	ORDER BY total_students DESC;
	
/*3) Write an SQL query to find the names of students who have not enrolled in any course. Use a 
LEFT JOIN between the "Students" table and the "Enrollments" table to identify students 
without enrollments. */

	SELECT S.student_id, S.first_name, S.last_name 
	FROM Students S 
	LEFT JOIN Enrollments E ON S.student_id = E.student_id 
	WHERE E.enrollment_id IS NULL
	ORDER BY S.first_name;

/*4) Write an SQL query to retrieve the first name, last name of students, and the names of the 
courses they are enrolled in. Use JOIN operations between the "Students" table and the 
"Enrollments" and "Courses" tables. */

	SELECT S.first_name, S.last_name, C.course_name 
	FROM Students S
	JOIN Enrollments E ON S.student_id = E.student_id
	JOIN Courses C ON E.course_id = C.course_id
	ORDER BY S.first_name, C.course_name;

/*5) Create a query to list the names of teachers and the courses they are assigned to. Join the 
"Teacher" table with the "Courses" table. */

	SELECT T.first_name, T.last_name, C.course_name 
	FROM Teacher T 
	JOIN Courses C ON T.teacher_id = C.teacher_id
	ORDER BY T.first_name, C.course_name;

/*6) Retrieve a list of students and their enrollment dates for a specific course. You'll need to join the 
"Students" table with the "Enrollments" and "Courses" tables.  */
	--initially joining student & enrollment table to link students to their enrollments
	--then joining course table to enrollment to specify individual student

	SELECT S.student_id, S.first_name, S.last_name, C.course_name, E.enrollment_date
	FROM Students S
	JOIN Enrollments E ON S.student_id = E.student_id
	JOIN Courses C ON E.course_id = C.course_id
	WHERE C.course_id = 11;

/* 7) Find the names of students who have not made any payments. Use a LEFT JOIN between the 
"Students" table and the "Payments" table and filter for students with NULL payment records.  */

	SELECT S.student_id, S.first_name, S.last_name FROM Students S
	LEFT JOIN Payments P ON S.student_id = P.student_id
	WHERE P.payment_date IS NULL;

/* 8)Write a query to identify courses that have no enrollments. You'll need to use a LEFT JOIN 
between the "Courses" table and the "Enrollments" table and filter for courses with NULL 
enrollment records. */

	SELECT C.course_id, C.course_name FROM Courses C
	LEFT JOIN Enrollments E ON C.course_id = E.course_id
	WHERE E.enrollment_id IS NULL;

/* 9)Identify students who are enrolled in more than one course. Use a self-join on the "Enrollments" 
table to find students with multiple enrollment records. */

	SELECT DISTINCT S.student_id, S.first_name, S.last_name FROM Students S
	JOIN Enrollments E1 ON S.student_id = E1.student_id  -- First enrollment record
	JOIN Enrollments E2 ON S.student_id = E2.student_id  -- Second enrollment record for the same student
	AND E1.course_id <> E2.course_id  -- Avoid duplicates
	ORDER BY S.first_name;
	--the provided table doesnt have students enrolled in more than one course, so no results are displayed

/*10) Find teachers who are not assigned to any courses. Use a LEFT JOIN between the "Teacher" 
table and the "Courses" table and filter for teachers with NULL course assignments. */

	SELECT t.teacher_id, T.first_name, T.last_name FROM Teacher T
	LEFT JOIN Courses C ON T.teacher_id = C.teacher_id
	WHERE C.course_id IS NULL;


--TASK 4
/*1) Write an SQL query to calculate the average number of students enrolled in each course. Use 
aggregate functions and subqueries to achieve this. */

	SELECT AVG(StudentCount) 'Average_count' FROM (
    SELECT course_id, COUNT(student_id) AS StudentCount FROM Enrollments
    GROUP BY course_id) AS EnrollmentCounts;

/*2) Identify the student(s) who made the highest payment. Use a subquery to find the maximum 
payment amount and then retrieve the student(s) associated with that amount. */

	SELECT s.*, p.amount AS Highest_payment FROM Students s
	JOIN Payments p ON s.student_id = p.student_id
	WHERE p.amount = (SELECT MAX(amount) FROM Payments);

/*3) Retrieve a list of courses with the highest number of enrollments. Use subqueries to find the 
course(s) with the maximum enrollment count. */

	SELECT c.course_id, c.course_name, COUNT(e.student_id) AS [Highest Enrollments] FROM Enrollments e
	JOIN Courses c on e.course_id = c.course_id GROUP BY c.course_id, c.course_name
	HAVING COUNT(e.student_id) =(SELECT MAX(Enrolled) FROM (SELECT COUNT(student_id) AS Enrolled 
	FROM Enrollments GROUP BY course_id) AS One);

/*4) Calculate the total payments made to courses taught by each teacher. Use subqueries to sum 
payments for each teacher's courses. */

	SELECT t.teacher_id, t.first_name, t.last_name,
		(SELECT SUM(p.amount) FROM Payments p
		WHERE p.student_id IN ( SELECT e.student_id  FROM Enrollments e
		WHERE e.course_id IN (SELECT c.course_id FROM Courses c 
		WHERE c.teacher_id = t.teacher_id))) AS total_payments
	FROM Teacher t;

/*5) Identify students who are enrolled in all available courses. Use subqueries to compare a 
student's enrollments with the total number of courses. */
			
	--finding students whose enrollment count matches total courses, & distinct removes duplicates
	--in provided data there are no students who enrolled for all the available courses
	SELECT student_id, first_name, last_name FROM Students
	WHERE student_id IN (SELECT e.student_id FROM Enrollments e
    GROUP BY e.student_id
    HAVING COUNT(DISTINCT e.course_id) = (SELECT COUNT(*) FROM Courses));

/*6) Retrieve the names of teachers who have not been assigned to any courses. Use subqueries to 
find teachers with no course assignments. */
	
	SELECT teacher_id, first_name, last_name FROM Teacher t
	WHERE NOT EXISTS (SELECT 1 FROM Courses c WHERE c.teacher_id = t.teacher_id);

/*7) Calculate the average age of all students. Use subqueries to calculate the age of each student 
based on their date of birth. */

	SELECT AVG(student_age) AS average_age FROM (
    SELECT DATEDIFF(YEAR, date_of_birth, GETDATE()) AS student_age FROM Students) AS One;

/*8) Identify courses with no enrollments. Use subqueries to find courses without enrollment 
records. */

	SELECT * FROM Courses c WHERE NOT EXISTS (SELECT 1 FROM Enrollments e 
	WHERE e.course_id = c.course_id) ;

/*9) Calculate the total payments made by each student for each course they are enrolled in. Use 
subqueries and aggregate functions to sum payments. */

	SELECT e.student_id, 
		(SELECT s.first_name FROM Students s WHERE s.student_id = e.student_id) AS first_name,
		(SELECT s.last_name FROM Students s WHERE s.student_id = e.student_id) AS last_name,
		(SELECT SUM(p.amount) FROM Payments p WHERE p.student_id = e.student_id) AS total_payments
	FROM Enrollments e;

/*10) Identify students who have made more than one payment. Use subqueries and aggregate 
functions to count payments per student and filter for those with counts greater than one */
    
	--provided data donot contain more than one payments, Additional payment for 2 students 
	INSERT INTO Payments (payment_id, student_id, amount, payment_date)
	VALUES 
	(11, 106, 250.00, '2025-02-10'),  
	(12, 107, 200.00, '2025-03-05');   

	--getting student details of more than one payment
	SELECT student_id, first_name, last_name FROM Students 
	WHERE student_id IN (SELECT student_id FROM Payments 
	GROUP BY student_id 
	HAVING COUNT(payment_id) > 1);

/*11) Write an SQL query to calculate the total payments made by each student. Join the "Students" 
table with the "Payments" table and use GROUP BY to calculate the sum of payments for each 
student. */

	SELECT s.first_name, s.last_name, SUM(p.amount) AS Paid_amt from Students s 
	JOIN Payments p ON p.student_id = s.student_id
	GROUP BY s.student_id, s.first_name, s.last_name;

/*12) Retrieve a list of course names along with the count of students enrolled in each course. Use 
JOIN operations between the "Courses" table and the "Enrollments" table and GROUP BY to 
count enrollments. */

	SELECT c.course_name, COUNT(e.student_id) AS stud_count FROM Enrollments e
	JOIN Courses c ON c.course_id = e.course_id
	GROUP BY c.course_name,c.course_id;

/*13) Calculate the average payment amount made by students. Use JOIN operations between the 
"Students" table and the "Payments" table and GROUP BY to calculate the average. */

	SELECT s.student_id, s.first_name, s.last_name, 
    AVG(p.amount) AS average_payment FROM Students s
	JOIN Payments p ON s.student_id = p.student_id
	GROUP BY s.student_id, s.first_name, s.last_name;






