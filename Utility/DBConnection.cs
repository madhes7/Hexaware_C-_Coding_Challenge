using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Utility
{
    internal class DBConnection
    {

        //private static IConfiguration _iconfiguration;

        //static DBConnection()
        //{
        //    GetAppSettingsFile();
        //}


        //private static void GetAppSettingsFile()
        //{
        //    var builder = new ConfigurationBuilder()
        //                .SetBasePath(Directory.GetCurrentDirectory())
        //                .AddJsonFile("appsettings.json");
        //    _iconfiguration = builder.Build();
        //}
        private static readonly string con = "Server=DESKTOP-BAHKPDL;Database=careerhub;Trusted_Connection=True";

            public static string GetConnectionString()
            {
            return con;
            }


        }
    }


