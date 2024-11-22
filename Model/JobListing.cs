using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Model
{
    public class JobListing
    {
        public int JobID { get; set; }
        public int CompanyID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }
        public decimal Salary { get; set; }
        public string JobType { get; set; }
        public DateTime PostedDate { get; set; }

        private List<JobApplication> applications = new List<JobApplication>();

        public void Apply(int applicantID, string coverLetter)
        {
            JobApplication application = new JobApplication
            {
                ApplicationID = applications.Count + 1,
                JobID = this.JobID,
                ApplicantID = applicantID,
                ApplicationDate = DateTime.Now,
                CoverLetter = coverLetter
            };
            applications.Add(application);
            Console.WriteLine($"Applicant {applicantID} has successfully applied for Job {JobID}.");
        }

        public List<JobApplication> GetApplicants()
        {
            return applications;
        }
    }
}
