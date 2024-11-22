﻿using System;
using System.IO;

namespace CareerHub.Exceptions
{
    // File Upload Exception Handling
    public class FileUploadException : Exception
    {
        public FileUploadException(string message) : base(message) { }
    }

    // Application Deadline Handling
    public class ApplicationDeadlineException : Exception
    {
        public ApplicationDeadlineException(string message) : base(message) { }
    }

    public class JobApplicationHandler
    {
        public static void CheckApplicationDeadline(DateTime deadline)
        {
            if (DateTime.Now > deadline)
            {
                throw new ApplicationDeadlineException("The job application deadline has passed. Applications are no longer accepted.");
            }
            else
            {
                Console.WriteLine("You can apply for this job.");
            }
        }
    }

    // Database Connection Handling
    public class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException(string message) : base(message) { }
    }

    public class DatabaseHandler
    {
        public static void ConnectToDatabase(string connectionString)
        {
            try
            {
                // Simulating database connection attempt
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new DatabaseConnectionException("Database connection string is empty. Please provide a valid connection string.");
                }

                // Simulating a failed connection attempt
                bool connectionSuccess = false;
                if (!connectionSuccess)
                {
                    throw new DatabaseConnectionException("Failed to connect to the database. Please check the connection settings.");
                }

                Console.WriteLine("Database connection successful.");
            }
            catch (DatabaseConnectionException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}