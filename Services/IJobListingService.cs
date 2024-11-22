using CareerHub.Model;
using System.Collections.Generic;

namespace CareerHub.Services
{
    public interface IJobListingService
    {
        // Method to apply for a job
        void Apply();

        // Method to get a list of applicants for a specific job
        void GetApplicants();

        // Method to insert a new job listing
        void InsertJobListing();

        // Method to retrieve all job listings
        void GetJobListings();

        void ListbasedOnSalary();
    }
}
