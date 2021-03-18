using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sovtechTest.Client.Models
{
    public class JokeResult
    {
        public string type { get; set; }
        public Value value { get; set; }
    }
    public class Value
    {
        public int id { get; set; }

        private string _joke;
        public string joke
        {
            get => _joke;
            set => _joke = value?.Replace("&quot;", "\"");
        }
    }
}
