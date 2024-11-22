using CareerHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Repositories
{
    internal interface ICompanyRepositories
    {
        // Method to post a job listing by a company
        void PostJob(string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType, int companyID);

        // Method to retrieve a list of job listings posted by the company
        List<JobListing> GetJobs(int companyID);

        void InsertCompany(Company company);
        List<Company> GetCompanies();
    }
}
