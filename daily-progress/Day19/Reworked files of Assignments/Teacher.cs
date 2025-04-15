using System;
using System.Collections.Generic;

namespace StudentInformationSystem
{
    // Creating Teacher class [TASK-1]
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Stores assigned courses [TASK-3]

        // private List<Course> assignedCourses = new List<Course>();

        // Changing the private list to public in collections[TASK-5]
        public List<Course> AssignedCourses { get; set; }


        // Constructor implementation [TASK-2]
        public Teacher(int teacherId, string firstName, string lastName, string email)
        {
            //Constructor validation(excep)
            if (string.IsNullOrWhiteSpace(firstName))
                throw new InvalidTeacherDataException("First name cannot be empty");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new InvalidTeacherDataException("Invalid email format");

            TeacherID = teacherId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;

            // Initialize the property[TASK-5]
            AssignedCourses = new List<Course>();
        }

        // 1)Updating teacher information [TASK-3]
        public void UpdateTeacherInfo(string firstName, string lastName, string email)
        {
            //Validation of teacher details
            if (string.IsNullOrWhiteSpace(firstName))
                throw new InvalidTeacherDataException("First name cannot be empty");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new InvalidTeacherDataException("Invalid email format");

            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        // 2)Display teacher details [TASK-3]
        public void DisplayTeacherInfo()
        {
            Console.WriteLine($"Teacher ID: {TeacherID}, Name: {FirstName} {LastName}, Email: {Email}");
        }

        // 3)Retrieve assigned courses [TASK-3 + TASK-5]
        public List<Course> GetAssignedCourses()
        {
            return AssignedCourses;
        }

        //Assigning course to teacher [TASK-6 Helper]
        public void AssignCourse(Course course)
        {
            if (course != null)
            {
                AssignedCourses.Add(course);
            }
        }
    }
}
