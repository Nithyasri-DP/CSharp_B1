using System;
using System.Collections.Generic;

namespace StudentInformationSystem
{
    // Creating Enrollment class [TASK-1]
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public Student Student { get; set; }   // Linking to Student object, Already implemented in Task one [TASK-5]
        public Course Course { get; set; }   // Linking to Course object, Already implemented in Task one [TASK-5]
        public DateTime EnrollmentDate { get; set; }

        // Constructor implementation [TASK-2]
        public Enrollment(int enrollmentId, Student student, Course course, DateTime enrollmentDate)
        {
            //Checks if the student or course is null(excep)
            if (student == null)
                throw new InvalidEnrollmentDataException("Student reference is missing");
            if (course == null)
                throw new InvalidEnrollmentDataException("Course reference is missing");

            this.EnrollmentID = enrollmentId;
            this.Student = student;
            this.Course = course;
            this.EnrollmentDate = enrollmentDate;
        }

        // 1)Retrieves student associated with the enrollment [TASK-3]
        public Student GetStudent()
        {
            return Student;
        }

        // 2)Retrieves courses associated with the enrollment [TASK-3]
        public Course GetCourse()
        {
            return Course;
        }
    }
}
