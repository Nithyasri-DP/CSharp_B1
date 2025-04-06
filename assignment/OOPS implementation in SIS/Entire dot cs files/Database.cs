using System;
using System.Data.SqlClient;
using System.Transactions;

namespace StudentInformationSystem
{
    //-------------------------------------------[TASK-7]
    public static class Database
    {
        private static string connectionString = "data source=RYZEN5\\SQLEXPRESS;initial catalog=SIS_DB;integrated security=true";

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection error: " + ex.Message);
                return null;
            }
        }

        //Separator between lines
        public static void PrintSeparator(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
            }
        }

        // Method to retrieve student data
        public static void GetAllStudents()
        {
            using (SqlConnection con = GetConnection())
            {
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine($"StudentID: {dr["student_id"]}, First Name: {dr["first_name"]}, Last Name: {dr["last_name"]}, " +
                                          $"Date of Birth: {dr["date_of_birth"]}, Email: {dr["email"]}, Phone: {dr["phone_number"]}");
                        PrintSeparator(1);
                    }
                }
            }
        }

        // Method to retrieve course data
        public static void GetAllCourses()
        {
            using (SqlConnection con = GetConnection())
            {
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Courses", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine($"Course ID: {dr["course_id"]}, Course Name: {dr["course_name"]}, Credits: {dr["credits"]}, " +
                                          $"Teacher ID: {dr["teacher_id"]}");
                        PrintSeparator(1);
                    }
                }
            }
        }

        // Method to retrieve enrollment data
        public static void GetAllEnrollments()
        {
            using (SqlConnection con = GetConnection())
            {
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Enrollments", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine($"Enrollment ID: {dr["enrollment_id"]}, Student ID: {dr["student_id"]}, " +
                                          $"Course ID: {dr["course_id"]}, Enrollment Date: {dr["enrollment_date"]}");
                        PrintSeparator(1);
                    }
                }
            }
        }

        // Method to retrieve teachers data
        public static void GetAllTeachers()
        {
            using (SqlConnection con = GetConnection())
            {
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Teacher", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine($"TeacherID: {dr["teacher_id"]}, First Name: {dr["first_name"]}, Last Name: {dr["last_name"]}, " +
                                          $"Email: {dr["email"]}");
                        PrintSeparator(1);
                    }
                }
            }
        }

        // Method to retrieve payments data
        public static void GetAllPayments()
        {
            using (SqlConnection con = GetConnection())
            {
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Payments", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine($"PaymentID: {dr["payment_id"]}, StudentID: {dr["student_id"]}, " +
                                          $"Amount: {dr["amount"]}, Payment Date: {dr["payment_date"]}");
                        PrintSeparator(1);
                    }
                }
            }
        }

        //Data insertion for Students table
        public static void InsertStudent(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            // Validation Check
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("All fields are required");
                return;
            }
            using (SqlConnection con = GetConnection())
            {
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Students (student_id, first_name, last_name, date_of_birth, email, phone_number) " +
                                                   "VALUES (@studentId, @firstName, @lastName, @dateOfBirth, @email, @phoneNumber)", con);

                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Student data inserted successfully");
                        }
                        else
                        {
                            Console.WriteLine("Error in inserting student");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        //Data insertion for Enrollment table
        public static void InsertEnrollment(int enrollmentId, int studentId, int courseId, DateTime enrollmentDate)
        {
            using (SqlConnection con = GetConnection())
            {
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) " +
                                                   "VALUES (@enrollmentId, @studentId, @courseId, @enrollmentDate)", con);

                    cmd.Parameters.AddWithValue("@enrollmentId", enrollmentId);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    cmd.Parameters.AddWithValue("@enrollmentDate", enrollmentDate);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Enrollment inserted successfully");
                        }
                        else
                        {
                            Console.WriteLine("Failed to insert enrollment");
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine($"SQL Error: {sqlEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        //Data insertion for Payments table
        public static void InsertPayment(int paymentId, int studentId, decimal amount, DateTime paymentDate)
        {
            //Validation check
            if (amount <= 0)
            {
                Console.WriteLine("Payment amount must be positive.");
                return;
            }
            using (SqlConnection con = GetConnection())
            {
                if (con != null)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Payments (payment_id, student_id, amount, payment_date) " +
                                                   "VALUES (@paymentId, @studentId, @amount, @paymentDate)", con);

                    cmd.Parameters.AddWithValue("@paymentId", paymentId);
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@paymentDate", paymentDate);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Payment inserted successfully");
                        }
                        else
                        {
                            Console.WriteLine("Failed to insert payment");
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine($"SQL Error: {sqlEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        // Method to update student information
        public static void UpdateStudent(int studentId, string firstName, string lastName, string email, string phoneNumber)
        {
            //Validation Check
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("All fields are required. Update aborted.");
                return;
            }
            using (SqlConnection con = GetConnection())
            {
                if (con != null)
                {
                    try
                    {
                        string updateQuery = "UPDATE Students SET first_name = @firstName, last_name = @lastName, email = @email, phone_number = @phoneNumber WHERE student_id = @studentId";

                        SqlCommand cmd = new SqlCommand(updateQuery, con);
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@studentId", studentId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Student information updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No student found with the given ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error during update: " + ex.Message);
                    }
                }
            }
        }

        //Enroll a Student + Record Payment (Transactional)
        public static void EnrollStudentWithPayment(int studentId, int courseId, DateTime enrollmentDate, decimal amount, DateTime paymentDate)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 1. Insert into Enrollments

                    int newEnrollmentId = 12; // must be unique cuz i didnt used identity(1,1) in enrollments table
                    SqlCommand enrollCmd = new SqlCommand(
                        "INSERT INTO Enrollments (enrollment_id,student_id, course_id, enrollment_date) VALUES (@enrollmentId, @studentId, @courseId, @enrollDate)", con, transaction);
                    enrollCmd.Parameters.AddWithValue("@enrollmentId", newEnrollmentId);
                    enrollCmd.Parameters.AddWithValue("@studentId", studentId);
                    enrollCmd.Parameters.AddWithValue("@courseId", courseId);
                    enrollCmd.Parameters.AddWithValue("@enrollDate", enrollmentDate);
                    enrollCmd.ExecuteNonQuery();

                    // 2. Insert into Payments

                    int newPaymentId = 14; // must be unique cuz i didnt used identity(1,1) in enrollments table
                    SqlCommand paymentCmd = new SqlCommand("INSERT INTO Payments (payment_id, student_id, amount, payment_date) VALUES (@paymentId, @studentId, @amount, @payDate)", con, transaction);
                    paymentCmd.Parameters.AddWithValue("@paymentId", newPaymentId);
                    paymentCmd.Parameters.AddWithValue("@studentId", studentId);
                    paymentCmd.Parameters.AddWithValue("@amount", amount);
                    paymentCmd.Parameters.AddWithValue("@payDate", paymentDate);
                    paymentCmd.ExecuteNonQuery();

                    // 3. Commit if both succeed
                    transaction.Commit();
                    Console.WriteLine("Enrollment and payment completed successfully");
                }
                catch (Exception ex)
                {
                    // Rollback if any fails
                    transaction.Rollback();
                    Console.WriteLine("Transaction failed, Rolled back.");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        //Assign a teacher(transactional)
        public static void AssignTeacherToCourseTransactional(int teacherId, int courseId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    SqlCommand assignCmd = new SqlCommand(
                        "UPDATE Courses SET teacher_id = @teacherId WHERE course_id = @courseId", con, transaction);
                    assignCmd.Parameters.AddWithValue("@teacherId", teacherId);
                    assignCmd.Parameters.AddWithValue("@courseId", courseId);

                    int rows = assignCmd.ExecuteNonQuery();

                    if (rows == 0)
                        throw new Exception("Course not found or update failed");

                    transaction.Commit();
                    Console.WriteLine("Teacher assigned to course successfully");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction failed, Rolled back.");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        //Viewing assigned teacher
        public static void ShowCoursesByTeacher(int teacherId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Courses WHERE teacher_id = @teacherId", con);
                cmd.Parameters.AddWithValue("@teacherId", teacherId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Course: {reader["course_name"]}, Assigned Teacher ID: {reader["teacher_id"]}");
                }
            }
        }

        //Recording payments independently(transactional)
        public static void RecordPaymentTransactional(int studentId, decimal amount, DateTime paymentDate)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    int newPaymentId = 15; // must be unique cuz i didnt used identity(1,1) in enrollments table

                    SqlCommand paymentCmd = new SqlCommand(
                        "INSERT INTO Payments (payment_id, student_id, amount, payment_date) VALUES (@paymentId, @studentId, @amount, @paymentDate)",con, transaction);
                    paymentCmd.Parameters.AddWithValue("@paymentId", newPaymentId);
                    paymentCmd.Parameters.AddWithValue("@studentId", studentId);
                    paymentCmd.Parameters.AddWithValue("@amount", amount);
                    paymentCmd.Parameters.AddWithValue("@paymentDate", paymentDate);

                    paymentCmd.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Payment recorded successfully");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction failed, Rolled back.");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        //Dynamic Query
        public static void DynamicQueryBuilder(string tableName, List<string> columns, Dictionary<string, string> conditions, string orderByColumn, bool ascending)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                try
                {
                    // 1. SELECT clause
                    string selectedColumns = columns.Count > 0 ? string.Join(", ", columns) : "*";

                    // 2. Building query
                    string query = $"SELECT {selectedColumns} FROM {tableName}";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    // 3. Add multiple WHERE conditions with parameter names
                    if (conditions.Count > 0)
                    {
                        List<string> whereClauses = new List<string>();
                        int paramIndex = 0;

                        foreach (var condition in conditions)
                        {
                            string paramName = $"@param{paramIndex}";
                            whereClauses.Add($"{condition.Key} = {paramName}");
                            cmd.Parameters.AddWithValue(paramName, condition.Value);
                            paramIndex++;
                        }

                        query += " WHERE " + string.Join(" AND ", whereClauses);
                    }

                    // 4. Add ORDER BY if given
                    if (!string.IsNullOrEmpty(orderByColumn))
                    {
                        query += $" ORDER BY {orderByColumn} {(ascending ? "ASC" : "DESC")}";
                    }

                    // 5. Code execution
                    cmd.CommandText = query;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetName(i)}: {reader[i]}  ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in dynamic query execution: " + ex.Message);
                }
            }
        }

        //----------------------------------------------------------------------[TASK-8]
        //Enroling a student with the given details
        public static void EnrollJohnDoe()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    int studentId;

                    // 1. Check if student already exists (as we have created John Doe in SQL creation task itself)
                    string checkStudentQuery = "SELECT student_id FROM Students WHERE first_name = @FirstName AND last_name = @LastName AND email = @Email";
                    using (SqlCommand checkCmd = new SqlCommand(checkStudentQuery, connection, transaction))
                    {
                        checkCmd.Parameters.AddWithValue("@FirstName", "John");
                        checkCmd.Parameters.AddWithValue("@LastName", "Doe");
                        checkCmd.Parameters.AddWithValue("@Email", "john.doe@example.com");

                        object result = checkCmd.ExecuteScalar();

                        if (result != null)
                        {
                            studentId = Convert.ToInt32(result);
                        }
                        else
                        {
                            // 2. Insert student if not found(in our code, the student exists already)
                            // Get next student_id manually as we are not using IDENTITY(1,1) in sql server
                            string getMaxStudentId = "SELECT ISNULL(MAX(student_id), 0) FROM Students";
                            int newStudentId;

                            using (SqlCommand maxCmd = new SqlCommand(getMaxStudentId, connection, transaction))
                            {
                                newStudentId = (int)maxCmd.ExecuteScalar() + 1;
                            }
                            string insertStudent = @"INSERT INTO Students (first_name, last_name, date_of_birth, email, phone_number)VALUES (@FirstName, @LastName, @DOB, @Email, @Phone);";

                            using (SqlCommand insertCmd = new SqlCommand(insertStudent, connection, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@FirstName", "John");
                                insertCmd.Parameters.AddWithValue("@LastName", "Doe");
                                insertCmd.Parameters.AddWithValue("@DOB", DateTime.Parse("1995-08-15"));
                                insertCmd.Parameters.AddWithValue("@Email", "john.doe@example.com");
                                insertCmd.Parameters.AddWithValue("@Phone", "123-456-7890");

                                insertCmd.ExecuteNonQuery(); 
                            }
                            studentId = newStudentId; // Using manually generated ID
                        }
                    }

                    // 3. Insert two fixed courses
                    List<string> courses = new List<string> { "Introduction to Programming", "Mathematics 101" };
                    List<int> courseIds = new List<int>();

                    foreach (string course in courses)
                    {
                        // Get next course_id manually as we are not using IDENTITY(1,1) in sql server
                        string getMaxCourseId = "SELECT ISNULL(MAX(course_id), 0) FROM Courses";
                        int newCourseId;

                        using (SqlCommand getMaxCmd = new SqlCommand(getMaxCourseId, connection, transaction))
                        {
                            newCourseId = (int)getMaxCmd.ExecuteScalar() + 1;
                        }

                        //adding the required courses 
                        string insertCourse = "INSERT INTO Courses (course_id, course_name, credits, teacher_id) VALUES (@CourseID, @CourseName, @Credits, NULL)";
                        using (SqlCommand courseCmd = new SqlCommand(insertCourse, connection, transaction))
                        {
                            courseCmd.Parameters.AddWithValue("@CourseID", newCourseId);
                            courseCmd.Parameters.AddWithValue("@CourseName", course);
                            courseCmd.Parameters.AddWithValue("@Credits", 3);

                            courseCmd.ExecuteNonQuery();
                            courseIds.Add(newCourseId);
                        }
                    }

                    // 4. Enroll John into newly added courses
                    foreach (int courseId in courseIds)
                    {
                        // Get next enrollment_id manually
                        string getMaxEnrollId = "SELECT ISNULL(MAX(enrollment_id), 0) FROM Enrollments";
                        int newEnrollmentId;
                        using (SqlCommand maxEnrollCmd = new SqlCommand(getMaxEnrollId, connection, transaction))
                        {
                            newEnrollmentId = (int)maxEnrollCmd.ExecuteScalar() + 1;
                        }
                        //enrolling values
                        string enrollQuery = "INSERT INTO Enrollments (enrollment_id, student_id, course_id, enrollment_date) " +
                                             "VALUES (@EnrollmentID, @StudentID, @CourseID, @Date)";

                        using (SqlCommand enrollCmd = new SqlCommand(enrollQuery, connection, transaction))
                        {
                            enrollCmd.Parameters.AddWithValue("@EnrollmentID", newEnrollmentId);
                            enrollCmd.Parameters.AddWithValue("@StudentID", studentId);
                            enrollCmd.Parameters.AddWithValue("@CourseID", courseId);
                            enrollCmd.Parameters.AddWithValue("@Date", DateTime.Now);

                            enrollCmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    Console.WriteLine("John Doe enrolled into both courses successfully");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error during enrollment: " + ex.Message);
                }
            }
        }

        //Getting output for task-8
        public static void ShowJohnDoeEnrollments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT S.first_name, S.last_name, C.course_name, E.enrollment_date
                FROM Enrollments E
                JOIN Students S ON E.student_id = S.student_id
                JOIN Courses C ON E.course_id = C.course_id
                WHERE S.first_name = 'John' AND S.last_name = 'Doe'";

                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("John Doe's Enrollments:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["first_name"]} {reader["last_name"]} - {reader["course_name"]} on {reader["enrollment_date"]}");
                    }
                }
            }
        }
    }
}



