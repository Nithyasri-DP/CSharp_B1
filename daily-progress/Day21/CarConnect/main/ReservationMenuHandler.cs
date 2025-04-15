using System;
using System.Collections.Generic;
using CarConnect.entity;
using CarConnect.dao;
using CarConnect.exception;

namespace CarConnect.main
{
    public class ReservationMenuHandler
    {
        public static void HandleReservationMenu()
        {
            ReservationService service = new ReservationService();

            while (true)
            {
                Console.WriteLine("\nRESERVATION MENU\n");
                Console.WriteLine("1. Create Reservation");
                Console.WriteLine("2. Get Reservation by ID");
                Console.WriteLine("3. Get Reservations by Customer ID");
                Console.WriteLine("4. Update Reservation");
                Console.WriteLine("5. Cancel Reservation");
                Console.WriteLine("6. Back to Main Menu\n");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Reservation newRes = new Reservation();
                        Console.Write("Customer ID: ");
                        newRes.CustomerID = int.Parse(Console.ReadLine());
                        Console.Write("Vehicle ID: ");
                        newRes.VehicleID = int.Parse(Console.ReadLine());
                        Console.Write("Start Date (yyyy-mm-dd): ");
                        newRes.StartDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("End Date (yyyy-mm-dd): ");
                        newRes.EndDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Total Cost: ");
                        newRes.TotalCost = decimal.Parse(Console.ReadLine());
                        Console.Write("Status (Pending/Confirmed/Completed): ");
                        newRes.Status = Console.ReadLine();
                        try
                        {
                            service.CreateReservation(newRes);
                            Console.WriteLine("Reservation created successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "2":
                        Console.Write("Enter Reservation ID: ");
                        int rid = int.Parse(Console.ReadLine());
                        var res = service.GetReservationById(rid);
                        if (res != null)
                            Display(res);
                        else
                            Console.WriteLine("Reservation not found.");
                        break;

                    case "3":
                        Console.Write("Enter Customer ID: ");
                        int cid = int.Parse(Console.ReadLine());
                        var list = service.GetReservationsByCustomerId(cid);
                        if (list.Count > 0)
                            list.ForEach(Display);
                        else
                            Console.WriteLine("No reservations found for this customer.");
                        break;

                    case "4":
                        Console.Write("Enter Reservation ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        var existing = service.GetReservationById(updateId);
                        if (existing == null)
                        {
                            Console.WriteLine("Reservation not found.");
                            break;
                        }

                        Console.Write("Start Date (" + existing.StartDate.ToShortDateString() + "): ");
                        existing.StartDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("End Date (" + existing.EndDate.ToShortDateString() + "): ");
                        existing.EndDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Total Cost (" + existing.TotalCost + "): ");
                        existing.TotalCost = decimal.Parse(Console.ReadLine());

                        Console.Write("Status (" + existing.Status + "): ");
                        existing.Status = Console.ReadLine();

                        try
                        {
                            service.UpdateReservation(existing);
                            Console.WriteLine("Reservation updated successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "5":
                        Console.Write("Enter Reservation ID to cancel: ");
                        int delId = int.Parse(Console.ReadLine());
                        try
                        {
                            service.CancelReservation(delId);
                            Console.WriteLine("Reservation cancelled successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private static void Display(Reservation res)
        {
            Console.WriteLine("\n--- Reservation Details ---");
            Console.WriteLine($"ID: {res.ReservationID}");
            Console.WriteLine($"Customer ID: {res.CustomerID}");
            Console.WriteLine($"Vehicle ID: {res.VehicleID}");
            Console.WriteLine($"Start Date: {res.StartDate.ToShortDateString()}");
            Console.WriteLine($"End Date: {res.EndDate.ToShortDateString()}");
            Console.WriteLine($"Total Cost: {res.TotalCost}");
            Console.WriteLine($"Status: {res.Status}");
        }
    }
}
