using System;
using System.Collections.Generic;
using System.Text;

namespace FinalsProject
{
    class Currency
    {
        public double amount { get; set; }
        public string @base { get; set; }
        public string date { get; set; }
        public Dictionary<string,string> rates { get; set; }

    }
}
