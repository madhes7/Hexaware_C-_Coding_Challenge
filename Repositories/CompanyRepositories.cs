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
    internal class CompanyRepositories:ICompanyRepositories
    {
        private readonly string _connectionString;

        
        public CompanyRepositories()
        {
            _connectionString = DBConnection.GetConnectionString();
        }

        
        public void PostJob(string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType, int companyID)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Job (CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " +
                           "VALUES (@CompanyID, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyID", companyID);
            command.Parameters.AddWithValue("@JobTitle", jobTitle);
            command.Parameters.AddWithValue("@JobDescription", jobDescription);
            command.Parameters.AddWithValue("@JobLocation", jobLocation);
            command.Parameters.AddWithValue("@Salary", salary);
            command.Parameters.AddWithValue("@JobType", jobType);
            command.Parameters.AddWithValue("@PostedDate", DateTime.Now);

            connection.Open();
            command.ExecuteNonQuery();
        }

        
        public List<JobListing> GetJobs(int companyID)
        {
            var jobs = new List<JobListing>();
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Job WHERE CompanyID = @CompanyID";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyID", companyID);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                jobs.Add(new JobListing
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
            return jobs;
        }
        // Insert a new company into the Companies table
        public void InsertCompany(Company company)
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "INSERT INTO Company (CompanyName, Location) " +
                           "VALUES (@CompanyName, @Location)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyName", company.Company_name);
            command.Parameters.AddWithValue("@Location", company.location);

            connection.Open();
            command.ExecuteNonQuery();
        }

        // Retrieve a list of all companies
        public List<Company> GetCompanies()
        {
            var companies = new List<Company>();
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Company";
            using var command = new SqlCommand(query, connection);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                companies.Add(new Company
                {
                    CompanyId = reader.GetInt32(0),
                    Company_name = reader.GetString(1),
                    location = reader.GetString(2)
                });
            }
            return companies;
        }
    }
}
