using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

public class JobListing
{
    public int JobID { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string JobLocation { get; set; } = string.Empty;
    public string JobType { get; set; } = string.Empty;
    public decimal Salary { get; set; }
}

public static class Careerhub_Exceptions
{
    private static string connectionString = "data source = RYZEN5\\SQLEXPRESS;initial catalog = CareerHub; integrated security = true";

    // Invalid Email Format Handling
    public static void ValidateEmail(string email)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                throw new FormatException("Invalid email format.");
            Console.WriteLine("Email is valid.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Salary Calculation Handling
    public static void CalculateAverageSalary(List<JobListing> jobListings)
    {
        try
        {
            if (jobListings.Any(job => job.Salary < 0))
                throw new ArgumentException("One or more job listings have invalid salary values.");

            decimal avgSalary = jobListings.Average(job => job.Salary);
            Console.WriteLine($"Average Salary: {avgSalary}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // File Upload Exception Handling
    public static void UploadResume(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Resume file not found.");

            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Length > 2 * 1024 * 1024) // 2 MB size limit
                throw new InvalidOperationException("File size exceeded the limit.");

            if (fileInfo.Extension != ".pdf" && fileInfo.Extension != ".docx")
                throw new NotSupportedException("Unsupported file format. Only PDF or DOCX allowed.");

            Console.WriteLine("Resume uploaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Application Deadline Handling
    public static void SubmitApplication(DateTime applicationDate, DateTime deadline)
    {
        try
        {
            if (applicationDate > deadline)
                throw new InvalidOperationException("Application deadline has passed. Submission rejected.");

            Console.WriteLine("Application submitted successfully.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Database Connection Handling
    public static void TestDatabaseConnection()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Jobs";
                SqlCommand cmd = new SqlCommand(query, conn);
                int count = (int)cmd.ExecuteScalar();
                Console.WriteLine($"Total jobs in database: {count}");
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"Database error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
