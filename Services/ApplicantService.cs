using CareerHub.Model;
using CareerHub.Repositories;
using System;
using System.Collections.Generic;

namespace CareerHub.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepositories _applicantRepositories;

        // Constructor to initialize the repository
        public ApplicantService( )
        {
            _applicantRepositories = new ApplicantRepositories();
        }

        // Create a new applicant profile
        public void CreateProfile()
        {
            Console.WriteLine("\n--- Create Applicant Profile ---");

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();

            // Create applicant profile
           
            
            _applicantRepositories.CreateProfile(email, firstName, lastName, phone);
            Console.WriteLine("Applicant profile created successfully!");
        }

        // Apply for a job
        public void ApplyForJob()
        {
            Console.WriteLine("\n--- Apply for Job ---");

            Console.Write("Enter applicant ID: ");
            int applicantID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter job ID: ");
            int jobID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your cover letter: ");
            string coverLetter = Console.ReadLine();

            // Apply for the job
            
           
            _applicantRepositories.ApplyForJob(jobID, applicantID, coverLetter); Console.WriteLine("Application submitted successfully!");
        }

        // Insert a new applicant
        public void InsertApplicant()
        {
            Console.WriteLine("\n--- Create Applicant Profile ---");

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();

            // Create applicant profile
            _applicantRepositories.InsertApplicant(
            new Applicant
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone
            });

            Console.WriteLine("Applicant profile created successfully!");
            
        }

        // Retrieve a list of all applicants
        public void GetApplicants()
        {
            Console.WriteLine("\n--- View All Applicants ---");

            List<Applicant> applicants = _applicantRepositories.GetApplicants();
            Console.WriteLine("Applicants List:");
            foreach (var applicant in applicants)
            {
                Console.WriteLine($"ID: {applicant.ApplicantID}, Name: {applicant.FirstName} {applicant.LastName}, Email: {applicant.Email}, Phone: {applicant.Phone}");
            }
            
            
        }
    }
}
