using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace JobBoard.Utility
{
    public class DataBaseManager
    {
        // 1. Job Listing Retrieval
        public void DisplayAllJobListings()
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = @"SELECT j.JobTitle, c.CompanyName, j.Salary 
                                     FROM Jobs j
                                     INNER JOIN Companies c ON j.CompanyID = c.CompanyID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Job Title\t\tCompany\t\tSalary");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetString(0)}\t\t{reader.GetString(1)}\t\t{reader.GetDecimal(2):C}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR] Failed to retrieve jobs: {ex.Message}");
            }
        }

        // 2. Applicant Profile Creation
        public void CreateApplicantProfile()
        {
            try
            {
                Console.Write("Enter Applicant ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter First Name: ");
                string first = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string last = Console.ReadLine();

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter Phone: ");
                string phone = Console.ReadLine();

                Console.Write("Enter Resume Path: ");
                string resume = Console.ReadLine();

                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "INSERT INTO Applicants (ApplicantID, FirstName, LastName, Email, Phone, Resume) " +
                                   "VALUES (@id, @first, @last, @email, @phone, @resume)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@first", first);
                        cmd.Parameters.AddWithValue("@last", last);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@resume", resume);
                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Applicant registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR] Failed to register applicant: {ex.Message}");
            }
        }

        // 3. Job Application Submission
        public void SubmitJobApplication()
        {
            try
            {
                Console.Write("Enter Application ID: ");
                int appId = int.Parse(Console.ReadLine());

                Console.Write("Enter Job ID: ");
                int jobId = int.Parse(Console.ReadLine());

                Console.Write("Enter Applicant ID: ");
                int applicantId = int.Parse(Console.ReadLine());

                Console.Write("Enter Cover Letter: ");
                string cover = Console.ReadLine();

                DateTime applicationDate = DateTime.Now;

                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "INSERT INTO Applications (ApplicationID, JobID, ApplicantID, ApplicationDate, CoverLetter) " +
                                   "VALUES (@appId, @jobId, @applicantId, @date, @cover)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appId", appId);
                        cmd.Parameters.AddWithValue("@jobId", jobId);
                        cmd.Parameters.AddWithValue("@applicantId", applicantId);
                        cmd.Parameters.AddWithValue("@date", applicationDate);
                        cmd.Parameters.AddWithValue("@cover", cover);
                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Application submitted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR] Failed to submit application: {ex.Message}");
            }
        }

        // 4. Company Job Posting
        public void PostJob()
        {
            try
            {
                Console.Write("Enter Job ID: ");
                int jobId = int.Parse(Console.ReadLine());

                Console.Write("Enter Company ID: ");
                int companyId = int.Parse(Console.ReadLine());

                Console.Write("Enter Job Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Job Description: ");
                string description = Console.ReadLine();

                Console.Write("Enter Job Location: ");
                string location = Console.ReadLine();

                Console.Write("Enter Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Job Type: ");
                string type = Console.ReadLine();

                DateTime postedDate = DateTime.Now;

                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "INSERT INTO Jobs (JobID, CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " +
                                   "VALUES (@id, @companyId, @title, @desc, @location, @salary, @type, @date)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", jobId);
                        cmd.Parameters.AddWithValue("@companyId", companyId);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@desc", description);
                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@salary", salary);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@date", postedDate);
                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Job posted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR] Failed to post job: {ex.Message}");
            }
        }

        // 5. Salary Range Query
        public void SearchJobsBySalaryRange()
        {
            try
            {
                Console.Write("Enter minimum salary: ");
                decimal min = decimal.Parse(Console.ReadLine());

                Console.Write("Enter maximum salary: ");
                decimal max = decimal.Parse(Console.ReadLine());

                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = @"SELECT j.JobTitle, c.CompanyName, j.Salary 
                                     FROM Jobs j 
                                     INNER JOIN Companies c ON j.CompanyID = c.CompanyID 
                                     WHERE j.Salary BETWEEN @min AND @max";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@min", min);
                        cmd.Parameters.AddWithValue("@max", max);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Jobs in Salary Range:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader.GetString(0)} | {reader.GetString(1)} | {reader.GetDecimal(2):C}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DB ERROR] Salary range query failed: {ex.Message}");
            }
        }
    }
}
