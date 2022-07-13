using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;

namespace Service
{
    public interface IQuoteService
    {
        IEnumerable<Quote> GetQuotes();
        Quote GetQuote(int id);
        void InsertQuote(Quote quote);
        void UpdateQuote(Quote quote);
        void DeleteQuote(int id);
    }
}
