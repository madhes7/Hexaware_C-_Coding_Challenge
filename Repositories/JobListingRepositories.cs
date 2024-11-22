using CareerHub.Model;
using CareerHub.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Repositories
{
    internal class JobListingRepositories:IJobListingRepositories
    {
        
         string _connectionString;

        public JobListingRepositories()
        {
            _connectionString = DBConnection.GetConnectionString();
        }

        public void Apply(int applicantID, string coverLetter, int jobID)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Applications (JobID, ApplicantID, CoverLetter, ApplicationDate) " +
                           "VALUES (@JobID, @ApplicantID, @CoverLetter, @ApplicationDate)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@JobID", jobID);
            command.Parameters.AddWithValue("@ApplicantID", applicantID);
            command.Parameters.AddWithValue("@CoverLetter", coverLetter);
            command.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);

            connection.Open();
            command.ExecuteNonQuery();
        }

      
        public List<Applicant> GetApplicants(int jobID)
        {
            var applicants = new List<Applicant>();
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT a.ApplicantID, a.FirstName, a.LastName, a.Email, a.Phone, a.Resume " +
                           "FROM Applicant a " +
                           "JOIN Applications ja ON a.ApplicantID = ja.ApplicantID " +
                           "WHERE ja.JobID = @JobID";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@JobID", jobID);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                applicants.Add(new Applicant
                {
                    ApplicantID = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    Phone = reader.GetString(4),
                    Resume = reader.GetString(5) 
                });
            }
            return applicants;
        }

        // Insert a new job listing into the Jobs table
        public void InsertJobListing(JobListing jobListing)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Job (CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " +
                           "VALUES (@CompanyID, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyID", jobListing.CompanyID);
            command.Parameters.AddWithValue("@JobTitle", jobListing.JobTitle);
            command.Parameters.AddWithValue("@JobDescription", jobListing.JobDescription);
            command.Parameters.AddWithValue("@JobLocation", jobListing.JobLocation);
            command.Parameters.AddWithValue("@Salary", jobListing.Salary);
            command.Parameters.AddWithValue("@JobType", jobListing.JobType);
            command.Parameters.AddWithValue("@PostedDate", jobListing.PostedDate);

            connection.Open();
            command.ExecuteNonQuery();
        }

        // Retrieve a list of all job listings
        public List<JobListing> GetJobListings()
        {
            var jobListings = new List<JobListing>();
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Job";
            using var command = new SqlCommand(query, connection);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                jobListings.Add(new JobListing
                {
                    JobID = reader.GetInt32(0),
                    CompanyID = reader.GetInt32(1),
                    JobTitle = reader.GetString(2),
                    JobDescription = reader.GetString(3),
                    JobLocation = reader.GetString(4),
                    Salary = reader.GetDecimal(5),
                    JobType = reader.GetString(6),
                    PostedDate = reader.GetDateTime(7)
                });
            }
            return jobListings;
        }
    }
}
