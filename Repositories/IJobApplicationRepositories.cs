using CareerHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CareerHub.Repositories
{
    internal interface IJobApplicationRepositories
    {

        void InsertJobApplication(JobApplication jobapplication);
    }
}
        // void InsertJobListing(JobListing jobListing);//
        //void InsertCompany(Company company);//
        //void InsertApplicant(Applicant applicant);//
        //List<JobListing> GetJobListings();
        //List<Company> GetCompanies();
        //List<Applicant> GetApplicants();
        //List<JobApplication> GetApplicationsForJob(int jobid);
    

