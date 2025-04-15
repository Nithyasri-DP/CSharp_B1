using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarConnect.entity;
using CarConnect.exception;
using CarConnect.util;

namespace CarConnect.dao
{
    public class ReservationService : IReservationService
    {
        public Reservation GetReservationById(int reservationId)
        {
            try
            {
                Reservation res = null;
                SqlConnection con = DbUtil.GetConnection();
                string query = "SELECT * FROM Reservation WHERE ReservationID = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", reservationId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    res = new Reservation
                    {
                        ReservationID = (int)reader["ReservationID"],
                        CustomerID = (int)reader["CustomerID"],
                        VehicleID = (int)reader["VehicleID"],
                        StartDate = (DateTime)reader["StartDate"],
                        EndDate = (DateTime)reader["EndDate"],
                        TotalCost = (decimal)reader["TotalCost"],
                        Status = reader["rStatus"].ToString()
                    };
                }
                reader.Close();
                if (res == null)
                {
                    throw new ReservationException("Reservation not found.");
                }
                return res;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        public List<Reservation> GetReservationsByCustomerId(int customerId)
        {
            try
            {
                List<Reservation> list = new List<Reservation>();
                SqlConnection con = DbUtil.GetConnection();
                string query = "SELECT * FROM Reservation WHERE CustomerID = @cid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cid", customerId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservation res = new Reservation
                    {
                        ReservationID = (int)reader["ReservationID"],
                        CustomerID = (int)reader["CustomerID"],
                        VehicleID = (int)reader["VehicleID"],
                        StartDate = (DateTime)reader["StartDate"],
                        EndDate = (DateTime)reader["EndDate"],
                        TotalCost = (decimal)reader["TotalCost"],
                        Status = reader["rStatus"].ToString()
                    };
                    list.Add(res);
                }
                reader.Close();
                return list;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        public void CreateReservation(Reservation reservationData)
        {
            try
            {
                SqlConnection con = DbUtil.GetConnection();

                // Check for conflicting reservations
                string checkQuery = @"SELECT COUNT(*) FROM Reservation 
                              WHERE VehicleID = @VehicleID 
                              AND ((StartDate <= @EndDate AND EndDate >= @StartDate))";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@VehicleID", reservationData.VehicleID);
                checkCmd.Parameters.AddWithValue("@StartDate", reservationData.StartDate);
                checkCmd.Parameters.AddWithValue("@EndDate", reservationData.EndDate);

                int conflictCount = (int)checkCmd.ExecuteScalar();
                if (conflictCount > 0)
                {
                    throw new ReservationException("This vehicle is already reserved during the selected dates.");
                }

                // Proceed with reservation if no conflict
                string query = @"INSERT INTO Reservation (CustomerID, VehicleID, StartDate, EndDate, TotalCost, rStatus)
                         VALUES (@CustomerID, @VehicleID, @StartDate, @EndDate, @TotalCost, @rStatus)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", reservationData.CustomerID);
                cmd.Parameters.AddWithValue("@VehicleID", reservationData.VehicleID);
                cmd.Parameters.AddWithValue("@StartDate", reservationData.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", reservationData.EndDate);
                cmd.Parameters.AddWithValue("@TotalCost", reservationData.TotalCost);
                cmd.Parameters.AddWithValue("@rStatus", reservationData.Status);

                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ReservationException("Failed to create reservation.");
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        public void UpdateReservation(Reservation reservationData)
        {
            try
            {
                SqlConnection con = DbUtil.GetConnection();
                string query = @"UPDATE Reservation 
                                 SET CustomerID = @CustomerID, VehicleID = @VehicleID, 
                                     StartDate = @StartDate, EndDate = @EndDate, 
                                     TotalCost = @TotalCost, rStatus = @rStatus 
                                 WHERE ReservationID = @ReservationID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", reservationData.CustomerID);
                cmd.Parameters.AddWithValue("@VehicleID", reservationData.VehicleID);
                cmd.Parameters.AddWithValue("@StartDate", reservationData.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", reservationData.EndDate);
                cmd.Parameters.AddWithValue("@TotalCost", reservationData.TotalCost);
                cmd.Parameters.AddWithValue("@rStatus", reservationData.Status);
                cmd.Parameters.AddWithValue("@ReservationID", reservationData.ReservationID);

                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ReservationException("Reservation update failed.");
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        public void CancelReservation(int reservationId)
        {
            try
            {
                SqlConnection con = DbUtil.GetConnection();
                string query = "DELETE FROM Reservation WHERE ReservationID = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", reservationId);

                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    throw new ReservationException("Reservation cancellation failed.");
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
        }

        // Added to view in admin menu
        public List<Reservation> GetAllReservations()
        {
            List<Reservation> list = new List<Reservation>();
            try
            {
                using (SqlConnection con = DbUtil.GetConnection())
                {
                    string query = "SELECT * FROM Reservation";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Reservation res = new Reservation
                        {
                            ReservationID = (int)reader["ReservationID"],
                            CustomerID = (int)reader["CustomerID"],
                            VehicleID = (int)reader["VehicleID"],
                            StartDate = (DateTime)reader["StartDate"],
                            EndDate = (DateTime)reader["EndDate"],
                            TotalCost = (decimal)reader["TotalCost"],
                            Status = reader["rStatus"].ToString()
                        };
                        list.Add(res);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database. " + ex.Message);
            }
            return list;
        }

        //Revenue for admin menu
        public decimal CalculateTotalRevenue()
        {
            decimal totalRevenue = 0;

            try
            {
                using (SqlConnection con = DbUtil.GetConnection())
                {
                    string query = "SELECT SUM(TotalCost) FROM Reservation WHERE rStatus IN ('Confirmed', 'Completed')";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            totalRevenue = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to calculate total revenue. " + ex.Message);
            }

            return totalRevenue;
        }

    }
}
