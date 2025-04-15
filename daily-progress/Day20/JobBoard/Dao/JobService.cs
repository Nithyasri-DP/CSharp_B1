using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Entity;
using JobBoard.Utility;
using System.Data.SqlClient;

namespace JobBoard.Dao
{
    public class JobService : IJobListingService
    {
        public void PostJob(JobListing job)
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "INSERT INTO Jobs (JobID, CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " + "VALUES (@id, @companyId, @title, @desc, @location, @salary, @type, @date)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", job.JobID);
                        cmd.Parameters.AddWithValue("@companyId", job.CompanyID);
                        cmd.Parameters.AddWithValue("@title", job.JobTitle);
                        cmd.Parameters.AddWithValue("@desc", job.JobDescription);
                        cmd.Parameters.AddWithValue("@location", job.JobLocation);
                        cmd.Parameters.AddWithValue("@salary", job.Salary);
                        cmd.Parameters.AddWithValue("@type", job.JobType);
                        cmd.Parameters.AddWithValue("@date", job.PostedDate);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Job posted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while posting job: " + ex.Message);
            }
        }

        public List<JobListing> GetAllJobs()
        {
            List<JobListing> jobs = new List<JobListing>();
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Jobs";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving jobs: " + ex.Message);
            }
            return jobs;
        }

        public List<JobListing> GetJobsByCompany(int companyId)
        {
            List<JobListing> jobs = new List<JobListing>();
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Jobs WHERE CompanyID = @companyId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@companyId", companyId);
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving company jobs: " + ex.Message);
            }
            return jobs;
        }

        public JobListing GetJobById(int jobId)
        {
            JobListing job = null;
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Jobs WHERE JobID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", jobId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                job = new JobListing(
                                    reader.GetInt32(0),
                                    reader.GetInt32(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetDecimal(5),
                                    reader.GetString(6),
                                    reader.GetDateTime(7)
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving job by ID: " + ex.Message);
            }
            return job;
        }
    }
}
