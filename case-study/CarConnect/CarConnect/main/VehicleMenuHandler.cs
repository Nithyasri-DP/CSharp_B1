using System;
using System.Collections.Generic;
using CarConnect.dao;
using CarConnect.entity;
using CarConnect.exception;

namespace CarConnect.main
{
    public class VehicleMenuHandler
    {
        public static void HandleVehicleMenu()
        {
            VehicleService vehicleService = new VehicleService();

            while (true)
            {
                Console.WriteLine("\nVEHICLE MENU\n");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Get Vehicle by ID");
                Console.WriteLine("3. Get Available Vehicles");
                Console.WriteLine("4. Update Vehicle");
                Console.WriteLine("5. Remove Vehicle");
                Console.WriteLine("6. Back to Main Menu\n");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Vehicle newVehicle = new Vehicle();

                        Console.Write("Model: ");
                        newVehicle.Model = Console.ReadLine();

                        Console.Write("Make: ");
                        newVehicle.Make = Console.ReadLine();

                        Console.Write("Year: ");
                        newVehicle.VehicleYear = int.Parse(Console.ReadLine());

                        Console.Write("Color (optional): ");
                        string color = Console.ReadLine();
                        newVehicle.Color = string.IsNullOrWhiteSpace(color) ? null : color;

                        Console.Write("Registration Number: ");
                        newVehicle.RegistrationNumber = Console.ReadLine();

                        Console.Write("Is Available (true/false): ");
                        newVehicle.VehicleAvailability = bool.Parse(Console.ReadLine());

                        Console.Write("Daily Rate: ");
                        newVehicle.DailyRate = decimal.Parse(Console.ReadLine());

                        try
                        {
                            vehicleService.AddVehicle(newVehicle);
                            Console.WriteLine("Vehicle added successfully.");
                        }
                        catch (VehicleException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "2":
                        Console.Write("Enter Vehicle ID: ");
                        if (int.TryParse(Console.ReadLine(), out int vehicleId))
                        {
                            try
                            {
                                var vehicle = vehicleService.GetVehicleById(vehicleId);
                                DisplayVehicle(vehicle);
                            }
                            catch (VehicleException ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "3":
                        List<Vehicle> availableVehicles = vehicleService.GetAvailableVehicles();
                        if (availableVehicles.Count > 0)
                        {
                            foreach (var v in availableVehicles)
                            {
                                DisplayVehicle(v);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No available vehicles found.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Vehicle ID to Update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            try
                            {
                                var existing = vehicleService.GetVehicleById(updateId);

                                Console.Write("Model (" + existing.Model + "): ");
                                existing.Model = Console.ReadLine();

                                Console.Write("Make (" + existing.Make + "): ");
                                existing.Make = Console.ReadLine();

                                Console.Write("Year (" + existing.VehicleYear + "): ");
                                existing.VehicleYear = int.Parse(Console.ReadLine());

                                Console.Write("Color (" + existing.Color + "): ");
                                string newColor = Console.ReadLine();
                                existing.Color = string.IsNullOrWhiteSpace(newColor) ? null : newColor;

                                Console.Write("Registration Number (" + existing.RegistrationNumber + "): ");
                                existing.RegistrationNumber = Console.ReadLine();

                                Console.Write("Is Available (true/false): ");
                                existing.VehicleAvailability = bool.Parse(Console.ReadLine());

                                Console.Write("Daily Rate (" + existing.DailyRate + "): ");
                                existing.DailyRate = decimal.Parse(Console.ReadLine());

                                vehicleService.UpdateVehicle(existing);
                                Console.WriteLine("Vehicle updated successfully.");
                            }
                            catch (VehicleException ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "5":
                        Console.Write("Enter Vehicle ID to Delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            try
                            {
                                vehicleService.RemoveVehicle(deleteId);
                                Console.WriteLine("Vehicle removed successfully.");
                            }
                            catch (VehicleException ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void DisplayVehicle(Vehicle vehicle)
        {
            Console.WriteLine("\n--- Vehicle Details ---");
            Console.WriteLine($"ID: {vehicle.VehicleID}");
            Console.WriteLine($"Model: {vehicle.Model}");
            Console.WriteLine($"Make: {vehicle.Make}");
            Console.WriteLine($"Year: {vehicle.VehicleYear}");
            Console.WriteLine($"Color: {vehicle.Color}");
            Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}");
            Console.WriteLine($"Available: {vehicle.VehicleAvailability}");
            Console.WriteLine($"Daily Rate: {vehicle.DailyRate}");
        }
    }
}
