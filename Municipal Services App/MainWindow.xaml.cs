using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG7321_POE
{
    
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            ReportIssues issue = new ReportIssues();
            issue.Show();
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