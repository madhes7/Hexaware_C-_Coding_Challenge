using CareerHub.Model;
using CareerHub.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Repositories
{
    internal class JobApplicationRepositories:IJobApplicationRepositories
    {
        private readonly string _connectionString;

        // Constructor to initialize the connection string
        public JobApplicationRepositories()
        {
            _connectionString = DBConnection.GetConnectionString();
        }
      public  void InsertJobApplication(JobApplication jobApplication)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Applications (JobID, ApplicantID, CoverLetter, ApplicationDate) " +
                           "VALUES (@JobID, @ApplicantID, @CoverLetter, @ApplicationDate)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@JobID", jobApplication.JobID);
            command.Parameters.AddWithValue("@ApplicantID", jobApplication.ApplicantID);
            command.Parameters.AddWithValue("@CoverLetter", jobApplication.CoverLetter);
            command.Parameters.AddWithValue("@ApplicationDate", jobApplication.ApplicationDate);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    }

