using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CareerHub
{
    public static class DatabaseManager
    {
     
        private static string connectionString = "data source = RYZEN5\\SQLEXPRESS;initial catalog = Career; integrated security = true";

       // SqlConnection connectionString = new SqlConnection("connectionString"); connectionString.ConnectionTimeout = 30; // Set timeout to 30 or more  secondsconnection.Open();
 

        public static void InitializeDatabase()
        {
            Console.WriteLine("Database already initialized. Tables exist.");
        }


        // Insert a job listing into Jobs table
        public static void InsertJobListing(JobListing job)
        {
            string query = "INSERT INTO Jobs (JobID, CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " +
                           "VALUES (@JobID, @CompanyID, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@JobID", job.JobID);
                cmd.Parameters.AddWithValue("@CompanyID", job.CompanyID);
                cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                cmd.Parameters.AddWithValue("@JobDescription", job.JobDescription);
                cmd.Parameters.AddWithValue("@JobLocation", job.JobLocation);
                cmd.Parameters.AddWithValue("@Salary", job.Salary);
                cmd.Parameters.AddWithValue("@JobType", job.JobType);
                cmd.Parameters.AddWithValue("@PostedDate", job.PostedDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Insert a company into Companies table
        public static void InsertCompany(Company company)
        {
            string query = "INSERT INTO Companies (CompanyID, CompanyName, CompanyLocation) VALUES (@CompanyID, @CompanyName, @CompanyLocation)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CompanyID", company.CompanyID);
                cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                cmd.Parameters.AddWithValue("@CompanyLocation", company.Location);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        // Insert Applicant
        public static void InsertApplicant(Applicant applicant)
        {
            string query = "INSERT INTO Applicants (ApplicantID, FirstName, LastName, Email, Phone, ApplicantResume) " +
                           "VALUES (@ApplicantID, @FirstName, @LastName, @Email, @Phone, @ApplicantResume)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ApplicantID", applicant.ApplicantID);
                cmd.Parameters.AddWithValue("@FirstName", applicant.FirstName);
                cmd.Parameters.AddWithValue("@LastName", applicant.LastName);
                cmd.Parameters.AddWithValue("@Email", applicant.Email);
                cmd.Parameters.AddWithValue("@Phone", applicant.Phone);
                cmd.Parameters.AddWithValue("@ApplicantResume", applicant.Resume);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Insert JobApplication
        public static void InsertJobApplication(JobApplication application)
        {
            string query = "INSERT INTO Applications (ApplicationID, JobID, ApplicantID, ApplicationDate, CoverLetter) " +
                           "VALUES (@ApplicationID, @JobID, @ApplicantID, @ApplicationDate, @CoverLetter)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
                cmd.Parameters.AddWithValue("@JobID", application.JobID);
                cmd.Parameters.AddWithValue("@ApplicantID", application.ApplicantID);
                cmd.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
                cmd.Parameters.AddWithValue("@CoverLetter", application.CoverLetter);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<JobListing> GetJobListings()
        {
            List<JobListing> jobs = new List<JobListing>();
            string query = "SELECT * FROM Jobs";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jobs.Add(new JobListing(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetDecimal(5),
                            reader.GetString(6),
                            reader.GetDateTime(7)
                        ));
                    }
                }
            }
            return jobs;
        }

        public static List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            string query = "SELECT * FROM Companies";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        companies.Add(new Company(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2)
                        ));
                    }
                }
            }
            return companies;
        }

        public static List<Applicant> GetApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();
            string query = "SELECT * FROM Applicants";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        applicants.Add(new Applicant(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5)
                        ));
                    }
                }
            }
            return applicants;
        }

        public static List<JobApplication> GetApplicationsForJob(int jobID)
        {
            List<JobApplication> applications = new List<JobApplication>();
            string query = "SELECT * FROM Applications WHERE JobID = @JobID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@JobID", jobID);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        applications.Add(new JobApplication(
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetInt32(2),
                            reader.GetDateTime(3),
                            reader.GetString(4)
                        ));
                    }
                }
            }
            return applications;
        }
    }
}