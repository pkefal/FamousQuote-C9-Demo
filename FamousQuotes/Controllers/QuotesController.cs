using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.Http;
using FamousQuotes.Models;
using Swashbuckle.Swagger.Annotations;

namespace FamousQuotes.Controllers
{
    [RoutePrefix("quotes")]
    public class QuotesController : ApiController
    {
        private readonly List<Quote> _quotes;
        public QuotesController()
        {
            _quotes = new List<Quote>()
            {
                new Quote() { Author = "Thomas A. Edison", Text = "I have not failed. I’ve just found 10,000 ways that won’t work."},
                new Quote() { Author = "Mahatma Gandhi", Text = "Live as if you were to die tomorrow. Learn as if you were to live forever."},
                new Quote() { Author = "Albert Einstein", Text = "You have to learn the rules of the game. And then you have to play better than anyone else."},
                new Quote() { Author = "Ayn Rand", Text = "The question isn’t who is going to let me; it’s who is going to stop me."},
                new Quote() { Author = "Julius Caesar", Text = "I came, I saw, I conquered."},
                new Quote() { Author = "Albert Einstein", Text = "If you can't explain it simply, you don't understand it well enough."}
            };
        }
        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Quote>> Get()
        {
            return await Task.FromResult(_quotes);
        }
        [HttpGet]
        [Route("author/{author}")]
        public async Task<IEnumerable<Quote>> GetQuotesByAuthor(string author)
        {
            return await Task.FromResult(_quotes.Where(a => a.Author.ToLowerInvariant().Contains(author.ToLowerInvariant())));
        }
        [HttpGet]
        [Route("random")]
        public async Task<Quote> GetRandomQuote()
        {
            return await Task.FromResult(_quotes[new Random().Next(0, _quotes.Count)]);
        }
    }
}
