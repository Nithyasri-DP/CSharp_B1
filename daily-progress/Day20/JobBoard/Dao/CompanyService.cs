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
    public class CompanyService : ICompanyService
    {
        public void RegisterCompany(Company company)
        {
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "INSERT INTO Companies (CompanyID, CompanyName, Location) " + "VALUES (@id, @name, @location)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", company.CompanyID);
                        cmd.Parameters.AddWithValue("@name", company.CompanyName);
                        cmd.Parameters.AddWithValue("@location", company.Location);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Company registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while registering company: " + ex.Message);
            }
        }

        public List<Company> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Companies";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving companies: " + ex.Message);
            }
            return companies;
        }

        public Company GetCompanyById(int companyId)
        {
            Company company = null;
            try
            {
                using (SqlConnection conn = DBConnUtil.GetConnection())
                {
                    string query = "SELECT * FROM Companies WHERE CompanyID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", companyId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                company = new Company(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2)
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving company: " + ex.Message);
            }
            return company;
        }

    }
}
