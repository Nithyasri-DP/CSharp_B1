using System;
using System.Data.SqlClient;
using CarConnect.dao;
using CarConnect.entity;
using CarConnect.exception;
using CarConnect.service;
using CarConnect.util;
using CarConnect.dao;

namespace CarConnect.main
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                AuthenticationService authService = new AuthenticationService();
                string loggedInRole = "";

                Console.WriteLine("WELCOME TO CAR CONNECT\n");
                Console.WriteLine("1. Customer Login");
                Console.WriteLine("2. Admin Login");
                Console.Write("Select option: ");
                string loginChoice = Console.ReadLine();

                if (loginChoice == "1")
                {
                    Console.Write("Enter Customer Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    try
                    {
                        if (authService.AuthenticateCustomer(username, password))
                        {
                            Console.WriteLine("Login successful, Welcome Customer.");
                            loggedInRole = "Customer";
                        }
                    }
                    catch (AuthenticationException ex)
                    {
                        Console.WriteLine("Login failed: " + ex.Message);
                        return;
                    }
                }
                else if (loginChoice == "2")
                {
                    Console.Write("Enter Admin Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    try
                    {
                        if (authService.AuthenticateAdmin(username, password))
                        {
                            Console.WriteLine("Login successful, Welcome Admin.");
                            loggedInRole = "Admin";
                        }
                    }
                    catch (AuthenticationException ex)
                    {
                        Console.WriteLine("Login failed: " + ex.Message);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Exiting..");
                    return;
                }

                while (true)
                {
                    Console.WriteLine("\nCARCONNECT MAIN MENU\n");

                    if (loggedInRole == "Customer")
                    {
                        Console.WriteLine("1. Customer Menu");
                        Console.WriteLine("2. Vehicle Menu");
                        Console.WriteLine("3. Reservation Menu");
                        Console.WriteLine("4. Exit");
                        Console.Write("Enter your choice: ");
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                CustomerMenuHandler.HandleCustomerMenu();
                                break;
                            case "2":
                                VehicleMenuHandler.HandleVehicleMenu();
                                break;
                            case "3":
                                ReservationMenuHandler.HandleReservationMenu();
                                break;
                            case "4":
                                Console.WriteLine("Exiting..");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Try again.");
                                break;
                        }
                    }
                    else if (loggedInRole == "Admin")
                    {
                        Console.WriteLine("1. Admin Menu");
                        Console.WriteLine("2. Vehicle Menu");
                        Console.WriteLine("3. Reservation Menu");
                        Console.WriteLine("4. Exit");
                        Console.Write("Enter your choice: ");
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                AdminMenuHandler.HandleAdminMenu();
                                break;
                            case "2":
                                VehicleMenuHandler.HandleVehicleMenu();
                                break;
                            case "3":
                                ReservationMenuHandler.HandleReservationMenu();
                                break;
                            case "4":
                                Console.WriteLine("Exiting..");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Try again.");
                                break;
                        }
                    }
                }
            }
            catch (DatabaseConnectionException ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
        }

    }
}
