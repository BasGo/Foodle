using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodle.Service.Model
{
    public class Result
    {
        public string Date { get; set; }
        public List<Restaurant> Votes { get; set; }
    }
}