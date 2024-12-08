using System;

namespace PROG7321_POE
{
    public class Request : IComparable<Request>
    {
        // request services information 
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }

        public Request(int id, string title, string description, string category, string location)
        {
            ID = id;
            Title = title;
            Description = description;
            Category = category;
            Location = location;
        }

        public int CompareTo(Request other)
        {
            // compare requests to each other >> used for AVL tree
            if (other == null) return 1;
            return ID.CompareTo(other.ID);
        }

        public override string ToString()
        {
            return $"Request ID: {ID}, Title: {Title}, Category: {Category}, Location: {Location}";
        }
    }
}
