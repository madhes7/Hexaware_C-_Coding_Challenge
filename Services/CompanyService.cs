using CareerHub.Model;
using CareerHub.Repositories;
using System.Collections.Generic;

namespace CareerHub.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepositories _companyRepositories;

        // Constructor to initialize the repository
        public CompanyService()
        {
            _companyRepositories = new CompanyRepositories(); 
        }

        // Method to post a job listing by a company
        public void PostJob()
        {
            Console.WriteLine("\n--- Post a New Job Listing ---");

            Console.Write("Enter company ID: ");
            int companyID = Convert.ToInt32(Console.ReadLine());

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

            // Post the job
            
            
            _companyRepositories.PostJob(jobTitle, jobDescription, jobLocation, salary, jobType, companyID);Console.WriteLine("Job posted successfully!");
        }

        // Method to retrieve a list of job listings posted by the company
        public void GetJobs()
        {
            Console.WriteLine("\n--- View All Job Listings by Company ---");

            Console.Write("Enter company ID: ");
            int companyID = Convert.ToInt32(Console.ReadLine());

            List<JobListing> jobListings = _companyRepositories.GetJobs(companyID);

            if (jobListings.Count > 0)
            {
                Console.WriteLine("Job Listings:");
                foreach (var job in jobListings)
                {
                    Console.WriteLine($"Job ID: {job.JobID}, Title: {job.JobTitle}, Location: {job.JobLocation}, Salary: {job.Salary}");
                }
            }
            else
            {
                Console.WriteLine("No job listings found for the specified company.");
            }
            
        }

        // Method to insert a new company into the Companies table
        public void InsertCompany()
        {
            Console.WriteLine("\n--- Insert a New Company ---");

            Console.Write("Enter company name: ");
            string companyName = Console.ReadLine();

            Console.Write("Enter company location: ");
            string location = Console.ReadLine();

            // Create a new company object
            var company = new Company
            {
                Company_name = companyName,
                location = location
            };

            // Insert the new company using the service
            _companyRepositories.InsertCompany(company);
            Console.WriteLine("Company inserted successfully!");
            
        }

        // Method to retrieve a list of all companies
        public void GetCompanies()

        {

            Console.WriteLine("\n--- View All Companies ---");

            List<Company> companies = _companyRepositories.GetCompanies();

            Console.WriteLine("Companies:");
            foreach (var company in companies)
            {
                Console.WriteLine($"Company ID: {company.CompanyId}, Name: {company.Company_name}, Location: {company.location}");
            }
           
        }
    }
}
