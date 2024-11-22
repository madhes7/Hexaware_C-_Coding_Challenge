using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CareerHub.Model
{
    public class Applicant
    {
     
        public int ApplicantID { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public string Email { get; set; }
        public  string Phone { get; set; }
        public  string Resume { get; set; }

    }
}
