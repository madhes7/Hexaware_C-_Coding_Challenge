using CareerHub.Model;
using CareerHub.Repositories;
using CareerHub.Services;
using System;
using System.Collections.Generic;

namespace CareerHub
{
    class Main
    {
        public Main( )
        {
            // Sample connection string (replace with actual connection string)
            string connectionString = "Server=localhost;Database=CareerHub;User Id=sa;Password=password;";

            // Initialize repositories and services
            var jobListingRepository = new JobListingRepositories();
            var jobListingService = new JobListingService();

            var jobApplicationRepository = new JobApplicationRepositories();
            var jobApplicationService = new JobApplicationService();

            var companyRepository = new CompanyRepositories();
            var companyService = new CompanyService();

            var applicantRepository = new ApplicantRepositories();
            var applicantService = new ApplicantService();

            // Main loop to show the menu
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to CareerHub! Please select an option:");
                Console.WriteLine("1. Create Applicant Profile");
                Console.WriteLine("2. Apply for Job");
                Console.WriteLine("3. Post a Job Listing");
                Console.WriteLine("4. View All Job Listings");
                Console.WriteLine("5. View All Companies");
                Console.WriteLine("6. View Applicants for a Job");
                Console.WriteLine("7. Exit");

                // Get user input for menu choice
                Console.Write("Enter your choice (1-7): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateApplicantProfile(applicantService);
                        break;

                    case "2":
                        ApplyForJob(applicantService, jobListingService);
                        break;

                    case "3":
                        PostJobListing(companyService);
                        break;

                    case "4":
                        ViewJobListings(jobListingService);
                        break;

                    case "5":
                        ViewCompanies(companyService);
                        break;

                    case "6":
                        ViewApplicantsForJob(jobListingService);
                        break;

                    case "7":
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice, please select between 1 and 7.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        // Method to create a new applicant profile
        private static void CreateApplicantProfile(ApplicantService applicantService)
        {
            applicantService.CreateProfile();
        }

        // Method for an applicant to apply for a job
        private static void ApplyForJob(ApplicantService applicantService, JobListingService jobListingService)
        {
            
            applicantService.ApplyForJob();
            Console.WriteLine("Application submitted successfully!");
        }

        // Method to post a new job listing
        private static void PostJobListing(CompanyService companyService)
        {
           

            
            // Post the job
            companyService.PostJob();
           
        }

        // Method to view all job listings
        private static void ViewJobListings(JobListingService jobListingService)
        {
            jobListingService.GetJobListings();

           
        }

        // Method to view all companies
        private static void ViewCompanies(CompanyService companyService)
        {
            companyService.GetCompanies();

           
        }

        // Method to view all applicants for a specific job
        private static void ViewApplicantsForJob(JobListingService jobListingService)
        {
           jobListingService.GetApplicants();

          
        }
    }
}
