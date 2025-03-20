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