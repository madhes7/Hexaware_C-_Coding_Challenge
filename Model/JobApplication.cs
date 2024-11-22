using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CareerHub.Model
{
    public class JobApplication
    {
        public  int ApplicationID { get; set; }
        public int JobID { get; set; }
        public  int ApplicantID { get; set; }
        public  DateTime ApplicationDate { get; set; }
        public  string CoverLetter { get; set; }

    }
}
