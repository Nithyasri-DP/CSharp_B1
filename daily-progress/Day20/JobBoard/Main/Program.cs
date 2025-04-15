using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Utility;

namespace JobBoard.Main
{
    class MainModule
    {
        static void Main(string[] args)
        {
            DataBaseManager dbManager = new DataBaseManager();

            while (true)
            {
                Console.WriteLine("\n-----CAREERHUB-----\n");
                Console.WriteLine("1. View All Job Listings");
                Console.WriteLine("2. Register New Applicant");
                Console.WriteLine("3. Submit Job Application");
                Console.WriteLine("4. Post New Job (Company)");
                Console.WriteLine("5. Search Jobs by Salary Range");
                Console.WriteLine("0. Exit\n");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        dbManager.DisplayAllJobListings();
                        break;

                    case "2":
                        dbManager.CreateApplicantProfile();
                        break;

                    case "3":
                        dbManager.SubmitJobApplication();
                        break;

                    case "4":
                        dbManager.PostJob();
                        break;

                    case "5":
                        dbManager.SearchJobsBySalaryRange();
                        break;

                    case "0":
                        Console.WriteLine("Exiting CareerHub. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
