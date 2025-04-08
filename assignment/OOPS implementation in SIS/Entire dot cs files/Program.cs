using System;

namespace StudentInformationSystem
{
    // Main program file
    internal class Program
    {
        static void Main(string[] args)
        {
            //Calling methods from other classes

            //[TASK-3]
              Task.TestMethods();

               //[TASK-4]
               ExceptionTests.RunException();   

               //[TASK-5]
               Task.TestCollections();

               //TASK-6]
               Task.DriverPrgm();

               //[TASK-7]  
               //Retrieval of tables
               Database.GetAllStudents();
               Database.GetAllCourses();
               Database.GetAllEnrollments();
               Database.GetAllTeachers();  
               Database.GetAllPayments();

               //Insertion and Updation        

                Task.InsertStudentFromUserInput();
                Task.InsertEnrollmentFromUserInput();
                Task.InsertPaymentFromUserInput();
                Task.GetInputForEnrollmentWithPayment();            
                Task.GetInputForTeacherAssignment();
                Task.GetInputForPaymentRecording();


               //Transactions(Enrolling students + their payments and recording payments can viewed by table retreivals)
               //Viewing assigned teacher to the course
               Database.ShowCoursesByTeacher(55);

               //Dynamic Query Builder
               Task.RunDynamicQuery();

               //[TASK-8]
               Database.EnrollStudentFromInput();

               //[TASK-9]
               Task.PerformTask9(); 

               //[TASK-10]
               //PerformTaskTen is created for adding new student and Payment is to record new pays
               Task.PerformTaskten();
               Task.PaymentRecord(); 

               //Viweing students details(id-100)
               Console.Write("Enter Student ID to retrieve: ");
               int studentId = Convert.ToInt32(Console.ReadLine());
               Database.GetStudentById(studentId);  

               //[TASK-11]
               //Performtask11 is for creating new course, as we dont have the required course
               Task.PerformTask11();

               //Generating report for Computer Science 101
               Console.Write("Enter course name to generate report: ");
               string courseName = Console.ReadLine();
               Database.GenerateEnrollmentReport(courseName); 

        }
    }
}
