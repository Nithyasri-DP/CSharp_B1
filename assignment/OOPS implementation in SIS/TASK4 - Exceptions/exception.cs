using System;

namespace StudentInformationSystem
{
    // 1)User-defined exception for duplicate enrollment
    public class DuplicateEnrollmentException : Exception
    {
        public DuplicateEnrollmentException(string message) : base(message) { }
    }

    // 2)User-defined exception for course not found
    public class CourseNotFoundException : Exception
    {
        public CourseNotFoundException(string message) : base(message) { }
    }

    // 3)User-defined exception for student not found
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message) { }
    }

    // 4)User-defined exception for teacher not found
    public class TeacherNotFoundException : Exception
    {
        public TeacherNotFoundException(string message) : base(message) { }
    }

    // 5)User-defined exception for payment validation failure
    public class PaymentValidationException : Exception
    {
        public PaymentValidationException(string message) : base(message) { }
    }

    // 6)User-defined exception for invalid student data
    public class InvalidStudentDataException : Exception
    {
        public InvalidStudentDataException(string message) : base(message) { }
    }

    // 7)User-defined exception for invalid course data
    public class InvalidCourseDataException : Exception
    {
        public InvalidCourseDataException(string message) : base(message) { }
    }

    // 8)User-defined exception for invalid enrollment data
    public class InvalidEnrollmentDataException : Exception
    {
        public InvalidEnrollmentDataException(string message) : base(message) { }
    }

    // 9)User-defined exception for invalid teacher data
    public class InvalidTeacherDataException : Exception
    {
        public InvalidTeacherDataException(string message) : base(message) { }
    }

    // 10)User-defined exception for insufficient funds
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
}
