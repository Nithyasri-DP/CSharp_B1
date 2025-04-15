using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Entity
{
    public class JobListing
    {
        public int JobID { get; set; }
        public int CompanyID { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string JobDescription { get; set; }
        public string JobLocation { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string JobType { get; set; } = string.Empty;
        public DateTime PostedDate { get; set; }

        private List<Applicant> applicants = new List<Applicant>();

        // Constructor to initialize job details
        public JobListing(int jobID, int companyID, string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType, DateTime postedDate)
        {
            this.JobID = jobID;
            this.CompanyID = companyID;
            this.JobTitle = jobTitle;
            this.JobDescription = jobDescription;
            this.JobLocation = jobLocation;
            this.Salary = salary;
            this.JobType = jobType;
            this.PostedDate = postedDate;
        }

        // Add applicant to this job
        public void Apply(Applicant applicant, string coverLetter)
        {
            applicants.Add(applicant);
            Console.WriteLine($"Applicant {applicant.FirstName} applied to {JobTitle}");
        }

        // Return all applicants for this job
        public List<Applicant> GetApplicants()
        {
            return applicants;
        }
    }
}
