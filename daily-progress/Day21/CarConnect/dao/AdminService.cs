using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarConnect.entity;
using CarConnect.util;
using CarConnect.exception;

namespace CarConnect.dao
{
    public class AdminService : IAdminService
    {
        public void RegisterAdmin(Admin adminData)
        {
            try
            {
                SqlConnection con = DbUtil.GetConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO AdminTb (FirstName, LastName, Email, PhoneNumber, Username, AdminPassword, AdminRole) " + "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Username, @AdminPassword, @AdminRole)", con);
                cmd.Parameters.AddWithValue("@FirstName", adminData.FirstName);
                cmd.Parameters.AddWithValue("@LastName", adminData.LastName);
                cmd.Parameters.AddWithValue("@Email", adminData.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", adminData.PhoneNumber);
                cmd.Parameters.AddWithValue("@Username", adminData.Username);
                cmd.Parameters.AddWithValue("@AdminPassword", adminData.AdminPassword);
                cmd.Parameters.AddWithValue("@AdminRole", adminData.AdminRole);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        public Admin GetAdminById(int adminId)
        {
            try
            {
                SqlConnection con = DbUtil.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AdminTb WHERE AdminID = @AdminID", con);
                cmd.Parameters.AddWithValue("@AdminID", adminId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return MapAdmin(reader);
                }
                throw new AdminNotFoundException("Admin with given ID not found.");
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        public Admin GetAdminByUsername(string username)
        {
            try
            {
                SqlConnection con = DbUtil.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AdminTb WHERE Username = @Username", con);
                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return MapAdmin(reader);
                }
                throw new AuthenticationException("Admin username not found.");
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        public void UpdateAdmin(Admin adminData)
        {
            try
            {
                SqlConnection con = DbUtil.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE AdminTb SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " + "PhoneNumber = @PhoneNumber, Username = @Username, AdminPassword = @AdminPassword, " + "AdminRole = @AdminRole WHERE AdminID = @AdminID", con);
                cmd.Parameters.AddWithValue("@FirstName", adminData.FirstName);
                cmd.Parameters.AddWithValue("@LastName", adminData.LastName);
                cmd.Parameters.AddWithValue("@Email", adminData.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", adminData.PhoneNumber);
                cmd.Parameters.AddWithValue("@Username", adminData.Username);
                cmd.Parameters.AddWithValue("@AdminPassword", adminData.AdminPassword);
                cmd.Parameters.AddWithValue("@AdminRole", adminData.AdminRole);
                cmd.Parameters.AddWithValue("@AdminID", adminData.AdminID);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        public void DeleteAdmin(int adminId)
        {
            try
            {
                SqlConnection con = DbUtil.GetConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM AdminTb WHERE AdminID = @AdminID", con);
                cmd.Parameters.AddWithValue("@AdminID", adminId);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        private Admin MapAdmin(SqlDataReader reader)
        {
            return new Admin
            {
                AdminID = Convert.ToInt32(reader["AdminID"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                Username = reader["Username"].ToString(),
                AdminPassword = reader["AdminPassword"].ToString(),
                AdminRole = reader["AdminRole"].ToString(),
                JoinDate = Convert.ToDateTime(reader["JoinDate"])
            };
        }

        public List<Admin> GetAllAdmins()
        {
            List<Admin> admins = new List<Admin>();
            try
            {
                SqlConnection con = DbUtil.GetConnection();
                string query = "SELECT * FROM AdminTb";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Admin admin = new Admin
                    {
                        AdminID = Convert.ToInt32(reader["AdminID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Username = reader["Username"].ToString(),
                        AdminPassword = reader["AdminPassword"].ToString(),
                        AdminRole = reader["AdminRole"].ToString(),
                        JoinDate = Convert.ToDateTime(reader["JoinDate"])
                    };
                    admins.Add(admin);
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
            return admins;
        }
    }
}
