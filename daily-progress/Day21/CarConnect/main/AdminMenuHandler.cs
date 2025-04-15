using System;
using System.Collections.Generic;
using CarConnect.dao;
using CarConnect.entity;
using CarConnect.exception;

namespace CarConnect.main
{
    public class AdminMenuHandler
    {
        public static void HandleAdminMenu()
        {
            AdminService adminService = new AdminService();
            CustomerService customerService = new CustomerService();
            ReservationService reservationService = new ReservationService();
            VehicleService vehicleService = new VehicleService();

            while (true)
            {
                Console.WriteLine("\nADMIN MENU\n");
                Console.WriteLine("1. Register Admin");
                Console.WriteLine("2. Get Admin by ID");
                Console.WriteLine("3. Get Admin by Username");
                Console.WriteLine("4. Update Admin");
                Console.WriteLine("5. Delete Admin");
                Console.WriteLine("6. View All Customers");
                Console.WriteLine("7. View All Admins");
                Console.WriteLine("8. View All Reservations(Current&History)");
                Console.WriteLine("9. View Vehicle Utilization");
                Console.WriteLine("10. View Revenue Report");
                Console.WriteLine("11. Back to Main Menu\n");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Admin newAdmin = new Admin();

                        Console.Write("First Name: ");
                        newAdmin.FirstName = Console.ReadLine();

                        Console.Write("Last Name: ");
                        newAdmin.LastName = Console.ReadLine();

                        Console.Write("Email: ");
                        newAdmin.Email = Console.ReadLine();

                        Console.Write("Phone Number: ");
                        newAdmin.PhoneNumber = Console.ReadLine();

                        Console.Write("Username: ");
                        newAdmin.Username = Console.ReadLine();

                        Console.Write("Password: ");
                        newAdmin.AdminPassword = Console.ReadLine();

                        Console.Write("Role (Super Admin / Fleet Manager): ");
                        newAdmin.AdminRole = Console.ReadLine();

                        try
                        {
                            adminService.RegisterAdmin(newAdmin);
                            Console.WriteLine("Admin registered successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "2":
                        try
                        {
                            Console.Write("Enter Admin ID: ");
                            int adminId = Convert.ToInt32(Console.ReadLine());
                            Admin admin = adminService.GetAdminById(adminId);
                            DisplayAdmin(admin);
                        }
                        catch (AdminNotFoundException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        catch (DatabaseConnectionException ex)
                        {
                            Console.WriteLine("Database error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unexpected error: " + ex.Message);
                        }
                        break;

                    case "3":
                        try
                        {
                            Console.Write("Enter Username: ");
                            string uname = Console.ReadLine();
                            Admin fetched = adminService.GetAdminByUsername(uname);
                            DisplayAdmin(fetched);
                        }
                        catch (AuthenticationException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        catch (DatabaseConnectionException ex)
                        {
                            Console.WriteLine("Database error: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Unexpected error: " + ex.Message);
                        }
                        break;

                    case "4":
                        Console.Write("Enter Admin ID to Update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            try
                            {
                                Admin adminToUpdate = adminService.GetAdminById(updateId);

                                Console.Write("First Name (" + adminToUpdate.FirstName + "): ");
                                adminToUpdate.FirstName = Console.ReadLine();

                                Console.Write("Last Name (" + adminToUpdate.LastName + "): ");
                                adminToUpdate.LastName = Console.ReadLine();

                                Console.Write("Email (" + adminToUpdate.Email + "): ");
                                adminToUpdate.Email = Console.ReadLine();

                                Console.Write("Phone Number (" + adminToUpdate.PhoneNumber + "): ");
                                adminToUpdate.PhoneNumber = Console.ReadLine();

                                Console.Write("Username (" + adminToUpdate.Username + "): ");
                                adminToUpdate.Username = Console.ReadLine();

                                Console.Write("Password: ");
                                adminToUpdate.AdminPassword = Console.ReadLine();

                                Console.Write("Role (" + adminToUpdate.AdminRole + "): ");
                                adminToUpdate.AdminRole = Console.ReadLine();

                                adminService.UpdateAdmin(adminToUpdate);
                                Console.WriteLine("Admin updated successfully.");
                            }
                            catch (Exception ex)
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
                        Console.Write("Enter Admin ID to Delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            try
                            {
                                adminService.DeleteAdmin(deleteId);
                                Console.WriteLine("Admin deleted successfully.");
                            }
                            catch (Exception ex)
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
                        List<Customer> customers = customerService.GetAllCustomers();
                        if (customers.Count > 0)
                            customers.ForEach(DisplayCustomer);
                        else
                            Console.WriteLine("No customers found.");
                        break;

                    case "7":
                        List<Admin> admins = adminService.GetAllAdmins();
                        if (admins.Count > 0)
                            admins.ForEach(DisplayAdmin);
                        else
                            Console.WriteLine("No admins found.");
                        break;

                    case "8":
                        List<Reservation> reservations = reservationService.GetAllReservations();
                        Console.WriteLine("\n--- Reservation History ---");
                        if (reservations.Count > 0)
                            reservations.ForEach(DisplayReservation);
                        else
                            Console.WriteLine("No reservations found.");
                        break;

                    case "9":
                        vehicleService.ShowVehicleUtilizationReport();
                        break;

                    case "10":
                        decimal revenue = reservationService.CalculateTotalRevenue();
                        Console.WriteLine("\n--- Revenue Report ---");
                        Console.WriteLine($"Total Revenue from Reservations: Rs. {revenue}");
                        break;
                    case "11":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }


        private static void DisplayAdmin(Admin admin)
        {
            Console.WriteLine("\n--- Admin Details ---");
            Console.WriteLine($"ID: {admin.AdminID}");
            Console.WriteLine($"Name: {admin.FirstName} {admin.LastName}");
            Console.WriteLine($"Email: {admin.Email}");
            Console.WriteLine($"Phone: {admin.PhoneNumber}");
            Console.WriteLine($"Username: {admin.Username}");
            Console.WriteLine($"Role: {admin.AdminRole}");
            Console.WriteLine($"Joined: {admin.JoinDate}");
        }

        private static void DisplayCustomer(Customer customer)
        {
            Console.WriteLine("\n--- Customer Details ---");
            Console.WriteLine($"ID: {customer.CustomerID}");
            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.PhoneNumber}");
            Console.WriteLine($"Username: {customer.Username}");
        }

        private static void DisplayReservation(Reservation res)
        {
            Console.WriteLine("\n--- Reservation Details ---");
            Console.WriteLine($"ID: {res.ReservationID}");
            Console.WriteLine($"Customer ID: {res.CustomerID}");
            Console.WriteLine($"Vehicle ID: {res.VehicleID}");
            Console.WriteLine($"Start: {res.StartDate.ToShortDateString()}");
            Console.WriteLine($"End: {res.EndDate.ToShortDateString()}");
            Console.WriteLine($"Total Cost: {res.TotalCost}");
            Console.WriteLine($"Status: {res.Status}");
        }
    }
}
