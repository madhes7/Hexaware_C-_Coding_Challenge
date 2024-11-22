using CareerHub.Model;
using CareerHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Services
{
    internal interface IApplicantService
    {
        // Method to create a new applicant profile
        void CreateProfile();

        // Method to apply for a job
        void ApplyForJob();

        // Method to insert an applicant
        void InsertApplicant();

        // Method to retrieve all applicants
        void GetApplicants();
    }
}
