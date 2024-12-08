using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROG7321_POE
{
    // Code Attribution
    // Link: https://www.tutorialspoint.com/chash-program-to-read-and-write-a-byte-array-to-file-using-filestream-class
    //Author: TutorialsPoint

    public partial class ReportIssues : Window
    {
        private int progressValue = 0;
        // bool variables to check that all fields are filled in 
        private bool isLocationFilled = false;
        private bool isCategorySelected = false;
        private bool isDescriptionFilled = false;
        private bool isFileAttached = false;

        public byte[] attachedFileBytes;

        public static CustomLinkedList<Issue> issueList = new CustomLinkedList<Issue>(); 
        // create instace >> static >> of custom doubly linked list to stor all reported issues

        public static CustomLinkedList<Issue> getLinkedList()
        {
            return issueList;
        }
       
        public ReportIssues()
        {
            InitializeComponent();
            lblThankYou.Content = null; // only show label after form is filled
            string[] categories = {"Sanitation","Water", "Electricity", "Infrastructure", "Environmental" };

            foreach (string category in categories)
            {
                cmbCategory.Items.Add(category);// add categories to combo box
            }
        }

        private void OnInputChanged(object sender, RoutedEventArgs e)
        { UpdateProgressBar();}// call method any time changes are made to text box, rich text edit or cobo box

        private void UpdateProgressBar()
        {
            int totalFields = 4;// num fields required
            int filledFields = 0;// num fields filled

            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) { isLocationFilled = true; filledFields++; }
            if(cmbCategory.SelectedItem != null) { isCategorySelected = true; filledFields++; }
            if(!string.IsNullOrWhiteSpace(new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text.Trim()))
            { isDescriptionFilled = true; filledFields++; }
            if (isFileAttached) filledFields++;

            progressValue = (filledFields * 100) / totalFields; // val in progress bar = num filed fields converted to %
            ProgressBar.Value = progressValue;

            if (progressValue == 100) // once progress bar is 100 show submit button and thank you label
            { btnSubmit.IsEnabled = true ; lblThankYou.Content = "Thank you for reporting issues and helping improve our municipality :)" ; }
            else if (isLocationFilled && isCategorySelected && isDescriptionFilled) { btnSubmit.IsEnabled = true; }
            // allow users to submit if all fields except attached file is filled >>> attached doc not compulsory for submisson
           
        }
       

        private void btnAttachment_Click(object sender, RoutedEventArgs e) 
        {
           // open file dialog to allow user to select file from device
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a File to Attach", // only attach certain file types >> images / pdfs 
                Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|Document files (*.pdf, *.docx)|*.pdf;*.docx"

            };

            if (openFileDialog.ShowDialog() == true) 
            {
                attachedFileBytes= File.ReadAllBytes(openFileDialog.FileName); // store doc as byte array
                    
                isFileAttached = true;
                UpdateProgressBar();
                // success message 
                MessageBox.Show("File successfully attached :)", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
           
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // submit button only available once all fields are filled in>> or all fields except attached doc

             string location = txtLocation.Text;
             string category = cmbCategory.Text;
             string description = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text;
             string status = "reported"; // status of all reported issues until changed by admin
             DateTime reportDate = DateTime.Now;// current date and time

            if (!(isLocationFilled && isCategorySelected && isDescriptionFilled))
            { // check that all field filled
                MessageBox.Show("All Field must be filled in before submitting", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }

           // create new issue >> call issue class
            Issue newIssueReport = new Issue(location, category, description, attachedFileBytes, status, reportDate);
            issueList.insertLast(newIssueReport); // add new issue to custom doubly linked list 
           
            //success message >> user feedback
            MessageBox.Show("Issue successfully reported to municipality :)", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
           
            // open rating window >> user engagement stratgy >> customer feedback form
            Rating ratingWindow = new Rating();
            ratingWindow.Show();
            this.Close();

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
        private void Request_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequests request = new ServiceRequests();
            request.Show();
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

