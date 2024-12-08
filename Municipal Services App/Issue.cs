using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    public class Issue
    {
        public string location {  get; set; }
        public string category { get; set; }

        public string description { get; set; }

        public byte[] attachedFile { get; set; }

        public string status { get; set; }

        public DateTime reportDate { get; set; }
        // add status

        public Issue(string location, string category, string description, byte[] attachedFile, string status, DateTime reportDate) 
        { 
            this.location = location;
            this.category = category;
            this.description = description;
            this.attachedFile = attachedFile;
            this.status = status;
            this.reportDate = reportDate;
        }
    }
}
