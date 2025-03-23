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
