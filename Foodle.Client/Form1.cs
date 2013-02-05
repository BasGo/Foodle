using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Foodle.Client.FoodleServiceReference;

namespace Foodle.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new FoodleServiceClient();

            var result = client.GetVoteOptions();

            var vote = new Vote
                {
                    Prio1 = result.Restaurants[0],
                    Prio2 = result.Restaurants[1],
                    Prio3 = result.Restaurants[2]
                };

            var submitted = client.SubmitVote(vote);

            var res = client.GetResults();

            Console.WriteLine();
        }
    }
}
