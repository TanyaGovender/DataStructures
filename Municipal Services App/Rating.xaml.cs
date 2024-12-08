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
    //Link: https://www.google.co.za/search?q=how+to+create+a+ratng+sysem+in+wpf&sca_esv=cc60acfe50cff9ff&hl=en&sxsrf=ADLYWIJgLOtM5s0ac4VfzlQW6PBAOmf4jA%3A1725908812768&source=hp&ei=TEffZpW5LfWEhbIP1JKvuQU&iflsig=AL9hbdgAAAAAZt9VXAVBcRY_i4syVuNyGjLWNObr76Nv&ved=0ahUKEwiVj8utx7aIAxV1QkEAHVTJK1cQ4dUDCA0&uact=5&oq=how+to+create+a+ratng+sysem+in+wpf&gs_lp=Egdnd3Mtd2l6IiJob3cgdG8gY3JlYXRlIGEgcmF0bmcgc3lzZW0gaW4gd3BmMgcQIRigARgKMgcQIRigARgKSKBjUIoDWO1dcAF4AJABAJgByAOgAfJZqgEJMi0xMS4xOC41uAEDyAEA-AEBmAIjoALrW6gCCsICBxAjGCcY6gLCAg0QLhjRAxjHARgnGOoCwgIEECMYJ8ICCxAAGIAEGJECGIoFwgIREC4YgAQYsQMY0QMYgwEYxwHCAgsQABiABBixAxiDAcICBRAAGIAEwgIOEAAYgAQYsQMYgwEYigXCAggQABiABBixA8ICChAAGIAEGEMYigXCAgsQABiABBixAxiKBcICChAjGIAEGCcYigXCAgUQIRigAcICBxAAGIAEGA3CAggQABgNGB4YD8ICBhAAGBYYHsICCBAAGIAEGKIEwgIIEAAYFhgeGA_CAgsQABiABBiGAxiKBZgDHZIHCjEuMC45LjIwLjWgB6W1Ag&sclient=gws-wiz#fpstate=ive&vld=cid:1ae932df,vid:V0gccjef5_E,st:0
    //Author: Aarica Aadien

    public partial class Rating : Window
    {
        private int rating = 0;

        // images saved as resources in project >>> can use same file path for all users 
        private string blueStar = "pack://application:,,,/Images/BlueStar.png"; // path to blue star >> selected star / filled in star
        private string whiteStar = "pack://application:,,,/Images/WhiteStar.png"; // path to white / empty star

        public static CustomLinkedList<Feedback> userFeedback = new CustomLinkedList<Feedback>();
        // create custom doubly linked list to store user feedback

        public Rating()
        {
            InitializeComponent();
        }

        private void btnStar1_Click(object sender, RoutedEventArgs e)
        { imgStar1.Source = new BitmapImage(new Uri(blueStar));
          imgStar2.Source = new BitmapImage(new Uri(whiteStar));
          imgStar3.Source = new BitmapImage(new Uri(whiteStar));
          imgStar4.Source = new BitmapImage(new Uri(whiteStar));
          imgStar5.Source = new BitmapImage(new Uri(whiteStar));
          rating = 1; // if only 1 star selected >> colour 1 blue and leave 4 empty 
        }

        private void btnStar2_Click(object sender, RoutedEventArgs e)
        { 
            imgStar1.Source = new BitmapImage(new Uri(blueStar));
            imgStar2.Source = new BitmapImage(new Uri(blueStar));
            imgStar3.Source = new BitmapImage(new Uri(whiteStar));
            imgStar4.Source = new BitmapImage(new Uri(whiteStar));
            imgStar5.Source = new BitmapImage(new Uri(whiteStar));
            rating = 2; // if only 2 star selected >> colour 2 blue and leave 3 empty 
        }
        private void btnStar3_Click(object sender, RoutedEventArgs e)
        { 
            imgStar1.Source = new BitmapImage(new Uri(blueStar));
            imgStar2.Source = new BitmapImage(new Uri(blueStar));
            imgStar3.Source = new BitmapImage(new Uri(blueStar));
            imgStar4.Source = new BitmapImage(new Uri(whiteStar));
            imgStar5.Source = new BitmapImage(new Uri(whiteStar));
            rating = 3; // if only 3 star selected >> colour 3 blue and leave 2 empty 
        }
        private void btnStar4_Click(object sender, RoutedEventArgs e)
        {
            imgStar1.Source = new BitmapImage(new Uri(blueStar));
            imgStar2.Source = new BitmapImage(new Uri(blueStar));
            imgStar3.Source = new BitmapImage(new Uri(blueStar)); 
            imgStar4.Source = new BitmapImage(new Uri(blueStar));
            imgStar5.Source = new BitmapImage(new Uri(whiteStar));
            rating = 4; // if only 4 star selected >> colour 4 blue and leave 1 empty 
        }
        private void btnStar5_Click(object sender, RoutedEventArgs e)
        {
            imgStar1.Source = new BitmapImage(new Uri(blueStar));
            imgStar2.Source = new BitmapImage(new Uri(blueStar));
            imgStar3.Source = new BitmapImage(new Uri(blueStar));
            imgStar4.Source = new BitmapImage(new Uri(blueStar));
            imgStar5.Source = new BitmapImage(new Uri(blueStar));
            rating = 5; // if 5 stars selected >> colour all blue :)
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string likes = txtLiked.Text;
            string dislikes = txtDisliked.Text;
            string improve = txtImprove.Text;

            if (likes.Equals(null) || dislikes.Equals(null) ||  improve.Equals(null)) // make sure all fields filled in
            {
                MessageBox.Show("All Field must be filled in before submitting", "Error", MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            else
            {
                Feedback newFeedback = new Feedback(rating, likes, dislikes, improve);
                // create new feedback object 
                userFeedback.insertLast(newFeedback); // add new feedback to linked list

                MessageBox.Show("Thank you for your feedback:)", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // success message 

                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
           

        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
    }

