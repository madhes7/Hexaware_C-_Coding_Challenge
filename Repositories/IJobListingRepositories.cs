using CareerHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Repositories
{
    internal interface IJobListingRepositories
    {
        void Apply(int applicantID, string coverLetter, int jobID);
        List<Applicant> GetApplicants(int jobID);
        void InsertJobListing(JobListing jobListing);
        List<JobListing> GetJobListings();
    }
}
