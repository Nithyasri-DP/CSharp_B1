using System;
using System.Data.SqlClient;
using CarConnect.entity;
using CarConnect.util;
using CarConnect.exception;

namespace CarConnect.dao
{
    public class CustomerService : ICustomerService
    {
        public Customer GetCustomerById(int customerId)
        {
            try
            {
                Customer customer = null;
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        customer = new Customer
                        {
                            CustomerID = (int)reader["CustomerID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            cAddress = reader["cAddress"].ToString(),
                            Username = reader["Username"].ToString(),
                            cPassword = reader["cPassword"].ToString(),
                            RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                        };
                    }
                }
                return customer;
            }
            catch (SqlException)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.");
            }
        }

        public Customer GetCustomerByUsername(string username)
        {
            try
            {
                Customer customer = null;
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = "SELECT * FROM Customer WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        customer = new Customer
                        {
                            CustomerID = (int)reader["CustomerID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            cAddress = reader["cAddress"].ToString(),
                            Username = reader["Username"].ToString(),
                            cPassword = reader["cPassword"].ToString(),
                            RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                        };
                    }
                }
                //excep
                if (customer == null)
                {
                    throw new AuthenticationException("Customer username not found.");
                }
                return customer;
            }
            catch (SqlException)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.");
            }
        }

        public void RegisterCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    if (string.IsNullOrWhiteSpace(customer.FirstName) ||
               string.IsNullOrWhiteSpace(customer.Email) ||
               string.IsNullOrWhiteSpace(customer.Username) ||
               string.IsNullOrWhiteSpace(customer.cPassword))
                    {
                        throw new InvalidInputException("Missing required customer information.");
                    }
                    string query = @"INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber, cAddress, Username, cPassword) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @cAddress, @Username, @cPassword)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@cAddress", customer.cAddress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Username", customer.Username);
                    cmd.Parameters.AddWithValue("@cPassword", customer.cPassword);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new CustomerException("Customer registration failed.");
                    }
                }
            }
            catch (SqlException)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.");
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = @"UPDATE Customer 
                                     SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, cAddress = @cAddress, Username = @Username, cPassword = @cPassword WHERE CustomerID = @CustomerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customer.LastName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", customer.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@cAddress", customer.cAddress ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Username", customer.Username);
                    cmd.Parameters.AddWithValue("@cPassword", customer.cPassword);
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new CustomerException("Customer update failed.");
                    }
                }
            }
            catch (SqlException)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.");
            }
        }

        public void DeleteCustomer(int customerId)
        {
            try
            {
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        throw new CustomerException("Customer deletion failed.");
                    }
                }
            }
            catch (SqlException)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.");
            }
        }

        // Get all customers for admin view
        public List<Customer> GetAllCustomers()
        {
            List<Customer> list = new List<Customer>();
            try
            {
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = "SELECT * FROM Customer";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer c = new Customer
                        {
                            CustomerID = (int)reader["CustomerID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            cAddress = reader["cAddress"].ToString(),
                            Username = reader["Username"].ToString(),
                            cPassword = reader["cPassword"].ToString(),
                            RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                        };
                        list.Add(c);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
            return list;
        }
    }
}
