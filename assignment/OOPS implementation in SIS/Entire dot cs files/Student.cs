using System;
using System.Collections.Generic;

namespace StudentInformationSystem
{
    // Creating Student class [TASK-1]
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //To identify balance(excep)
        public decimal Balance { get; set; } = 0;


        /* Lists to store enrollments and payments [TASK-3]

        private List<Course> enrolledCourses = new List<Course>();
        private List<Payment> paymentHistory = new List<Payment>();*/

        //Defining class-level collections for relationships
        //Changed from List<Course> to List<Enrollment> [TASK-5] 
        public List<Enrollment> Enrollments { get; set; }

        //Changed from private List<Payment> to public List<Payment> [TASK-5] 
        public List<Payment> Payments { get; set; }

        // Constructor implementation [TASK-2]
        public Student(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            //updating constructor to validate student data(excep)
            if (dateOfBirth > DateTime.Now)
            {
                throw new InvalidStudentDataException("Invalid DOB, Date of birth cannot be in future");
            }
            if (!email.Contains("@"))
            {
                throw new InvalidStudentDataException("Invalid email format, Email must contain '@'");
            }

            this.StudentID = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Email = email;
            this.PhoneNumber = phoneNumber;

            //Initialize collections on object creation [TASK-5] 
            Enrollments = new List<Enrollment>();
            Payments = new List<Payment>();
        }

        // 1)Enroll student in a course [TASK-3] + [TASK-5]
        public void EnrollInCourse(Course course)
        {
            //Check if student exists(excep)
            if (this == null)
                throw new StudentNotFoundException("Student does not exist.");

            //Check if the course exists(excep)
            if (course == null)
            {
                throw new CourseNotFoundException("The specified course does not exist.");
            }

            //Check if the student is already enrolled in the course(excep)
            //Rewriting task-3 using foreach loop for task-5

            foreach (var enrollment in Enrollments)
            {
                if (enrollment.Course.CourseID == course.CourseID)
                    throw new DuplicateEnrollmentException($"Student {FirstName} is already enrolled in {course.CourseName}");
            }

            decimal courseFee = 1000;

            if (Balance < courseFee)
                throw new InsufficientFundsException($"Insufficient funds. Course fee is {courseFee}, but balance is {Balance}");


            // Create and link new enrollment [TASK-5]
            Enrollment newEnrollment = new Enrollment(Enrollments.Count + 1, this, course, DateTime.Now);
            Enrollments.Add(newEnrollment);
            course.Enrollments.Add(newEnrollment); // Link student to course
            Console.WriteLine($"{FirstName} enrolled in {course.CourseName}");
        }

        // 2)Updating student details [TASK-3]
        public void UpdateStudentInfo(string firstName, string lastName, DateTime dob, string email, string phone)
        {
            // Check if right details are entered(excep)
            if (dob > DateTime.Now)
            {
                throw new InvalidStudentDataException("Invalid DOB, Date of birth cannot be in future");
            }

            if (!email.Contains("@"))
            {
                throw new InvalidStudentDataException("Invalid email format, Email must contain '@'");
            }

            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            Email = email;
            PhoneNumber = phone;
            Console.WriteLine("Student details updated");
        }      

        // 3)Making payment [TASK-3 + TASK-5]
        public void MakePayment(int paymentId, decimal amount, DateTime paymentDate)
        {
            // Check if student exists(excep)
            if (this == null)
                throw new StudentNotFoundException("Student does not exist.");

            Payment payment = new Payment(paymentId, this, amount, paymentDate);
            Payments.Add(payment);
            Balance += amount;
            Console.WriteLine($"{FirstName} made a payment of {amount} on {paymentDate.ToShortDateString()}.");
        }

        // 4)Displaying student details [TASK-3]
        public void DisplayStudentInfo()
        {
            Console.WriteLine($"ID: {StudentID}, Name: {FirstName} {LastName}, DOB: {DateOfBirth.ToShortDateString()}");
            Console.WriteLine($"Email: {Email}, Phone: {PhoneNumber}");
        }

        // 5)Enrolled courses [TASK-3]        
        public List<Course> GetEnrolledCourses()
        {
            List<Course> courses = new List<Course>();
            foreach (var enrollment in Enrollments)
            {
                courses.Add(enrollment.Course);
            }
            return courses;
        }
        // 6)Payment history [TASK-3 + TASK-5]
        public List<Payment> GetPaymentHistory()
        {
            return Payments;
        }
    }
}
