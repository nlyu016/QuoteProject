using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Repository
{
    public interface IQuoteRepository
    {
        void Add(Quote quote);
        void Update(Quote quote);
        IEnumerable<Quote> GetAll();
        Quote Get(int id);
        void Delete(Quote task);
    }
}
