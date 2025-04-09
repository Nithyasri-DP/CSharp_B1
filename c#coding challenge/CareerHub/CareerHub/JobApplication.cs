using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub
{
    public class JobApplication
    {
        public int ApplicationID { get; set; }
        public int JobID { get; set; }
        public int ApplicantID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string CoverLetter { get; set; }

        // Constructor to initialize application
        public JobApplication(int applicationID, int jobID, int applicantID, DateTime applicationDate, string coverLetter)
        {
            this.ApplicationID = applicationID;
            this.JobID = jobID;
            this.ApplicantID = applicantID;
            this.ApplicationDate = applicationDate;
            this.CoverLetter = coverLetter;
        }
    }


}
