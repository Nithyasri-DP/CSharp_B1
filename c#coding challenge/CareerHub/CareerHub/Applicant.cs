using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub
{
    public class Applicant
    {
        public int ApplicantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Resume { get; set; }

        // Constructor to initialize applicant details
        public Applicant(int applicantID, string firstName, string lastName, string email, string phone, string resume)
        {
            this.ApplicantID = applicantID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Resume = resume;
        }

        // Update profile details
        public void CreateProfile(string email, string firstName, string lastName, string phone)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            Console.WriteLine($"Profile updated: {FirstName} {LastName}");
        }

        // Apply for a job
        public JobApplication ApplyForJob(int jobID, string coverLetter)
        {
            return new JobApplication(0, jobID, this.ApplicantID, DateTime.Now, coverLetter);
        }
    }


}
