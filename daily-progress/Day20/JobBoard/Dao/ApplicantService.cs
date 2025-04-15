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
    public class ApplicantService : IApplicantService
    {
        public void RegisterApplicant(Applicant applicant)
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "INSERT INTO Applicants (ApplicantID, FirstName, LastName, Email, Phone, Resume) " + "VALUES (@id, @first, @last, @mail, @phone, @resume)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", applicant.ApplicantID);
                        cmd.Parameters.AddWithValue("@first", applicant.FirstName);
                        cmd.Parameters.AddWithValue("@last", applicant.LastName);
                        cmd.Parameters.AddWithValue("@mail", applicant.Email);
                        cmd.Parameters.AddWithValue("@phone", applicant.Phone);
                        cmd.Parameters.AddWithValue("@resume", applicant.Resume);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Applicant registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while registering applicant: " + ex.Message);
            }
        }

        public Applicant GetApplicantById(int applicantId)
        {
            Applicant applicant = null;
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Applicants WHERE ApplicantID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", applicantId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                applicant = new Applicant(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetString(5)
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving applicant: " + ex.Message);
            }
            return applicant;
        }

        public List<Applicant> GetAllApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Applicants";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving applicants: " + ex.Message);
            }
            return applicants;
        }
    }
}
