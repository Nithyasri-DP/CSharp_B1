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

            // ------------------------------------------TASK-7----------------------------------------------------
            //Calling methods from other classes
             Database.GetAllStudents();
             Database.GetAllCourses();
             Database.GetAllEnrollments();
             Database.GetAllTeachers();  
             Database.GetAllPayments();

            // UpdateStudentInfo();
             Console.ReadLine();

            // Inserting student data [TASK-7]
               Database.InsertStudent(121, "Mary", "Jasmine", new DateTime(2000, 5, 15), "maryyy@gmail.com", "48091");
               Database.InsertStudent(112, "Anikha", "Surendran", new DateTime(2002, 7, 25), "anikha@gmail.com", "91341");

              // Inserting enrollment data [TASK-7]
              Database.InsertEnrollment(11, 112, 13,new DateTime(2025, 1, 29));

              // Inserting payment data[TASK-7]
              Database.InsertPayment(13, 121, 1500.00m, new DateTime(2025, 1, 14));

                static void UpdateStudentInfo()
                {
                    Console.WriteLine("Enter student ID to update:");
                    int studentId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter first name:");
                    string? firstName = Console.ReadLine();

                    Console.WriteLine("Enter last name:");
                    string? lastName = Console.ReadLine();

                    Console.WriteLine("Enter email:");
                    string? email = Console.ReadLine();

                    Console.WriteLine("Enter phone number:");
                    string phoneNumber = Console.ReadLine();

                    Database.UpdateStudent(studentId, firstName, lastName, email, phoneNumber);
                }

              //Transaction management when enrolling students
              Database.EnrollStudentWithPayment(121, 15, DateTime.Now, 2500.00m, DateTime.Now);
              Console.ReadLine();

              //Transaction management when assigning teachers
              Database.AssignTeacherToCourseTransactional(58, 17);  // teacher_id, course_id
              Console.ReadLine(); 

            // viewing assigned teacher to the course
             Database.ShowCoursesByTeacher(58);


            //Transaction management when recording payments
            Database.RecordPaymentTransactional(104, 1300.00m, DateTime.Now); //student_id 

            //Accepting user input for dynamic query
            Console.Write("Enter table name: ");
            string tableName = Console.ReadLine();

            Console.Write("Enter columns to retrieve: ");
            string[] colArray = Console.ReadLine().Split(',');
            List<string> columns = new List<string>(colArray);

            // Accept multiple conditions
            Dictionary<string, string> conditions = new Dictionary<string, string>();
            Console.Write("Enter number of conditions: ");
            int condCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < condCount; i++)
            {
                Console.Write($"Enter condition column {i + 1}: ");
                string col = Console.ReadLine();

                Console.Write($"Enter value for {col}: ");
                string val = Console.ReadLine();

                conditions.Add(col, val);
            }

            Console.Write("Enter column to sort by (or leave blank to skip): ");
            string orderByColumn = Console.ReadLine();

            Console.Write("Sort ascending? (yes/no): ");
            bool ascending = Console.ReadLine().Trim().ToLower() == "yes";

            // Call the dynamic query method from sub class
            Database.DynamicQueryBuilder(tableName, columns, conditions, orderByColumn, ascending); 

            //Calling program [TASK-8]
            Database.EnrollJohnDoe();

            //Displaying output [TASK-8]
            Database.ShowJohnDoeEnrollments();
        }
    }
}
