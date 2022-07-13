using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;

namespace Repository
{
    public interface IQuoteRepository
    {
        void Add(Quote quote);
        void Update(Quote quote);
        IEnumerable<Quote> GetAll();
        Quote Get(int id);
        bool Delete(Quote quote);
    }
}
