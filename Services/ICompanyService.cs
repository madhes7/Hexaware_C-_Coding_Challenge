using CareerHub.Model;
using System.Collections.Generic;

namespace CareerHub.Services
{
    public interface ICompanyService
    {
        // Method to post a job listing by a company
        void PostJob();

        // Method to retrieve a list of job listings posted by the company
        void GetJobs();

        // Method to insert a new company into the Companies table
        void InsertCompany();

        // Method to retrieve a list of all companies
        void GetCompanies();
    }
}
