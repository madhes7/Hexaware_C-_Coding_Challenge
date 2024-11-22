using CareerHub.Model;
using CareerHub.Repositories;

namespace CareerHub.Services
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepositories _jobApplicationRepositories;

        // Constructor to initialize the repository
        public JobApplicationService()
        {
            _jobApplicationRepositories = new JobApplicationRepositories();
        }

        // Method to insert a new job application
        public void InsertJobApplication()
        {
            Console.WriteLine("\n--- Apply for a Job ---");

            // Get applicant ID
            Console.Write("Enter applicant ID: ");
            int applicantID = Convert.ToInt32(Console.ReadLine());

            // Get job ID
            Console.Write("Enter job ID: ");
            int jobID = Convert.ToInt32(Console.ReadLine());

            // Get the cover letter
            Console.Write("Enter your cover letter: ");
            string coverLetter = Console.ReadLine();

            // Create a new JobApplication object
            var jobApplication = new JobApplication
            {
                ApplicantID = applicantID,
                JobID = jobID,
                CoverLetter = coverLetter,
                ApplicationDate = DateTime.Now
            };

            // Call the service method to insert the job application
            _jobApplicationRepositories.InsertJobApplication(jobApplication);

            Console.WriteLine("Job application submitted successfully!");
            
        }
    }
}
