--database design

create database SISDB;

use SISDB;

--creating tables with given appropriate data
--1)STUDENTS TABLE

create table Students 
	(
    student_id INT PRIMARY KEY,
    first_name VARCHAR(20) NOT NULL,
    last_name VARCHAR(20),
    date_of_birth DATE,
    email VARCHAR(50),
    phone_number VARCHAR(15) UNIQUE
);

--creating teachers table secondly as the course table consists of foreign key 
--2)TEACHER TABLE

create table Teacher
	(
	teacher_id INT PRIMARY KEY,
	first_name VARCHAR(20) NOT NULL,
	last_name VARCHAR(20),
	email VARCHAR(50)
);

--3)COURSES TABLE

create table Courses
(
	course_id INT PRIMARY KEY,
	course_name VARCHAR(100),
    credits INT,
    teacher_id INT,
    FOREIGN KEY (teacher_id) REFERENCES Teacher(teacher_id) 
);

--4)ENROLLMENTS TABLE

create table Enrollments 
(
    enrollment_id INT PRIMARY KEY,
    student_id INT,
    course_id INT,
    enrollment_date DATE,
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) 
);

--5)Payments Table

create table Payments 
(
    payment_id INT PRIMARY KEY,
    student_id INT,
    amount DECIMAL(10,2),
    payment_date DATE,
    FOREIGN KEY (student_id) REFERENCES Students(student_id)
);

--inserting 10 elements for each table 
--1)STUDENTS TABLE

insert into Students (student_id, first_name, last_name, date_of_birth, email, phone_number) 
	values
	(101, 'Anu', 'Vidhya', '2000-05-15', 'anuvidhya@gmail.com', 48291),
	(102, 'Banu', 'Priya', '2002-07-20', 'banupriya@yahoo.com', 75903),
	(103, 'Charu', 'Mathi', '2001-03-10', 'charumathi@outlook.com', 63827),
	(104, 'Diya', 'Kannan', '1998-11-25', 'diyakannan@gmail.com', 19274),
	(105, 'Nila', 'Sri', '2004-06-30', 'nilasri@yahoo.com', 84629),
	(106, 'Riya', 'Akash', '2003-01-12', 'riyaakash@outlook.com', 50718),
	(107, 'Mrunal', 'Siksha', '1997-09-18', 'mrunalnisiksha@gmail.com', 93582),
	(108, 'Niharika', 'Sumit', '1996-04-23', 'niharikasumit@yahoo.com', 21469),
	(109, 'Lekha', 'Sri', '1995-12-05', 'lekhasri@outlook.com', 67035),
	(110, 'Nithya', 'Vasudevan', '2004-02-29', 'nithyavasudevan@gmail.com', 38914);

--2)TEACHERS TABLE

insert into Teacher (teacher_id, first_name, last_name, email) 
	values
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

insert into Courses (course_id, course_name, credits, teacher_id) 
	values
	(11, 'Data Structures', 4, 51),
	(12, 'DBMS', 4, 58),
	(13, 'OOPS', 4, 51),
	(14, 'Cyber Security', 2, 52),
	(15, 'TOC', 1, 55),
	(16, 'AI', 4, 56),
	(17, 'ML', 4, 53),
	(18, 'Networks', 3, 58),
	(19, 'OS', 3, 55),
	(20, 'Software Engg', 3, 60);

--adding some more elements to insert all the teachers_id values that're ref to course table 

insert into Courses (course_id, course_name, credits, teacher_id) 
	values
	(21, 'DLD', 2, 54),
	(22, 'Design thinking', 1, 59),
	(23, 'Data mining', 4, 57),
	(24, 'IOT', 3, 60),
	(25, 'Laboratory', 2, 52)
	   	  

--4)ENROLLMENT TABLE

insert into Enrollments (enrollment_id, student_id, course_id, enrollment_date) 
	values
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

insert into Payments (payment_id, student_id, amount, payment_date) 
	values
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

