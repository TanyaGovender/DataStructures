using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    public class Status
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string status { get; set; } // track status of requests

        public string category { get; set; }

        public int progress { get; set; } // track progres of request

        public int priority { get; set; }

        public Status(int ID, string title, string status, int progress, int priority , string category) 
        { 
            this.ID = ID;
            this.title = title;
            this.status = status;
            this.progress = progress;
            this.priority = priority;
            this.category = category;
        }
    }
}
