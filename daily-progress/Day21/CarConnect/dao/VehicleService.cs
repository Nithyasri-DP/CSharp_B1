using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarConnect.entity;
using CarConnect.util;
using CarConnect.exception;

namespace CarConnect.dao
{
    public class VehicleService : IVehicleService
    {
        public Vehicle GetVehicleById(int vehicleId)
        {
            Vehicle vehicle = null;

            try
            {
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = "SELECT * FROM Vehicle WHERE VehicleID = @VehicleID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        vehicle = new Vehicle
                        {
                            VehicleID = (int)reader["VehicleID"],
                            Model = reader["Model"].ToString(),
                            Make = reader["Make"].ToString(),
                            VehicleYear = (int)reader["VehicleYear"],
                            Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : null,
                            RegistrationNumber = reader["RegistrationNumber"].ToString(),
                            VehicleAvailability = (bool)reader["VehicleAvailability"],
                            DailyRate = (decimal)reader["DailyRate"]
                        };
                    }
                    else
                    {
                        throw new VehicleException("Vehicle not found. ");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new VehicleException("Database error while fetching vehicle by ID. " + ex.Message);
            }

            return vehicle;
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            try
            {
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = "SELECT * FROM Vehicle WHERE VehicleAvailability = 1";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle
                        {
                            VehicleID = (int)reader["VehicleID"],
                            Model = reader["Model"].ToString(),
                            Make = reader["Make"].ToString(),
                            VehicleYear = (int)reader["VehicleYear"],
                            Color = reader["Color"] != DBNull.Value ? reader["Color"].ToString() : null,
                            RegistrationNumber = reader["RegistrationNumber"].ToString(),
                            VehicleAvailability = (bool)reader["VehicleAvailability"],
                            DailyRate = (decimal)reader["DailyRate"]
                        };
                        vehicles.Add(vehicle);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new VehicleException("Database error while fetching available vehicles. " + ex.Message);
            }

            return vehicles;
        }

        public void AddVehicle(Vehicle vehicleData)
        {
            try
            {
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = @"INSERT INTO Vehicle (Model, Make, VehicleYear, Color, RegistrationNumber, VehicleAvailability, DailyRate) VALUES (@Model, @Make, @VehicleYear, @Color, @RegistrationNumber, @VehicleAvailability, @DailyRate)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Model", vehicleData.Model);
                    cmd.Parameters.AddWithValue("@Make", vehicleData.Make);
                    cmd.Parameters.AddWithValue("@VehicleYear", vehicleData.VehicleYear);
                    cmd.Parameters.AddWithValue("@Color", (object?)vehicleData.Color ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", vehicleData.RegistrationNumber);
                    cmd.Parameters.AddWithValue("@VehicleAvailability", vehicleData.VehicleAvailability);
                    cmd.Parameters.AddWithValue("@DailyRate", vehicleData.DailyRate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new VehicleException("Failed to add vehicle");
                }
            }
            catch (SqlException ex)
            {
                throw new VehicleException("Database error while adding vehicle." + ex.Message);
            }
        }

        public void UpdateVehicle(Vehicle vehicleData)
        {
            try
            {
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = @"UPDATE Vehicle SET 
                                        Model = @Model, 
                                        Make = @Make,
                                        VehicleYear = @VehicleYear,
                                        Color = @Color,
                                        RegistrationNumber = @RegistrationNumber,
                                        VehicleAvailability = @VehicleAvailability,
                                        DailyRate = @DailyRate
                                     WHERE VehicleID = @VehicleID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Model", vehicleData.Model);
                    cmd.Parameters.AddWithValue("@Make", vehicleData.Make);
                    cmd.Parameters.AddWithValue("@VehicleYear", vehicleData.VehicleYear);
                    cmd.Parameters.AddWithValue("@Color", (object?)vehicleData.Color ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", vehicleData.RegistrationNumber);
                    cmd.Parameters.AddWithValue("@VehicleAvailability", vehicleData.VehicleAvailability);
                    cmd.Parameters.AddWithValue("@DailyRate", vehicleData.DailyRate);
                    cmd.Parameters.AddWithValue("@VehicleID", vehicleData.VehicleID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new VehicleException("Failed to update vehicle. ");
                }
            }
            catch (SqlException ex)
            {
                throw new VehicleException("Database error while updating vehicle " + ex.Message);
            }
        }

        public void RemoveVehicle(int vehicleId)
        {
            try
            {
                using (SqlConnection conn = DbUtil.GetConnection())
                {
                    string query = "DELETE FROM Vehicle WHERE VehicleID = @VehicleID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new VehicleException("Vehicle not found or could not be removed.");
                }
            }
            catch (SqlException ex)
            {
                throw new VehicleException("Database error while removing vehicle. " + ex.Message);
            }
        }

        //Getting vehicle report in admin menu
        public void ShowVehicleUtilizationReport()
        {
            using (SqlConnection con = DbUtil.GetConnection())
            {
                string query = @"SELECT VehicleID, SUM(DATEDIFF(DAY, StartDate, EndDate)) AS DaysUsed
                         FROM Reservation
                         GROUP BY VehicleID";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n--- Vehicle Utilization Report ---");
                if (!reader.HasRows)
                {
                    Console.WriteLine("No utilization data found.");
                    return;
                }

                while (reader.Read())
                {
                    int vehicleId = (int)reader["VehicleID"];
                    int daysUsed = reader["DaysUsed"] != DBNull.Value ? (int)reader["DaysUsed"] : 0;

                    Console.WriteLine($"Vehicle ID: {vehicleId}, Days Reserved: {daysUsed}");
                }
            }
        }

    }
}
