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

namespace PROG7321_POE
{
    // Code Attribution
    // Author: GeeksForGeeks
    // Link:https://www.geeksforgeeks.org/introduction-to-avl-tree/
    // Author: Stack Overflow
    // Link: https://stackoverflow.com/questions/7532882/is-there-any-graph-data-structure-implemented-for-c-sharp
    // Author: Stack Overflow
    // Link: https://stackoverflow.com/questions/2231796/heap-class-in-net
    public partial class ServiceRequests : Window
    {
        private int selectedRequestId;
        public CustomHeap<Status> heap = new CustomHeap<Status>(); // create custom heap using status class
        public static CustomGraph<Status> graph = new CustomGraph<Status>(); // create custom graph using status class
        public static CustomAVLTree<Request> tree = new CustomAVLTree<Request>();// create custom tree using request class
        public CustomHashSet<string> categories; // creating custom hash set to keep track of different categories

        public List<Status> statusList;

        public ServiceRequests()
        {
            InitializeComponent();
            AddRequests();
        }

        public void AddRequests()
        {
            categories = new CustomHashSet<string>();

            // create status objects
            Status s1 = new Status(1, "Fix Electricity", "In Progress", 75, 1, "Electricity"); categories.Add(s1.category);
            Status s2 = new Status(2, "Fix Street Light", "Pending", 0, 4, "Electricity"); categories.Add(s2.category);
            Status s3 = new Status(3, "Road Maintenance", "Pending", 0, 5, "Infrastructure"); categories.Add(s3.category);
            Status s4 = new Status(4, "Fix Pot Hole", "In progress", 50, 2, "Infrastructure"); categories.Add(s4.category);
            Status s5 = new Status(5, "Fix Flood Damage", "In progress", 90, 1, "Infrastructure"); categories.Add(s5.category);
            Status s6 = new Status(6, "Fix Water Leekage", "Recieved", 25, 2, "Water"); categories.Add(s6.category);
            Status s7 = new Status(7, "Pick up waste", "Pending", 10, 4, "Waste Management"); categories.Add(s7.category);
            Status s8 = new Status(8, "Fix Street Light", "Pending", 10, 4, "Electricity"); categories.Add(s8.category);
            Status s9 = new Status(9, "Fix Bridge", "Done", 100, 1, "Infrastructure"); categories.Add(s9.category);
            Status s10 = new Status(10, "Clean Up Area", "Pending", 5, 5, "Sanitation"); categories.Add(s10.category);

            // add to heap and graph 
            HeapNode<Status> h1 = new HeapNode<Status>(s1, s1.priority); heap.Insert(h1); graph.AddNode(s1);
            HeapNode<Status> h2 = new HeapNode<Status>(s2, s2.priority); heap.Insert(h2); graph.AddNode(s2);
            HeapNode<Status> h3 = new HeapNode<Status>(s3, s3.priority); heap.Insert(h3); graph.AddNode(s3);
            HeapNode<Status> h4 = new HeapNode<Status>(s4, s4.priority); heap.Insert(h4); graph.AddNode(s4);
            HeapNode<Status> h5 = new HeapNode<Status>(s5, s5.priority); heap.Insert(h5); graph.AddNode(s5);
            HeapNode<Status> h6 = new HeapNode<Status>(s6, s6.priority); heap.Insert(h6); graph.AddNode(s6);
            HeapNode<Status> h7 = new HeapNode<Status>(s7, s7.priority); heap.Insert(h7); graph.AddNode(s7);
            HeapNode<Status> h8 = new HeapNode<Status>(s8, s8.priority); heap.Insert(h8); graph.AddNode(s8);
            HeapNode<Status> h9 = new HeapNode<Status>(s9, s9.priority); heap.Insert(h9); graph.AddNode(s9);
            HeapNode<Status> h10 = new HeapNode<Status>(s10,s10.priority); heap.Insert(h10); graph.AddNode(s10);

            // add dependancies
            graph.AddDependancy(s1, s2);
            graph.AddDependancy(s4, s3);
            graph.AddDependancy(s5, s3);
            graph.AddDependancy(s5, s4);
            graph.AddDependancy(s5, s6);
            graph.AddDependancy(s7, s10);
            graph.AddDependancy(s9, s3);
            graph.AddDependancy(s9, s4);
            graph.AddDependancy(s9, s5);
           
            // create request objects and add to tree
            Request r1 = new Request(1, "Fix Electricity", "No electricity", "Electricity", "Durban North"); tree.Insert(r1);
            Request r2 = new Request(2, "Fix Street Light", "No Power", "Electricity", "Durban North"); tree.Insert(r2);
            Request r3 = new Request(3, "Road Maintenance", "Maintain road, fix any inperfections and pot holes", "Infrastructure", "Central Durban"); tree.Insert(r3);
            Request r4 = new Request(4, "Fix Pot Hole", "Fix huge pot hole in center of road","Infrastructure", "Malvern"); tree.Insert(r4);
            Request r5 = new Request(5, "Fix Flood Damage", "Massive damage to infrastructure, roads and houses due to recent storm",  "Infrastructure", "Overport"); tree.Insert(r5);
            Request r6 = new Request(6, "Fix Water Leekage", "Water Hydrant leeking onto street, wasting water", "Water", "Queensburgh"); tree.Insert(r6);
            Request r7 = new Request(7, "Pick up waste", "Waste bins not picked up for several weeks now", "Waste Management", "Phenix"); tree.Insert(r7);
            Request r8 = new Request(8, "Fix Street Light", "Street light not working on main road", "Electricity", "Chatsworth"); tree.Insert(r8);
            Request r9 = new Request(9, "Fix Bridge", "Bridge completely colapsing, unable to cross", "Infrastructure", "Toti"); tree.Insert(r9);
            Request r10 = new Request(10, "Clean Up Area", "Waste thrown on side of the road","Sanitation", "Durban North"); tree.Insert(r10);

            statusList = heap.GetList();
            RequestListView.ItemsSource = statusList;// add heap items to list view

            cmbCategory.ItemsSource = categories.toList();
        }

        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the selected Servic eRequest ID for the button selected 
            if (sender is Button button && button.DataContext is Status selectedRequest)
            {
                selectedRequestId = selectedRequest.ID;
                RequestDetails details = new RequestDetails(selectedRequestId, graph, tree);
                details.Show();

                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void SearchEvents(object sender, RoutedEventArgs e)
        {
            string? searchCategory = null;
            var selectedCategory = cmbCategory.SelectedItem; // Get selected item from combo box 
            if (selectedCategory != null)
            { searchCategory = selectedCategory.ToString();}

            string? idS = txtID.Text;
            string? request = txtRequest.Text;

            if (!string.IsNullOrEmpty(idS))
            {
                if (int.TryParse(idS, out int id)) // Safely parse the ID
                { displayIDSearch(id); resetComponents(); }
                else
                { MessageBox.Show("ID could not be found, please try again :)", "Error", MessageBoxButton.OK, MessageBoxImage.Warning); }
            }
            else if (string.IsNullOrEmpty(idS) && !string.IsNullOrEmpty(request) && string.IsNullOrEmpty(searchCategory))
            { displayRequestSearch(request); resetComponents(); }
            else if (string.IsNullOrEmpty(idS) && string.IsNullOrEmpty(request) && !string.IsNullOrEmpty(searchCategory))
            { displayCateegorySearch(searchCategory); resetComponents(); }
            else if (string.IsNullOrEmpty(idS) && !string.IsNullOrEmpty(request) && !string.IsNullOrEmpty(searchCategory))
            { displayCatReqSearch(searchCategory, request); resetComponents(); }
           
        }

        public void displayCatReqSearch(string searchCategory, string request)
        {
            var list = statusList.Where(s => s.category.Equals(searchCategory) && s.title.Contains(request, StringComparison.OrdinalIgnoreCase)).ToList();
            RequestListView.ItemsSource = list;

        }

        public void displayCateegorySearch(string cateegorySearch)
        {
            var list = statusList.Where(s => s.category.Equals(cateegorySearch)).ToList();
            RequestListView.ItemsSource = list;

        }

        private void displayRequestSearch(string request)
        {
            var matchingStatuses = statusList
            .Where(s => s.title.Contains(request, StringComparison.OrdinalIgnoreCase))
            .ToList();

            if (matchingStatuses.Any())
            { RequestListView.ItemsSource = matchingStatuses; }
            else
            {
                RequestListView.ItemsSource = null;
                MessageBox.Show($"No results found for '{request}'.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void displayIDSearch(int id)
        {
            var item = statusList.FirstOrDefault(r => r.ID == id);

            if (item != null)
            { RequestListView.ItemsSource = new List<Status> { item }; }
            else
            {
                RequestListView.ItemsSource = null;
                MessageBox.Show($"No results found for ID {id}.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        public void resetComponents()
        {
            // reset search components onvce search complete
            cmbCategory.Text = string.Empty;
            txtID.Text = "";
            txtRequest.Text = "";
        }

        private void ResetEvents(object sender, RoutedEventArgs e)
        {
            RequestListView.ItemsSource = statusList;
            resetComponents();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void Events_Click(object sender, RoutedEventArgs e)
        {
            EventsandAnnouncements events = new EventsandAnnouncements();
            events.Show();
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
