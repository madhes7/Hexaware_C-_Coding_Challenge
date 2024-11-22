using CareerHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Repositories
{
    internal interface IApplicantRepositories
    {
        // Method to create an applicant's profile
        void CreateProfile(string email, string firstName, string lastName, string phone);

        // Method to allow an applicant to apply for a job
        void ApplyForJob(int jobID, int applicantID, string coverLetter);

        void InsertApplicant(Applicant applicant);

        List<Applicant> GetApplicants();
    }
}
