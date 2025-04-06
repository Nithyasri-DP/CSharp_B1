using System;

namespace StudentInformationSystem
{
    public class ExceptionTests
    {
        public static void RunAll()
        {
            //Hard coded examples to demonstrate exceptions(moved to new .cs file for segregation)
            // 1)DuplicateEnrollmentException
            try
            {
                Student student = new Student(111, "Kavya", "Rao", new DateTime(2003, 8, 8), "kavyarao@gmail.com", "14345");
                Course courseTest = new Course(16, "AI", "AI101", "Bhava Dharani");
                student.Balance = 2000; //Using this here to avoid catching in insufficient bal exception

                student.EnrollInCourse(courseTest);
                student.EnrollInCourse(courseTest);
            }
            catch (DuplicateEnrollmentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            // 2)CourseNotFoundException - Enrolling student
            try
            {
                Course invalidCourse = null;
                Student student = new Student(112, "Aryan", "Sharma", new DateTime(2002, 5, 20), "aryansharma@gmail.com", "98765");

                if (invalidCourse == null)
                    throw new CourseNotFoundException("Cannot enroll, course does not exist");

                student.EnrollInCourse(invalidCourse);
            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            // 2)CourseNotFoundException - Assigning Teacher 
            try
            {
                Course invalidCourse = null;
                Teacher teacher = new Teacher(61, "Rajesh", "Kumar", "rajesh@gmail.com");

                if (invalidCourse == null)
                    throw new CourseNotFoundException("Cannot assign a teacher, course does not exist");

                invalidCourse.AssignTeacher(teacher);
            }
            catch (CourseNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            // 3)StudentNotFoundException - Enrolling a Non-Existent Student
            try
            {
                Student nonExistentStudent = null;
                Course course = new Course(10, "MedicalInformatics", "MED01", "Arjun");

                if (nonExistentStudent == null)
                    throw new StudentNotFoundException("Cannot enroll, student does not exist");

                nonExistentStudent.EnrollInCourse(course);
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            // 3) StudentNotFoundException - Making Payment for Non-Existent Student
            try
            {
                Student nonExistentStudent = null;

                if (nonExistentStudent == null)
                    throw new StudentNotFoundException("Cannot make payment, student does not exist");

                nonExistentStudent.MakePayment(501, 2000.00m, DateTime.Now);
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            // 4)TeacherNotFoundException - Assigning a Non-Existent Teacher
            try
            {
                Course course = new Course(21, "Physics", "PHY101", "Ashok");
                Teacher nonExistentTeacher = null;

                if (nonExistentTeacher == null)
                    throw new TeacherNotFoundException("Cannot assign teacher, teacher does not exist");

                course.AssignTeacher(nonExistentTeacher);
            }
            catch (TeacherNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            // 5)PaymentValidationException - Invalid Amount
            try
            {
                Student student = new Student(113, "Ravi", "Verma", new DateTime(2001, 7, 15), "raviverma@gmail.com", "93210");

                Payment invalidPayment = new Payment(301, student, -500, DateTime.Now);
            }
            catch (PaymentValidationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            // 5)PaymentValidationException - Future Payment Date
            try
            {
                Student student = new Student(114, "Sneha", "Iyer", new DateTime(2000, 6, 10), "sneha.iyer@gmail.com", "82109");

                Payment futurePayment = new Payment(302, student, 1000, DateTime.Now.AddDays(5));
            }
            catch (PaymentValidationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            // 6)InvalidStudentDataException - Invalid Date of Birth
            try
            {
                Student invalidStudent = new Student(117, "Vishika", "Anand", new DateTime(2030, 5, 10), "vishikanand@gmail.com", "98245");
            }
            catch (InvalidStudentDataException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }

            //7)InvalidCourseDataException - Invalid course code
            try
            {
                Course course = new Course(21, "Data Structures", "DS101", "Anjali");
                course.UpdateCourse("Advanced Data Structures", "DS", "Anjali");
            }
            catch (InvalidCourseDataException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            //8)InvalidEnrollmentDataException - Creating invalid enrollment 
            try
            {
                Student student = null;
                Course course = new Course(31, "Cybersecurity", "CYB101", "Meena");
                Enrollment invalidEnrollment = new Enrollment(501, student, course, DateTime.Now);
            }
            catch (InvalidEnrollmentDataException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            //9)InvalidTeacherDataException
            try
            {
                Teacher invalidTeacher = new Teacher(101, "", "Nair", "nairemail.com");
            }
            catch (InvalidTeacherDataException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            //10)InsufficientFundsException - New student has no balance initially
            try
            {
                Student student = new Student(1, "Arun", "Kumar", new DateTime(2000, 1, 1), "arun@email.com", "90210");
                Course course = new Course(101, "Data Structures", "DS101", "AkashSharma");

                student.EnrollInCourse(course);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}