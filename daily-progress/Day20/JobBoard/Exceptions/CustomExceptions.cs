using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JobBoard.Entity;
using JobBoard.Utility;
using System.Data.SqlClient;


namespace JobBoard.Exceptions
{
    public class CustomExceptions
    {

        // 1. Invalid Email Format Handling
        public static void ValidateEmail(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new FormatException("Invalid email format.");
                }
                Console.WriteLine("Email is valid.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[Email Error] {ex.Message}");
            }
        }

        // 2. Salary Calculation Handling
        public static void CalculateAverageSalary(List<JobListing> jobListings)
        {
            try
            {
                decimal total = 0;
                int count = 0;

                foreach (var job in jobListings)
                {
                    if (job.Salary < 0)
                    {
                        throw new ArgumentException($"Invalid salary detected for job ID {job.JobID}: {job.Salary}");
                    }
                    total += job.Salary;
                    count++;
                }

                decimal average = count > 0 ? total / count : 0;
                Console.WriteLine($"Average Salary: {average:C}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[Salary Error] {ex.Message}");
            }
        }

        // 3. File Upload Exception Handling
        public static void UploadResume(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Resume file not found.");
                }

                FileInfo file = new FileInfo(filePath);
                if (file.Length > 2 * 1024 * 1024) // 2MB size limit
                {
                    throw new Exception("File size exceeds the limit of 2MB.");
                }

                if (file.Extension.ToLower() != ".pdf" && file.Extension.ToLower() != ".docx")
                {
                    throw new Exception("Unsupported file format. Only PDF and DOCX allowed.");
                }

                Console.WriteLine("Resume uploaded successfully.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"[File Error] {ex.Message}");
            }
            catch (ExceptionHandler ex)
            {
                Console.WriteLine($"[Upload Error] {ex.Message}");
            }
        }

        // 4. Application Deadline Handling
        public static void SubmitApplication(DateTime applicationDate, DateTime deadline)
        {
            try
            {
                if (applicationDate > deadline)
                {
                    throw new Exception("Application deadline has passed. Cannot submit application.");
                }

                Console.WriteLine("Application submitted successfully.");
            }
            catch (ExceptionHandler ex)
            {
                Console.WriteLine($"[Deadline Error] {ex.Message}");
            }
        }

        // 5. Database Connection Handling
        public static void FetchJobListings()
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT JobTitle FROM Jobs";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Job Titles:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"- {reader.GetString(0)}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"[Database Error] SQL Exception: {ex.Message}");
            }
            catch (ExceptionHandler ex)
            {
                Console.WriteLine($"[Database Error] General Error: {ex.Message}");
            }
        }

    }
}
