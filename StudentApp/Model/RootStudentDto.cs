using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Model
{
   
        public class Data
        {
            public int id { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string last_name { get; set; }
            public string date_of_birth { get; set; }
        }

        public class RootStudentDto
        {
            public string status { get; set; }
            public Data data { get; set; }
        }

    }

