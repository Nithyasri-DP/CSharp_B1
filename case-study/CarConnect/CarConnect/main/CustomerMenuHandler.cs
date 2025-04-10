using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarConnect.dao;
using CarConnect.entity;
using CarConnect.exception;

namespace CarConnect.main
{
    public class CustomerMenuHandler
    {
        public static void HandleCustomerMenu()
        {
            CustomerService customerService = new CustomerService();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nCUSTOMER MENU\n");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Get Customer by ID");
                Console.WriteLine("3. Get Customer by Username");
                Console.WriteLine("4. Update Customer");
                Console.WriteLine("5. Delete Customer");
                Console.WriteLine("6. Back to Main Menu\n");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Customer newCustomer = new Customer();

                        Console.Write("First Name: ");
                        newCustomer.FirstName = Console.ReadLine();

                        Console.Write("Last Name: ");
                        newCustomer.LastName = Console.ReadLine();

                        Console.Write("Email: ");
                        newCustomer.Email = Console.ReadLine();

                        Console.Write("Phone Number: ");
                        newCustomer.PhoneNumber = Console.ReadLine();

                        Console.Write("Address: ");
                        newCustomer.cAddress = Console.ReadLine();

                        Console.Write("Username: ");
                        newCustomer.Username = Console.ReadLine();

                        Console.Write("Password: ");
                        newCustomer.cPassword = Console.ReadLine();

                        try
                        {
                            customerService.RegisterCustomer(newCustomer);
                            Console.WriteLine("Customer registered successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "2":
                        Console.Write("Enter Customer ID: ");
                        if (int.TryParse(Console.ReadLine(), out int custId))
                        {
                            var customer = customerService.GetCustomerById(custId);
                            if (customer != null)
                            {
                                DisplayCustomer(customer);
                            }
                            else
                            {
                                Console.WriteLine("Customer not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Username: ");
                        string username = Console.ReadLine();
                        var cust = customerService.GetCustomerByUsername(username);
                        if (cust != null)
                        {
                            DisplayCustomer(cust);
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Customer ID to Update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            var existing = customerService.GetCustomerById(updateId);
                            if (existing == null)
                            {
                                Console.WriteLine("Customer not found.");
                                break;
                            }

                            Console.Write("First Name (" + existing.FirstName + "): ");
                            existing.FirstName = Console.ReadLine();

                            Console.Write("Last Name (" + existing.LastName + "): ");
                            existing.LastName = Console.ReadLine();

                            Console.Write("Email (" + existing.Email + "): ");
                            existing.Email = Console.ReadLine();

                            Console.Write("Phone Number (" + existing.PhoneNumber + "): ");
                            existing.PhoneNumber = Console.ReadLine();

                            Console.Write("Address (" + existing.cAddress + "): ");
                            existing.cAddress = Console.ReadLine();

                            Console.Write("Username (" + existing.Username + "): ");
                            existing.Username = Console.ReadLine();

                            Console.Write("Password: ");
                            existing.cPassword = Console.ReadLine();

                            try
                            {
                                customerService.UpdateCustomer(existing);
                                Console.WriteLine("Customer updated successfully.");
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
                        Console.Write("Enter Customer ID to Delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            try
                            {
                                customerService.DeleteCustomer(deleteId);
                                Console.WriteLine("Customer deleted successfully.");
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
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void DisplayCustomer(Customer customer)
        {
            Console.WriteLine("\n--- Customer Details ---");
            Console.WriteLine($"ID: {customer.CustomerID}");
            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone: {customer.PhoneNumber}");
            Console.WriteLine($"Address: {customer.cAddress}");
            Console.WriteLine($"Username: {customer.Username}");
        }
    }

}