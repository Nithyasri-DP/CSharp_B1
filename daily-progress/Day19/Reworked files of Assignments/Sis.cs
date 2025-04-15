using System;
using System.Collections.Generic;

namespace StudentInformationSystem
{
    // Sis class is defined as part of the system design [TASK-2]
    public class SIS
    {
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Payment> Payments { get; set; }

        // Constructor implementation [TASK-2]
        public SIS()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Enrollments = new List<Enrollment>();
            Teachers = new List<Teacher>();
            Payments = new List<Payment>();
        }
        // 1)Enroll a student in a course [TASK-3]
        public void EnrollStudentInCourse(Student student, Course course)
        {
            Enrollment enrollment = new Enrollment(Enrollments.Count + 1, student, course, DateTime.Now);
            Enrollments.Add(enrollment);
            student.EnrollInCourse(course);
            Console.WriteLine($"Enrolled {student.FirstName} in {course.CourseName}.");
        }

        // 2)Assign a teacher to a course [TASK-3]
        public void AssignTeacherToCourse(Teacher teacher, Course course)
        {
            course.AssignTeacher(teacher);
            Console.WriteLine($"Assigned {teacher.FirstName} {teacher.LastName} to {course.CourseName}.");
        }

        // 3)Record a payment made by a student [TASK-3]
        public void RecordPayment(Student student, decimal amount, DateTime paymentDate)
        {
            Payment payment = new Payment(Payments.Count + 1, student, amount, paymentDate);
            Payments.Add(payment);
            student.MakePayment(payment.PaymentID, amount, paymentDate);
            Console.WriteLine($"Payment of {amount} recorded for {student.FirstName}.");
        }

        // 4)Generate a report of students enrolled in a specific course [TASK-3]
        public void GenerateEnrollmentReport(Course course)
        {
            Console.WriteLine($"\nEnrollment Report for {course.CourseName}:");

            foreach (var enrollment in Enrollments)
            {
                if (enrollment.GetCourse() == course)
                {
                    Console.WriteLine($"Student: {enrollment.GetStudent().FirstName} {enrollment.GetStudent().LastName}");
                }
            }
        }

        // 5)Generate a report of payments made by a specific student [TASK-3]
        public void GeneratePaymentReport(Student student)
        {
            Console.WriteLine($"\nPayment Report for {student.FirstName} {student.LastName}:");

            foreach (var payment in Payments)
            {
                if (payment.GetStudent() == student)
                {
                    Console.WriteLine($"Amount: {payment.GetPaymentAmount()}, Date: {payment.GetPaymentDate().ToShortDateString()}");
                }
            }
        }

        // 6)Calculate statistics for a specific course (number of enrollments & total payments) [TASK-3]
        public void CalculateCourseStatistics(Course course)
        {
            int count = 0;
            decimal totalPayments = 0;

            foreach (var enrollment in Enrollments)
            {
                if (enrollment.GetCourse() == course)
                {
                    count++;
                }
            }

            foreach (var payment in Payments)
            {
                if (payment.GetStudent().GetEnrolledCourses().Contains(course))
                {
                    totalPayments += payment.GetPaymentAmount();
                }
            }

            Console.WriteLine($"\nCourse Statistics for {course.CourseName}:");
            Console.WriteLine($"Total Enrollments: {count}");
            Console.WriteLine($"Total Payments: {totalPayments}");
        }

        // ----------------- Methods for Managing Relationships [TASK-6] 
        // 1)AddEnrollment(student, course, enrollmentDate) [TASK-6]
        public void AddEnrollment(Student student, Course course, DateTime enrollmentDate)
        {
            Enrollment enrollment = new Enrollment(Enrollments.Count + 1, student, course, enrollmentDate);
            Enrollments.Add(enrollment);
            student.EnrollInCourse(course);
            course.AddEnrollment(enrollment);
        }

        // 2)AssignCourseToTeacher(course, teacher) [TASK-6]
        public void AssignCourseToTeacher(Course course, Teacher teacher)
        {
            course.AssignTeacher(teacher);
            teacher.AssignCourse(course);
        }

        // 3)AddPayment(student, amount, paymentDate) [TASK-6]
        public void AddPayment(Student student, decimal amount, DateTime paymentDate)
        {
            Payment payment = new Payment(Payments.Count + 1, student, amount, paymentDate);
            Payments.Add(payment);
            student.MakePayment(payment.PaymentID, amount, paymentDate);
        }

        // 4)GetEnrollmentsForStudent(student) [TASK-6]
        public List<Enrollment> GetEnrollmentsForStudent(Student student)
        {
            List<Enrollment> result = new List<Enrollment>();
            foreach (var enrollment in Enrollments)
            {
                if (enrollment.GetStudent() == student)
                {
                    result.Add(enrollment);
                }
            }
            return result;
        }

        // 5)GetCoursesForTeacher(teacher) [TASK-6]
        public List<Course> GetCoursesForTeacher(Teacher teacher)
        {
            return teacher.GetAssignedCourses();
        }
    }
}
