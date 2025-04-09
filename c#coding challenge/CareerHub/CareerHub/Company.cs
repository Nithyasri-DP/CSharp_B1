using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub
{
    public class Company
    {
        // Company properties
        public int CompanyID { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        // List to store jobs posted by this company
        private List<JobListing> postedJobs = new List<JobListing>();

        // Default constructor
        public Company() { }

        // Constructor to initialize company details
        public Company(int companyID, string companyName, string location)
        {
            this.CompanyID = companyID;
            this.CompanyName = companyName;
            this.Location = location;
        }

        // Post a new job
        public void PostJob(string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType)
        {
            int newJobId = postedJobs.Count + 1; // Simple JobID generator
            JobListing job = new JobListing(newJobId, this.CompanyID, jobTitle, jobDescription, jobLocation, salary, jobType, DateTime.Now);
            postedJobs.Add(job); // Add to the list
            Console.WriteLine($"Job '{jobTitle}' posted by {CompanyName}");
        }

        // Get all jobs posted by this company
        public List<JobListing> GetJobs()
        {
            return postedJobs;
        }
    }

}


