using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamousQuotesConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FamousQuotes();
            var quotes = client.Quotes.Get();

            quotes.ToList().ForEach(q => Console.WriteLine(q.Text + " -- " + q.Author));
            Console.ReadLine();
        }
    }
}
