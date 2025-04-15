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
    public class ApplicationService : IApplicationService
    {
        public void SubmitApplication(JobApplication application)
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "INSERT INTO Applications (ApplicationID, JobID, ApplicantID, ApplicationDate, CoverLetter) " + "VALUES (@appId, @jobId, @applicantId, @date, @letter)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appId", application.ApplicationID);
                        cmd.Parameters.AddWithValue("@jobId", application.JobID);
                        cmd.Parameters.AddWithValue("@applicantId", application.ApplicantID);
                        cmd.Parameters.AddWithValue("@date", application.ApplicationDate);
                        cmd.Parameters.AddWithValue("@letter", application.CoverLetter);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Application submitted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while submitting application: " + ex.Message);
            }
        }

        public List<JobApplication> GetApplicationsByJobId(int jobId)
        {
            List<JobApplication> applications = new List<JobApplication>();
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Applications WHERE JobID = @jobId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@jobId", jobId);
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving applications: " + ex.Message);
            }
            return applications;
        }

        public List<JobApplication> GetAllApplications()
        {
            List<JobApplication> applications = new List<JobApplication>();
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Applications";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving all applications: " + ex.Message);
            }
            return applications;
        }
    }
}
