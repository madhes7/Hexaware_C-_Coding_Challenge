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
                Console.WriteLine("7. Get Jobs Posted by a Company");
                Console.WriteLine("8. Insert a New Company");
                Console.WriteLine("9. Insert a New Applicant");
                Console.WriteLine("10. Get All Applicants");
                Console.WriteLine("11. Insert Job Listing");
                Console.WriteLine("12. Insert Job Application");
                Console.WriteLine("13. Get Applicants for a Job");
                Console.WriteLine("13. Salary Range job search");
                Console.WriteLine("15. Exit");

                // Get user input for menu choice
                Console.Write("Enter your choice (1-14): ");
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
                        GetJobs(companyService);
                        return;
                    case "8":
                        InsertCompany(companyService);
                        return;
                    case "9":
                        InsertApplicant( applicantService);
                        return;
                    case "10":
                        GetApplicants( applicantService);
                        return;
                    case "11":
                        VInsertJobListing(jobListingService);
                        return;
                    case "12":
                        InsertJobApplication( jobApplicationService);
                        return;
                    case "13":
                        GetApplicants( jobListingService);
                        return;
                    case "14":
                        ListbasedOnSalary(jobListingService);
                        return;
                    case "15":
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
        private static void GetJobs(CompanyService companyService)
        {
            companyService.GetJobs();


        }
        private static void InsertCompany(CompanyService companyService)
        {
            companyService.InsertCompany();


        }
        private static void InsertApplicant(ApplicantService applicantService)
        {

            applicantService.InsertApplicant();
            Console.WriteLine("Application submitted successfully!");
        }
        private static void GetApplicants(ApplicantService applicantService)
        {

            applicantService.GetApplicants();
            Console.WriteLine("Application submitted successfully!");
        }
        private static void InsertJobApplication(JobApplicationService jobApplicationService)
        {

            jobApplicationService.InsertJobApplication();
            Console.WriteLine("Application submitted successfully!");
        }
        private static void VInsertJobListing(JobListingService jobListingService)
        {
            jobListingService.GetApplicants();


        }
        private static void GetApplicants(JobListingService jobListingService)
        {
            jobListingService.GetApplicants();
        }
        private static void ListbasedOnSalary(JobListingService jobListingService)
        {
            jobListingService.ListbasedOnSalary();
        }
    }
}
