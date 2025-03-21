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