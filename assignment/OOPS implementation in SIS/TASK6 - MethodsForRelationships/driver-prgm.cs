using System;

namespace StudentInformationSystem
{
    // Main program file
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating SIS instance [TASK-6]
            SIS sis = new SIS();

            // ----------- Creating sample objects [TASK-6]

            // Creating Student objects
            Student s1 = new Student(1, "Sherin", "Farhana", new DateTime(2000, 1, 15), "sherin@gmail.com", "45670");
            Student s2 = new Student(2, "Kowshik", "Mehta", new DateTime(2001, 3, 10), "kowshimehta@gmail.com", "23590");

            // Creating Teacher objects [TASK-6]
            Teacher t1 = new Teacher(1, "Meena", "Sharma", "meena.sharma@gmail.com");
            Teacher t2 = new Teacher(2, "Baskar", "Sethupathi", "baskar@gmail.com");

            // Creating Courses objects [TASK-6]
            Course c1 = new Course(1, "Microcontrol", "MICRO06", "Meena Sharma");
            Course c2 = new Course(2, "Robotics", "ROBO10", "Baskar Sethupathi");

            // Add students, teachers, and courses to SIS lists [TASK-6]
            sis.Students.AddRange(new[] { s1, s2 });
            sis.Teachers.AddRange(new[] { t1, t2 });
            sis.Courses.AddRange(new[] { c1, c2 });

            // Add payments BEFORE enrollments to avoid InsufficientFundsException [TASK-6]
            sis.AddPayment(s1, 1000m, new DateTime(2024, 7, 19));
            sis.AddPayment(s2, 1200m, new DateTime(2024, 8, 22));

            // AddEnrollment [TASK-6]
            sis.AddEnrollment(s1, c1, new DateTime(2024, 8, 10));  // Sherin - Microcontrol
            sis.AddEnrollment(s2, c2, new DateTime(2024, 11, 12));  // Kowshik - Robotics
            sis.AddEnrollment(s1, c2, new DateTime(2024, 9, 15));  // Sherin - Robotics

            // AssignCourseToTeacher [TASK-6]
            sis.AssignCourseToTeacher(c1, t1);
            sis.AssignCourseToTeacher(c2, t2);

            // GetEnrollmentsForStudent [TASK-6]
            Console.WriteLine($"\nEnrollments for {s1.FirstName} {s1.LastName}:");
            foreach (var enrollment in sis.GetEnrollmentsForStudent(s1))
            {
                Console.WriteLine($" - {enrollment.GetCourse().CourseName} on {enrollment.EnrollmentDate.ToShortDateString()}");
            }

            //  GetCoursesForTeacher [TASK-6]
            Console.WriteLine($"\nCourses assigned to {t1.FirstName} {t1.LastName}:");
            foreach (var course in sis.GetCoursesForTeacher(t1))
            {
                Console.WriteLine($" - {course.CourseName}");
            }

            //ExceptionTests.RunAll(); [TASK-4]
        }
    }    
}
