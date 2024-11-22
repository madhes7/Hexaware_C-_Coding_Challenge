using CareerHub.Model;
using CareerHub.Repositories;
using System;
using System.Collections.Generic;

namespace CareerHub.Services
{
    public class JobListingService : IJobListingService
    {
        private readonly IJobListingRepositories _jobListingRepositories;

        // Constructor to initialize the repository
        public JobListingService()
        {
            _jobListingRepositories = new JobListingRepositories ();
        }

        // Method to apply for a job
        public void Apply()
        {
            Console.WriteLine("\n--- Apply for a Job ---");

            // Get application details
            Console.Write("Enter applicant ID: ");
            int applicantID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter job ID: ");
            int jobID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your cover letter: ");
            string coverLetter = Console.ReadLine();

            // Apply for the job using the service
            _jobListingRepositories.Apply(applicantID, coverLetter, jobID);

            Console.WriteLine("Job application submitted successfully!");
            
            
        }

        // Method to get a list of applicants for a specific job
        public void GetApplicants()
        {
            Console.WriteLine("\n--- View Applicants for a Job ---");

            Console.Write("Enter job ID: ");
            int jobID = Convert.ToInt32(Console.ReadLine());

            List<Applicant> applicants = _jobListingRepositories.GetApplicants(jobID);

            Console.WriteLine("Applicants for Job ID " + jobID + ":");
            foreach (var applicant in applicants)
            {
                Console.WriteLine($"Applicant ID: {applicant.ApplicantID}, Name: {applicant.FirstName} {applicant.LastName}");
            }
            
        }

        // Method to insert a new job listing
        public void InsertJobListing()
        {
            Console.WriteLine("\n--- Insert a Job Listing ---");

            // Get job details
            Console.Write("Enter job title: ");
            string jobTitle = Console.ReadLine();

            Console.Write("Enter job description: ");
            string jobDescription = Console.ReadLine();

            Console.Write("Enter job location: ");
            string jobLocation = Console.ReadLine();

            Console.Write("Enter salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter job type (e.g., Full-Time, Part-Time): ");
            string jobType = Console.ReadLine();

            // Create a new JobListing object
            var jobListing = new JobListing
            {
                JobTitle = jobTitle,
                JobDescription = jobDescription,
                JobLocation = jobLocation,
                Salary = salary,
                JobType = jobType,
                PostedDate = DateTime.Now
            };

            // Insert the job listing using the service
            _jobListingRepositories.InsertJobListing(jobListing);

            Console.WriteLine("Job listing inserted successfully!");
            
        }

        // Method to retrieve all job listings
        public void GetJobListings()
        {
            Console.WriteLine("\n--- View All Job Listings ---");

            List<JobListing> jobListings = _jobListingRepositories.GetJobListings(); ;

            Console.WriteLine("Job Listings:");
            foreach (var job in jobListings)
            {
                Console.WriteLine($"Job ID: {job.JobID}, Title: {job.JobTitle}, Location: {job.JobLocation}, Salary: {job.Salary}");
            }
         
        }
        public void ListbasedOnSalary()
        {
            Console.WriteLine("\n--- Enter the Start range ---");
            decimal s= Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("\n--- Enter the End range ---");
            decimal e = Convert.ToDecimal(Console.ReadLine());


            List<JobListing> jobListings = _jobListingRepositories.ListbasedOnSalary(s,e);

            Console.WriteLine("Job Listings:");
            foreach (var job in jobListings)
            {
                Console.WriteLine($"Job ID: {job.JobID}, Title: {job.JobTitle}, Location: {job.JobLocation}, Salary: {job.Salary}");
            }

        }
    }
}
