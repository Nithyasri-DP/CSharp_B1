using System;
using System.Collections.Generic;

namespace StudentInformationSystem
{
    // Creating Course class [TASK-1]
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string InstructorName { get; set; }

        // Stores the assigned teacher and list of student enrollments for this course [TASK-3]

        private Teacher? AssignedTeacher; 

        //private List<Enrollment> enrollments = new List<Enrollment>();[rewriting]

        // Stores all enrollments related to this course [TASK-5]
        public List<Enrollment> Enrollments { get; set; }

        // Constructor implementation [TASK-2]
        public Course(int courseId, string courseName, string courseCode, string instructorName)
        {
            //constructor with validation(excep)
            ValidateCourseData(courseCode, instructorName);

            this.CourseID = courseId;
            this.CourseName = courseName;
            this.CourseCode = courseCode;
            this.InstructorName = instructorName;

            // Initialize enrollments list [TASK-5] 
            Enrollments = new List<Enrollment>();
        }


        //Method to update course details(excep)
        public void UpdateCourse(string courseName, string courseCode, string instructorName)
        {
            ValidateCourseData(courseCode, instructorName);
            this.CourseName = courseName;
            this.CourseCode = courseCode;
            this.InstructorName = instructorName;
            Console.WriteLine("Course details updated successfully");
        }

        //Validation method(excep)
        private void ValidateCourseData(string courseCode, string instructorName)
        {
            if (string.IsNullOrWhiteSpace(courseCode) || courseCode.Length < 4)
            {
                throw new InvalidCourseDataException("Invalid Course Code, it must be at least 4 characters");
            }

            if (string.IsNullOrWhiteSpace(instructorName))
            {
                throw new InvalidCourseDataException("Instructor name cannot be empty");
            }
        }

        // 1)Assigning teacher to the course [TASK-3]
        public void AssignTeacher(Teacher teacher)
        {
            // Check if teacher exists(excep)
            if (teacher == null) 
                throw new TeacherNotFoundException("Teacher does not exist");

            //Check if course exists(excep)
            if (this == null)
            {
                throw new CourseNotFoundException("Course does not exist");
            }
            AssignedTeacher = teacher;
            InstructorName = $"{teacher.FirstName} {teacher.LastName}"; // Concatenating teacher name
        }

        // 2)Updating course details [TASK-3]
        public void UpdateCourseInfo(string courseCode, string courseName, string instructorName)
        {
            CourseCode = courseCode;
            CourseName = courseName;
            InstructorName = instructorName;
        }

        // 3)Displaying course details [TASK-3]
        public void DisplayCourseInfo()
        {
            Console.WriteLine($"Course: {CourseCode} - {CourseName}, Instructor: {InstructorName}");
        }

        // 4)Getting list of students enrolled in a course [TASK-3 + TASK-5]       
        public List<Enrollment> GetEnrollments()
        {
            return Enrollments;
        }
        // 5)Retrieving assigned teacher for the course [TASK-3]
        public Teacher GetTeacher()
        {
            return AssignedTeacher;
        }

        //Adding enrollment to course[TASK-6 Helper]
        public void AddEnrollment(Enrollment enrollment)
        {
            if (enrollment != null)
                Enrollments.Add(enrollment);
        }

    }
}
