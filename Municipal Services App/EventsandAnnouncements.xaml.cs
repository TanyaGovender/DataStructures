using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PROG7321_POE
{

    // Code Attribution
    // Author: Stack overflow
    // Link: https://stackoverflow.com/questions/12507191/an-efficient-way-to-implement-a-custom-generic-list-queue-stack-combination

    public partial class EventsandAnnouncements : Window
    {
        public EventsandAnnouncements()
        {
            InitializeComponent();
            // add hard coded events to dictionary 
            addEvents();
            // retrieve events from dictionary and display in item control
            displayEvents();
            // add pre generated recomendation on start up >>> since no searches have been made yet 
            firstRecomendation();
        }

        public CustomDictionary<DateTime, Event> events;
        // use date as key for dictionary >>> will store unique dates and a queue of all events that occur on that day
        public CustomHashSet<string> categories;
        // hash set used to store unique categories 
        public CustomStack<Event> searchHistory;
        // stack used to store search history >> since most recent searches at top of stack >> top 5 most recent searches are used to make recommendation
       
        public void addEvents()
        {
            events = new CustomDictionary<DateTime, Event>();
            categories = new CustomHashSet<string>();
            searchHistory = new CustomStack<Event>();

            Event event1 = new Event("Community Cleanup", "Environment", DateTime.Today.AddDays(1), new TimeOnly(10, 30), "Durban Beach Front", "Join the community in a cleanup the event at the Durban Beach front.");
            Event event2 = new Event("Political Rally", "Political", DateTime.Today.AddDays(1), new TimeOnly(12, 00), "Durban ICC", "ANC Political Rally");
            Event event3 = new Event("Food Festival", "Culture", DateTime.Today.AddDays(5), new TimeOnly(10, 00), "Florida Road", "Enjoy local food and music. Indulge in South African Heritage.");
            Event event4 = new Event("Community feeding", "Outreach", DateTime.Today.AddDays(2), new TimeOnly(10, 30), "Youth Centre", "Join the community in providing hot meals in our outreach program at the youth centre.");
            Event event5 = new Event("Music concert", "Entertainment", DateTime.Today.AddDays(4), new TimeOnly(20, 00), "Durban Beach Front", "Enjoy a fun filled night of culture and music. Experience local bands preform live.");
            Event event6 = new Event("Heritage Celebration ", "Culture", DateTime.Today.AddDays(10), new TimeOnly(10, 00), "Nelson Mandela Stadium", "Enjoy South African heritage and experience different cultures at the nelson mandela stadium. Experience different foods, music, clothing and many more");

            // method to check that there are no conflicting events on the same day at the same time and at the same venue 
             // >> if no conflicting events then event is added to dictionary and category is added to set
            checkSchedule(event1, getPriority(event1.Category));
            checkSchedule(event2, getPriority(event2.Category));
            checkSchedule(event3, getPriority(event3.Category));
            checkSchedule(event4, getPriority(event4.Category));
            checkSchedule(event5, getPriority(event5.Category));
            checkSchedule(event6, getPriority(event6.Category));

            // load unique categories from set to combo box >> to optomise search function for user
            cmbCategory.ItemsSource = categories.toList();
        }

        public int getPriority(string Category) 
        {
            int priority = 0; // if event does not fall into any of the following categories >> new unique category >> it has a priority of 0
            if (Category == "Culture") { priority = 1; }
            else if (Category == "Environment") { priority = 2; }
            else if (Category == "Outreach") { priority = 3; }
            else if (Category == "Municipal Services") { priority = 4; }
            else if (Category == "Political") { priority = 5; }
            else if (Category == "Protesting") { priority = 6; } // highest priority 
            return priority;
        }

        public void displayEvents()
        {
            // load all events from dictionary into window based on key value pairs 
            EventsList.ItemsSource = events.GetKeyValuePairs()
           .Select(kvp => new { Key = kvp.Key.ToShortDateString(), Value = kvp.Value.toList() })
           .ToList();
        }

        public void firstRecomendation()
        {
            //Before user searches >> make pre loaded recomendation
            var firstKey = events.Keys().First();
            var firstQueue = events.getQueue(firstKey);
            Event firstEvent = firstQueue.Peek(); // get the first event >> with the highesr priority>> on the earliest date >>> first key 
            List<Event> firstrec = new List<Event>();
            firstrec.Add(firstEvent);
            DisplayRecomendation(firstrec);
        }

        public void checkSchedule(Event newEvent, int priority)
        {
            DateTime date = newEvent.Date; // date of new event to be added 
            if (events.ContainsKey(date)) { // if there are already events on this day

                TimeOnly time = newEvent.Time; // time of new event
                string venue = newEvent.Venue; // venue of new event 
                CustomQueue<Event> eE = events.getQueue(date);
                var existingEvents = eE.toList();

                for (int i = 0; i < existingEvents.Count(); i++) // check all existing events in the queue for this date 
                {
                   if (existingEvents[i].Venue.Equals(venue) && existingEvents[i].Time.Equals(time))
                    { throw new Exception("Can not have 2 events on the same day, at the same time and at the same event."); }
                   else
                    {
                        events.Add(date, newEvent, priority);// different venue or different time
                        categories.Add(newEvent.Category);
                    }
                }
            } // if no events already on this day >> unique event doesnt conflict
            else { events.Add(date, newEvent, priority); categories.Add(newEvent.Category); }// not on same date as any other events 
        }

        private void ResetEvents(object sender, RoutedEventArgs e)
        { displayEvents(); } // reset display to show all events again

        private void SearchEvents(object sender, RoutedEventArgs e)
        {
            string searchCategory = null; 
            var selectedCategory = cmbCategory.SelectedItem; // get selected item from combo box 
            if (selectedCategory != null) // only if somethng is selected
            {
                searchCategory = selectedCategory.ToString();
            }

            DateTime? startDate = startPicker.SelectedDate; // get start date
            DateTime? endDate = endPicker.SelectedDate; // get end date 



            if (startDate != null && endDate == null && searchCategory == null) // start date only 
            { displayStartDateSearch(startDate); resetComponents(); }
            else if ( startDate == null && endDate == null && searchCategory !=null) // category only 
            { displayCategorySearch(searchCategory); resetComponents(); }
            else if (startDate == null && endDate != null && searchCategory == null) //end date nlu
            { displayEndDateSearch(endDate); resetComponents(); }
            else if (startDate != null && endDate == null && searchCategory != null) // cat and s date
            { displayCategoryStartDate(searchCategory, startDate); resetComponents(); }
            else if (startDate == null && endDate != null && searchCategory != null) // cat and e date 
            { displayCategoryEndDate(searchCategory, endDate); resetComponents(); }
            else if (startDate != null && endDate != null && searchCategory == null) // s date and e date 
            { displayDateSearch(startDate, endDate); resetComponents(); }
            else if (startDate != null && endDate != null && searchCategory != null) // all 3
            { displayDateCategorySearch(searchCategory, startDate, endDate); resetComponents(); }

        }

        public void resetComponents()
        {
            // reset search components onvce search complete
            cmbCategory.Text = string.Empty;
            startPicker.Text = string.Empty;
            endPicker.Text = string.Empty;
        }
        public void displayDateCategorySearch(string searchCategory, DateTime? startDate, DateTime? endDate)
        {
           
            var filteredEvents = events.GetKeyValuePairs().Where(kvp => kvp.Key >= startDate && kvp.Key <= endDate) // events within starting date and end date
        .Select(kvp => new
        {
            Key = kvp.Key.ToShortDateString(),
            Value = kvp.Value.toList().Where(e => e.Category == searchCategory).ToList() // only events in the selected category
        })
        .Where(entry => entry.Value.Count > 0).ToList();

        EventsList.ItemsSource = filteredEvents; // add list to xaml 

        foreach (var entry in filteredEvents)
        {
         List<Event> entries = entry.Value.ToList();// get list of events for all search results 
         foreach(var e in entries) {searchHistory.Push(e);  }// add all events (in search results) to stack >> keeps track of search history 
        }
            var mostSearchedEvent = searchHistory.Analyze();// method in stack >>> analyses all stack elements >> all searches >> and returns most common 
            makeRecommendation(mostSearchedEvent);
        }

        public void makeRecommendation(Event mostSearchedEvent)
        {
          var relatedCategories = new Dictionary<string, List<string>> // create dictonary to store related categories 
          //>> eg. if culture selected get rec from culture and outreach
            {
                 { "Culture", new List<string> { "Culture", "Outreach" } },
                 { "Environment", new List<string> { "Environment", "Municipal Services" } },
                 { "Outreach", new List<string> { "Outreach", "Culture" } },
                 { "Municipal Services", new List<string> { "Municipal Services", "Environment" } },
                 { "Political", new List<string> { "Political", "Protesting" } },
                 { "Protesting", new List<string> { "Protesting", "Political" } }
            };

            string mainCategory = mostSearchedEvent.Category;
            List<string> categoriesToConsider = relatedCategories.ContainsKey(mainCategory)? relatedCategories[mainCategory]: new List<string> { mainCategory };
            List<Event> reclist = new List<Event>(); // create list to store recomendations

            DateTime searchDate = mostSearchedEvent.Date;
            DateTime startDate = searchDate.AddDays(-3); //get events 3 days before most searched event
            DateTime endDate = searchDate.AddDays(3);// get events 3 days after most searched event

            // Get events that match the date range and belong to the relevant categories
            var filteredEvents = events.GetKeyValuePairs()
                .Where(kvp => kvp.Key >= startDate && kvp.Key <= endDate) // Events within the date range
                .Select(kvp => new
                { Key = kvp.Key.ToShortDateString(),
                  Value = kvp.Value.toList().Where(e => categoriesToConsider.Contains(e.Category)) // Adjusted from previous rec algorithm >> Events in the relevant categories
                        .ToList()
                }).Where(entry => entry.Value.Count > 0).ToList();

            foreach (var entry in filteredEvents)
            {
                List<Event> entries = entry.Value.ToList(); // Get list of events for all search results
                foreach (var e in entries)
                { reclist.Add(e); } // Add all events to the recommendation list
            }
            // Display the recommendations
            DisplayRecomendation(reclist);
        }


        private void DisplayRecomendation(List<Event> recomendations)
        {
            RecommendationList.ItemsSource = recomendations;
        }
        public void displayCategorySearch(string searchCategory)
        {
            var filteredEvents = events.GetKeyValuePairs()
          .Where(kvp => kvp.Value.toList().Any(e => e.Category == searchCategory)) // Only include events in the selected catwgory 
          .Select(kvp => new { Key = kvp.Key.ToShortDateString(), Value = kvp.Value.toList().Where(e => e.Category == searchCategory).ToList() })
          .ToList();

            EventsList.ItemsSource = filteredEvents; // add list to xaml 

            foreach (var entry in filteredEvents)
            {
                List<Event> entries = entry.Value.ToList();// get list of events for all search results 
                foreach (var e in entries) { searchHistory.Push(e); }// add all events (in search results) to stack >> keeps track of search history 
            }
            var mostSearchedEvent = searchHistory.Analyze();// method in stack >>> analyses all stack elements >> all searches >> and returns most common 
            makeRecommendation(mostSearchedEvent);
        }

        public void displayDateSearch(DateTime? startDate, DateTime? endDate)
        {
            var filteredEvents = events.GetKeyValuePairs()
       .Where(kvp => kvp.Key >= startDate.Value && kvp.Key <= endDate.Value) // show events between start date and end datw >> include both
       .Select(kvp => new { Key = kvp.Key.ToShortDateString(), Value = kvp.Value.toList() })
       .ToList();

            EventsList.ItemsSource = filteredEvents; // add list to xaml 

            foreach (var entry in filteredEvents)
            {
                List<Event> entries = entry.Value.ToList();// get list of events for all search results 
                foreach (var e in entries) { searchHistory.Push(e); }// add all events (in search results) to stack >> keeps track of search history 
            }
            var mostSearchedEvent = searchHistory.Analyze();// method in stack >>> analyses all stack elements >> all searches >> and returns most common 
            makeRecommendation(mostSearchedEvent);
        }

        public void displayStartDateSearch(DateTime? searchDate)
        {
            var filteredEvents = events.GetKeyValuePairs()
         .Where(kvp => kvp.Key >= searchDate.Value) // only events that happen after start date
         .Select(kvp => new { Key = kvp.Key.ToShortDateString(), Value = kvp.Value.toList() })
         .ToList();

            EventsList.ItemsSource = filteredEvents; // add list to xaml 

            foreach (var entry in filteredEvents)
            {
                List<Event> entries = entry.Value.ToList();// get list of events for all search results 
                foreach (var e in entries) { searchHistory.Push(e); }// add all events (in search results) to stack >> keeps track of search history 
            }
            var mostSearchedEvent = searchHistory.Analyze();// method in stack >>> analyses all stack elements >> all searches >> and returns most common 
            makeRecommendation(mostSearchedEvent);// display recomendation
        }

        public void displayEndDateSearch(DateTime? searchDate)
        {
            var filteredEvents = events.GetKeyValuePairs()
            .Where(kvp => kvp.Key <= searchDate.Value) // only events that happenbefore end date
            .Select(kvp => new { Key = kvp.Key.ToShortDateString(), Value = kvp.Value.toList() })
            .ToList();

            EventsList.ItemsSource = filteredEvents; // add list to xaml 

            foreach (var entry in filteredEvents)
            {
                List<Event> entries = entry.Value.ToList();// get list of events for all search results 
                foreach (var e in entries) { searchHistory.Push(e); }// add all events (in search results) to stack >> keeps track of search history 
            }
            var mostSearchedEvent = searchHistory.Analyze();// method in stack >>> analyses all stack elements >> all searches >> and returns most common 
            makeRecommendation(mostSearchedEvent);// display recomendation
        }

        public void displayCategoryStartDate(string searchCategory, DateTime? searchDate)
        {
            var filteredEvents = events.GetKeyValuePairs().Where(kvp => kvp.Key >= searchDate) // only events that happenbefore end date
            .Where(kvp => kvp.Value.toList().Any(e => e.Category == searchCategory)) // only include events in this catefory 
            .Select(kvp => new
            {
                Key = kvp.Key.ToShortDateString(),
                Value = kvp.Value.toList().Where(e => e.Category == searchCategory).ToList()
            }).ToList();

            EventsList.ItemsSource = filteredEvents; // add list to xaml 

            foreach (var entry in filteredEvents)
            {
                List<Event> entries = entry.Value.ToList();// get list of events for all search results 
                foreach (var e in entries) { searchHistory.Push(e); }// add all events (in search results) to stack >> keeps track of search history 
            }
            var mostSearchedEvent = searchHistory.Analyze();// method in stack >>> analyses all stack elements >> all searches >> and returns most common 
            makeRecommendation(mostSearchedEvent); // display recomendation
        }

        public void displayCategoryEndDate(string searchCategory, DateTime? searchDate)
        {
            var filteredEvents = events.GetKeyValuePairs()
           .Where(kvp => kvp.Key <= searchDate).Where(kvp => kvp.Value.toList().Any(e => e.Category == searchCategory)) 
           .Select(kvp => new
           {
               Key = kvp.Key.ToShortDateString(),
               Value = kvp.Value.toList().Where(e => e.Category == searchCategory).ToList()
           })
           .ToList();

            EventsList.ItemsSource = filteredEvents; // add list to xaml 

            foreach (var entry in filteredEvents)
            {
                List<Event> entries = entry.Value.ToList();// get list of events for all search results 
                foreach (var e in entries) { searchHistory.Push(e); }// add all events (in search results) to stack >> keeps track of search history 
            }
            var mostSearchedEvent = searchHistory.Analyze();// method in stack >>> analyses all stack elements >> all searches >> and returns most common 
            makeRecommendation(mostSearchedEvent); // display recomendation
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void Request_Click(object sender, RoutedEventArgs e)
        {
           ServiceRequests serviceRequests = new ServiceRequests();
            serviceRequests.Show();
            this.Close();
        }
        private void Issues_Click(object sender, RoutedEventArgs e)
        {
            ReportIssues issues = new ReportIssues();
            issues.Show();
            this.Close();
        }
        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
