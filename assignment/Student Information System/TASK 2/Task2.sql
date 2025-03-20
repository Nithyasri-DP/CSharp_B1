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