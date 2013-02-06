using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Foodle.Client.Windows.FoodleServiceReference;

namespace Foodle.Client.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Options _voteOptions;

        private IEnumerable<Restaurant> OptionsOne
        {
            get { return _voteOptions.Restaurants.Where(t => t.VotePoints == 0 || t.VotePoints == 3); }
        }

        private IEnumerable<Restaurant> OptionsTwo
        {
            get { return _voteOptions.Restaurants.Where(t => t.VotePoints == 0 || t.VotePoints == 2); }
        }

        private IEnumerable<Restaurant> OptionsThree
        {
            get { return _voteOptions.Restaurants.Where(t => t.VotePoints == 0 || t.VotePoints == 1); }
        }

        private IEnumerable<Restaurant> ValidVotes
        {
            get { return _voteOptions.Restaurants.Where(t => t.VotePoints > 0).OrderByDescending(t => t.VotePoints); }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetRestaurantsButton_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new FoodleServiceClient())
            {
                var response = client.GetVoteOptions();
                _voteOptions = response.Options;
            }           

            ShowRestaurants();
  
        }

        private void ShowRestaurants()
        {
            //comboChoice1.DataContext = voteOptions;


            BindData();
            


            //foreach (var vo in voteOptions)
            //{
            //    var rd = new RowDefinition();
            //    grid1.RowDefinitions.Add(rd);
            //}
            //grid1.RowDefinitions.Add();
            //listBox1.Items.Clear();

            //foreach (var restaurant in voteOptions.Restaurants)
            //{
            //    listBox1.Items.Add(restaurant.Name);
            //}

            //MessageBox.Show(string.Format("Successfully added {0} restaurants to list", voteOptions.Restaurants.Count()));
        }

        private void BindData()
        {
            comboChoice1.ItemsSource = OptionsOne;
            comboChoice1.DisplayMemberPath = "Name";
            comboChoice2.ItemsSource = OptionsTwo;
            comboChoice2.DisplayMemberPath = "Name";
            comboChoice3.ItemsSource = OptionsThree;
            comboChoice3.DisplayMemberPath = "Name";
        }

        private void SetPoints(Restaurant restaurant, int points)
        {
            restaurant.VotePoints = points;
            BindData();
        }

        private void RemovePoints(Restaurant restaurant)
        {
            restaurant.VotePoints = 0;
            BindData();
        }

        private void ComboOne_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems != null && e.RemovedItems.Count == 1)
                RemovePoints(e.RemovedItems[0] as Restaurant);

            if (e.AddedItems != null && e.AddedItems.Count == 1)
                SetPoints(e.AddedItems[0] as Restaurant, 3);
        }

        private void ComboTwo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems != null && e.RemovedItems.Count == 1)
                RemovePoints(e.RemovedItems[0] as Restaurant);

            if (e.AddedItems != null && e.AddedItems.Count == 1)
                SetPoints(e.AddedItems[0] as Restaurant, 2);
        }

        private void ComboThree_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems != null && e.RemovedItems.Count == 1)
                RemovePoints(e.RemovedItems[0] as Restaurant);

            if (e.AddedItems != null && e.AddedItems.Count == 1)
                SetPoints(e.AddedItems[0] as Restaurant, 1);
        }

        private void SendVoteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_voteOptions == null)
                MessageBox.Show("Please get options first");
            else if (ValidVotes.Count() != 3)
                MessageBox.Show("Select three items");
            else
            {
                var client = new FoodleServiceClient();
                var request = new SaveVoteRequest
                    {
                        Vote = new Vote
                            {
                                Prio1 = ValidVotes.ElementAt(0),
                                Prio2 = ValidVotes.ElementAt(1),
                                Prio3 = ValidVotes.ElementAt(2)
                            }
                    };

                var resp = client.SubmitVote(request);
                GetResults(string.Format("Your vote has been {0}.", resp.Status));
            }
            
        }

        private void GetResults(string statusInformation)
        {
            var msgBuilder = new StringBuilder();
            using (var client = new FoodleServiceClient())
            {
                var response = client.GetResults();
                var results = response.Results;
                if (!results.Items.Any())
                { 
                    msgBuilder.AppendLine("No votes yet"); 
                }
                else
                {
                    msgBuilder.AppendLine(string.Format("[1] -> {0} ({1} votes)", results.Items[0].Prio1.Name, results.Items[0].Prio1.Points));
                    msgBuilder.AppendLine(string.Format("[2] -> {0} ({1} votes)", results.Items[0].Prio2.Name, results.Items[0].Prio2.Points));
                    msgBuilder.AppendLine(string.Format("[3] -> {0} ({1} votes)", results.Items[0].Prio3.Name, results.Items[0].Prio3.Points));
                }
            }

            if (!string.IsNullOrEmpty(statusInformation))
            {
                msgBuilder.AppendLine();
                msgBuilder.AppendLine(statusInformation);
            }

            contentControl1.Content = msgBuilder.ToString();
        }

        private void GetResultsButton_Click(object sender, RoutedEventArgs e)
        {
            GetResults(string.Empty);
        }
    }
}
