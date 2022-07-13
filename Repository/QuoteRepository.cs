using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;

namespace Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly QuoteDBEntities _context;

        public QuoteRepository(QuoteDBEntities context)
        {
            _context = context;
        }

        public void Add(Quote quote)
        {
            if (quote == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Quotes.Add(quote);
            _context.SaveChanges();

        }

        public IEnumerable<Quote> GetAll()
        {
            return _context.Quotes.AsEnumerable();
        }

        public Quote Get(int id)
        {
            return _context.Quotes.SingleOrDefault(s => s.QuoteId == id);
        }

        public void Update(Quote quote)
        {
            if (quote == null)
            {
                throw new ArgumentNullException("entity");
            }
            Quote temp = Get(quote.QuoteId);
            temp.QuoteType = quote.QuoteType;
            temp.DueDate = quote.DueDate;
            temp.Task = quote.Task;
            temp.Contact = quote.Contact;
            temp.TaskType = quote.TaskType;
            _context.SaveChanges();
        }

        public void Delete(Quote quote)
        {
            if (quote == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Quotes.Remove(quote);
            _context.SaveChanges();
        }
    }
}
