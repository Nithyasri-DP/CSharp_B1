using System;
using System.Collections.Generic;
namespace StudentInformationSystem
{
    public static class Task
    {
        //---------------------------------------[TASK-3]
        // Sample temp data addition for TASK-3 (values will not be allocated in SIS_DB)
        public static void TestMethods()
        {
            Student studadd = new Student(111, "Kavya", "Rao", new DateTime(2003, 8, 8), "kavyarao@gmail.com", "14345");
            // Add balance before payment to avoid error
            studadd.AddBalance(2000.00m);
            Course courseTest = new Course(16, "AI", "AI101", "Bhava Dharani");
            studadd.EnrollInCourse(courseTest);
            studadd.MakePayment(13, 600.00m, new DateTime(2025, 02, 15));
            studadd.DisplayStudentInfo();
            courseTest.DisplayCourseInfo();
        }

        //---------------------------------------[TASK-4,5]
        // Task 4 methods is in Exceptions.cs file
        // Sample objects to test created collections [TASK-5]
        public static void TestCollections()
        {
            // Creating student [TASK-5]
            Student s1 = new Student(201, "Kiran", "Patel", new DateTime(2002, 6, 12), "kiran.patel@gmail.com", "99999");
            s1.AddBalance(1000); // Add balance for enrollment

            // Creating courses [TASK-5]
            Course c1 = new Course(301, "Data Science", "DS101", "Dr. Aarti");
            Course c2 = new Course(302, "Cyber Security", "CS101", "Dr. Ravi");

            // Enrolling student in courses [TASK-5]
            s1.EnrollInCourse(c1);
            s1.EnrollInCourse(c2);

            // Display student enrollments [TASK-5]
            Console.WriteLine($"\nCourses enrolled by {s1.FirstName}:");
            foreach (var enrollment in s1.Enrollments)
            {
                Console.WriteLine($"- {enrollment.Course.CourseName}");
            }

            // Creating teacher and assigning courses [TASK-5]
            Teacher t1 = new Teacher(401, "Dr. Aarti", "Computer Science", "aarti@college.edu");
            t1.AssignCourse(c1);
            t1.AssignCourse(c2);

            // Display teacher's assigned courses [TASK-5]
            Console.WriteLine($"\nCourses assigned to {t1.FirstName} {t1.LastName}:");
            foreach (var course in t1.AssignedCourses)
            {
                Console.WriteLine($"- {course.CourseName}");
            }

            // Make payment [TASK-5]
            s1.MakePayment(501, 500, DateTime.Now);

            // Display student payment history [TASK-5]
            Console.WriteLine($"\nPayment history for {s1.FirstName}:");
            foreach (var payment in s1.Payments)
            {
                Console.WriteLine($"- Paid {payment.Amount} on {payment.PaymentDate.ToShortDateString()}");
            }
        }

        //---------------------------------------[TASK-6]
        public static void DriverPrgm()
        {
            // Creating SIS instance and working in main program as mentioned in question [TASK-6]
            SIS sis = new SIS();

            // Creating Student objects [TASK-6]
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
        }

        //---------------------------------------[TASK-7]
        //DATA INITIALIZATION
        // Inserting student data [TASK-7]
        public static void InsertStudentFromUserInput()
        {
            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Date of Birth (yyyy-mm-dd): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Database.InsertStudent(studentId, firstName, lastName, dob, email, phone);
        }

        // Inserting enrollment data [TASK-7]
        public static void InsertEnrollmentFromUserInput()
        {
            Console.Write("Enter Enrollment ID: ");
            int enrollmentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            Console.Write("Enter Enrollment Date (yyyy-mm-dd): ");
            DateTime enrollmentDate = DateTime.Parse(Console.ReadLine());

            Database.InsertEnrollment(enrollmentId, studentId, courseId, enrollmentDate);
        }

        // Inserting payment data[TASK-7]
        public static void InsertPaymentFromUserInput()
        {
            Console.Write("Enter Payment ID: ");
            int paymentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Payment Date (yyyy-mm-dd): ");
            DateTime paymentDate = DateTime.Parse(Console.ReadLine());

            Database.InsertPayment(paymentId, studentId, amount, paymentDate);
        }

        //Transaction management when enrolling students
        public static void GetInputForEnrollmentWithPayment()
        {
            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            Console.Write("Enter Enrollment Date (yyyy-mm-dd): ");
            DateTime enrollmentDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Payment Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Payment Date (yyyy-mm-dd): ");
            DateTime paymentDate = DateTime.Parse(Console.ReadLine());

            // Call transactional method
            Database.EnrollStudentWithPayment(studentId, courseId, enrollmentDate, amount, paymentDate);
        }

        //Transaction management when assigning teachers
        public static void GetInputForTeacherAssignment()
        {
            Console.Write("Enter Teacher ID: ");
            int teacherId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            // Call transactional assignment method
            Database.AssignTeacherToCourseTransactional(teacherId, courseId);
        }

        //Transaction management when recording payments
        public static void GetInputForPaymentRecording()
        {
            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Payment Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Payment Date (yyyy-MM-dd): ");
            DateTime paymentDate = DateTime.Parse(Console.ReadLine());

            Database.RecordPaymentTransactional(studentId, amount, paymentDate);
        }       

        // UPDATE DETAILS [TASK-7]
        public static void UpdateStudentInfo()
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

        // DYNAMIC QUERY [TASK-7]
        public static void RunDynamicQuery()
        {
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
        }

        //------------------------------------------TASK-9

        public static void PerformTask9()
        {
            Console.Write("Enter Course ID to assign the teacher:");
            int courseId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Name:");
            string courseName = Console.ReadLine();

            Console.Write("Enter Course Code:");
            string courseCode = Console.ReadLine();

            // Insert course into database
            Database.InsertCourse(courseId, courseName, 3);

            Console.Write("Enter Teacher ID:");
            int teacherId = int.Parse(Console.ReadLine());

            Console.Write("Enter Teacher First Name:");
            string firstName = Console.ReadLine();

            Console.Write("Enter Teacher Last Name:");
            string lastName = Console.ReadLine();

            Console.Write("Enter Teacher Email:");
            string email = Console.ReadLine();

            // Insert teacher into database
            Database.InsertTeacher(teacherId, firstName, lastName, email);

            // Assign teacher to the course using transaction
            Database.AssignTeacherToCourseTransactional(teacherId, courseId);

            Console.Write("Teacher assigned to course successfully");
        }

        //------------------------------------------TASK-10
        //Entering details for a new student
        public static void PerformTaskten()
        {
            Console.WriteLine("Enter Student Details:");
            Console.Write("Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Date of Birth (yyyy-mm-dd): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();

            Database.InsertStudent(studentId, firstName, lastName, dob, email, phone);
            Console.WriteLine("Student inserted successfully.");
        }
        //Making payment for that new student
        public static void PaymentRecord()
        {
            Console.Write("Enter Payment Details:");
            Console.Write("Payment ID: ");
            int paymentId = int.Parse(Console.ReadLine());

            Console.Write("Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Payment Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.Write("Payment Date (yyyy-mm-dd): ");
            DateTime paymentDate = DateTime.Parse(Console.ReadLine());

            Database.InsertPayment(paymentId, studentId, amount, paymentDate);
            Console.Write("Payment recorded successfully.");
        }

        //------------------------------------------TASK-11
        //Adding course details, the provided is not present in our table
        public static void PerformTask11()
        {
            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();

            Console.Write("Enter Credits: ");
            int credits = int.Parse(Console.ReadLine());

            Database.InsertCourse(courseId, courseName, credits);
            Console.WriteLine("Course inserted successfully");
        }
    }
}
    
