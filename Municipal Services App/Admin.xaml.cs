using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    // Link: https://www.reddit.com/r/dotnet/comments/ijdiwa/download_file_saved_as_byte_array/?rdt=37005
    // Author: Auth0Dev

    public partial class Admin : Window
    {
        private string username = "Admin";
        private string password = "Admin";
       
        public Admin()
        {
            InitializeComponent();
            CustomLinkedList<Issue> issueList = ReportIssues.getLinkedList();
            if (!(issueList.Count() <= 0 )) // check that items in linked list
            {
                dgReports.ItemsSource = issueList.GetList(); // add list items to data grid
                pnlDisplay.Visibility = Visibility.Hidden;
            }
           else
            {
                MessageBox.Show("Currently no reported issues", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
        }

        private void ViewDocument_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            byte[] docBytes = button.Tag as byte[];

            if (docBytes != null) // if file was attached >>> file not null
            {
                string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "tempfile.pdf");
                File.WriteAllBytes(tempPath, docBytes);
                docViewer.Navigate(tempPath);
            }
            else
            {
                MessageBox.Show("No attached document for report", "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Show error message >> no doc was attached
            }
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // get usr intput from window
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            if (user != null && pass != null)
            {
                if (user.Equals(username) && pass.Equals(password)) { pnlDisplay.Visibility = Visibility.Visible; return; } // show pnl withreported issue details
                else
                {
                    txtUsername.Clear();
                    txtPassword.Clear();
                    MessageBox.Show("Incorrect username or password. Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Username and Password must be filled in", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


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
        private void Request_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequests request = new ServiceRequests();
            request.Show();
            this.Close();
        }
    }
}
