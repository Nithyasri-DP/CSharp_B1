using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Entity;

namespace JobBoard.Dao
{
    public interface IJobListingService
    {
        void PostJob(JobListing job);
        List<JobListing> GetAllJobs();
        List<JobListing> GetJobsByCompany(int companyId);
        JobListing GetJobById(int jobId);
    }
}
