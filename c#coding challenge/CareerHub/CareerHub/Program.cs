using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CareerHub;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    static void Main(string[] args)
    {
        // Your existing commented block
        /*
        Console.WriteLine("All Companies:");
        var companies = DatabaseManager.GetCompanies();
        foreach (var company in companies)
        {
            Console.WriteLine($"{company.CompanyID}: {company.CompanyName} - {company.Location}");
        }

        Console.WriteLine("All Job Listings:");
        var jobs = DatabaseManager.GetJobListings();
        foreach (var job in jobs)
        {
            Console.WriteLine($"{job.JobID}: {job.JobTitle} ({job.JobLocation}) - {job.JobType} - {job.Salary}");
        }

        Console.WriteLine("All Applicants:");
        var applicants = DatabaseManager.GetApplicants();
        foreach (var applicant in applicants)
        {
            Console.WriteLine($"{applicant.ApplicantID}: {applicant.FirstName} {applicant.LastName} - {applicant.Email}");
        }

        Console.WriteLine("Applications for JobID 11:");
        var applications = DatabaseManager.GetApplicationsForJob(11);
        foreach (var app in applications)
        {
            Console.WriteLine($"ApplicationID: {app.ApplicationID}, ApplicantID: {app.ApplicantID}, Cover Letter: {app.CoverLetter}");
        }
        */

        // Exceptions
        // 1. Email validation
        Careerhub_Exceptions.ValidateEmail("invalidemail.com");

        // 2. Salary calculation (renamed 'testJobs' to avoid conflict)
        var testJobs = new List<JobListing>
        {
            new JobListing { Salary = 50000 },
            new JobListing { Salary = -20000 } // Invalid
        };
        Careerhub_Exceptions.CalculateAverageSalary(testJobs);

        // 3. File upload simulation
        Careerhub_Exceptions.UploadResume("path/to/resume.pdf");

        // 4. Application deadline check
        Careerhub_Exceptions.SubmitApplication(DateTime.Now, new DateTime(2025, 04, 01));

        // 5. DB connection test
        Careerhub_Exceptions.TestDatabaseConnection();

        
        // TASK-4
       
        using var context = new CareerHubContext();

        // Job Listing Retrieval
        Console.WriteLine("\n--- Job Listing Retrieval ---");
        try
        {
            var jobs = context.Jobs.Include(j => j.Company).ToList();
            foreach (var job in jobs)
                Console.WriteLine($"{job.JobTitle} - {job.Company.CompanyName} - ${job.Salary}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving jobs: " + ex.Message);
        }

        // Applicant Profile Creation
        Console.WriteLine("\n--- Applicant Profile Creation ---");
        try
        {
            var applicant = new Applicant { FirstName = "Nithya", LastName = "Sri", Email = "nithya.sri@gmail.com" };
            context.Applicants.Add(applicant);
            context.SaveChanges();
            Console.WriteLine("Applicant profile created.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error creating applicant: " + ex.Message);
        }

        // Job Application Submission
        Console.WriteLine("\n--- Job Application Submission ---");
        try
        {
            var application = new Application { ApplicantID = 1, JobID = 11, CoverLetter = "I am interested." };
            context.Applications.Add(application);
            context.SaveChanges();
            Console.WriteLine("Job application submitted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error submitting application: " + ex.Message);
        }

        // Company Job Posting
        Console.WriteLine("\n--- Company Job Posting ---");
        try
        {
            var job = new Job
            {
                JobTitle = "Backend Developer",
                JobLocation = "Remote",
                JobType = "Full-Time",
                Salary = 70000,
                CompanyID = 1
            };
            context.Jobs.Add(job);
            context.SaveChanges();
            Console.WriteLine("Job posted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error posting job: " + ex.Message);
        }

        // Salary Range Query
        Console.WriteLine("\n--- Salary Range Query ---");
        try
        {
            decimal minSalary = 50000;
            decimal maxSalary = 80000;
            var jobsInRange = context.Jobs.Include(j => j.Company).Where(j => j.Salary >= minSalary && j.Salary <= maxSalary).ToList();

            Console.WriteLine("Jobs within salary range:");
            foreach (var job in jobsInRange)
                Console.WriteLine($"{job.JobTitle} - {job.Company.CompanyName} - ${job.Salary}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving salary range jobs: " + ex.Message);
        }
    }
}
