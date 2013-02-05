using System;
using System.Collections.Generic;
using System.Linq;
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
using Foodle.Client.Windows.FoodleServiceReference;

namespace Foodle.Client.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var client = new FoodleServiceClient();

            var voteOptions = client.GetVoteOptions();

            ShowRestaurants(voteOptions);

            //var vote = new Vote
            //{
            //    Prio1 = result.Restaurants[0],
            //    Prio2 = result.Restaurants[1],
            //    Prio3 = result.Restaurants[2]
            //};

            //var submitted = client.SubmitVote(vote);

            //var res = client.GetResults();

            //Console.WriteLine();
        }

        private void ShowRestaurants(VoteOptions voteOptions)
        {
            listBox1.Items.Clear();

            foreach (var restaurant in voteOptions.Restaurants)
            {
                listBox1.Items.Add(restaurant.Name);
            }

            MessageBox.Show(string.Format("Successfully added {0} restaurants to list", voteOptions.Restaurants.Count()));
        }
    }
}
