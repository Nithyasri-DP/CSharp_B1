using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBoard.Entity;

namespace JobBoard.Dao
{
    public interface IApplicationService
    {
        void SubmitApplication(JobApplication application);
        List<JobApplication> GetApplicationsByJobId(int jobId);
        List<JobApplication> GetAllApplications();
    }
}
