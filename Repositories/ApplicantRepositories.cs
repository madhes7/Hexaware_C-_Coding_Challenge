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
    internal class ApplicantRepositories:IApplicantRepositories
    {
        private readonly string _connectionString;

        // Constructor to initialize the connection string
        public ApplicantRepositories()
        {
            _connectionString = DBConnection.GetConnectionString();
        }

        // Create a new applicant profile
        public void CreateProfile(string email, string firstName, string lastName, string phone)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Applicant (Email, FirstName, LastName, Phone) " +
                           "VALUES (@Email, @FirstName, @LastName, @Phone)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Phone", phone);

            connection.Open();
            command.ExecuteNonQuery();
        }

        // Apply for a job by inserting a new job application
        public void ApplyForJob(int jobID, int applicantID, string coverLetter)
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

        public void InsertApplicant(Applicant applicant)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Applicant (FirstName, LastName, Email, Phone, Resume) " +
                           "VALUES (@FirstName, @LastName, @Email, @Phone, @Resume)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", applicant.FirstName);
            command.Parameters.AddWithValue("@LastName", applicant.LastName);
            command.Parameters.AddWithValue("@Email", applicant.Email);
            command.Parameters.AddWithValue("@Phone", applicant.Phone);
            command.Parameters.AddWithValue("@Resume", applicant.Resume);

            connection.Open();
            command.ExecuteNonQuery();
        }

        // Retrieve a list of all applicants
        public List<Applicant> GetApplicants()
        {
            var applicants = new List<Applicant>();
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Applicant";
            using var command = new SqlCommand(query, connection);

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
    }
}
