using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace PROG7321_POE
{
    // Code Attribution
    // Author: GeeksForGeeks
    // Link:https://www.geeksforgeeks.org/introduction-to-avl-tree/
    // Author: Stack Overflow
    // Link: https://stackoverflow.com/questions/7532882/is-there-any-graph-data-structure-implemented-for-c-sharp
    // Author: Stack Overflow
    // Link: https://stackoverflow.com/questions/2231796/heap-class-in-net

    public partial class RequestDetails : Window
    {
        private CustomAVLTree<Request> tree;
        private CustomGraph<Status> graph;
        private Request selectedRequest;

        // pass data structire and id as parameters 
        public RequestDetails(int id, CustomGraph<Status> graph, CustomAVLTree<Request> tree)
        {
            InitializeComponent();
            this.tree = tree;
            this.graph = graph;

            // Retrieve the selected request from the AVL Tree by ID
            List<Request> requests = tree.getList();
            selectedRequest = requests.FirstOrDefault(r => r.ID == id); // get data for selected id
     
            List<Status> status = graph.getList();
            Status selectedStatus = status.FirstOrDefault(r => r.ID == id); // get status for selected id

            List<Status> dependants = graph.GetDependants(selectedStatus); // get all dependancies for selected id 
            DataContext = selectedRequest;

            // Display the dependent requests
            DependentRequestsListBox.ItemsSource = dependants;
        }

        private void ViewDetailsButton_Click(object sender, RoutedEventArgs e)
        {
           
            // redirect to new window using new id
            if (sender is Button button && button.DataContext is Status selectedDependent)
            {
                int dependentRequestId = selectedDependent.ID;
                RequestDetails dependentRequestDetails = new RequestDetails(dependentRequestId, graph, tree);
               
                dependentRequestDetails.Show();
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequests requests = new ServiceRequests();
           
            requests.Show();
            this.Close();

        }
    }
}
