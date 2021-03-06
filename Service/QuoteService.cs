using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Repository;

namespace Service
{
    public class QuoteService : IQuoteService
    {
        private IQuoteRepository quoteRepository;

        public QuoteService(IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return quoteRepository.GetAll();
        }

        public Quote GetQuote(int id)
        {
            return quoteRepository.Get(id);
        }

        public void InsertQuote(Quote quote)
        {
            quoteRepository.Add(quote);
        }
        public void UpdateQuote(Quote quote)
        {
            quoteRepository.Update(quote);
        }

        public bool DeleteQuote(int id)
        {
            Quote quote = GetQuote(id);
            return quoteRepository.Delete(quote);
        }
    }
}