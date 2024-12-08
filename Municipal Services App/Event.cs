using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    // Code Attribution
    //Link: https://stackoverflow.com/questions/3150381/generic-linked-list
    //Author: StackOverflow

    public class Event
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly Time { get; set; }
        public string Description { get; set; }

        public string Venue { get; set; }

        public Event(string title, string category, DateTime date, TimeOnly time, string venue, string description)
        {
            Title = title;
            Category = category;
            Date = date;
            Time = time;
            Venue = venue;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Title} - {Date.ToShortDateString()}";
        }

        public string display()
        {
            return $"{Title}\n{Category}\n{Description}\n{Time}"; 
        }
    }
}
