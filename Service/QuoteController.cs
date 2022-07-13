using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL.Models;

namespace Service
{
    public class QuoteController : ApiController
    {
        private readonly IQuoteService quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            this.quoteService = quoteService;
        }

        // GET: api/Quote
        public IQueryable<Quote> GetQuotes()
        {
            return quoteService.GetQuotes().AsQueryable<Quote>();
        }

        // GET: api/Quote/5
        [Authorize]
        [ResponseType(typeof(Quote))]
        public IHttpActionResult GetQuote(int id)
        {
            return Ok(quoteService.GetQuote(id));
        }

        // PUT: api/Quote/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuote(int id, Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quote.QuoteId)
            {
                return BadRequest();
            }

            quoteService.UpdateQuote(quote);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Quote
        [Authorize]
        [ResponseType(typeof(Quote))]
        public IHttpActionResult PostQuote(Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            quoteService.InsertQuote(quote);

            return CreatedAtRoute("DefaultApi", new { id = quote.QuoteId }, quote);
        }

        // DELETE: api/Quote/5
        [Authorize]
        [ResponseType(typeof(Quote))]
        public IHttpActionResult DeleteQuote(int id)
        {
            if (quoteService.DeleteQuote(id))
            {
                return Ok("Deleted");
            } else
            {
                return BadRequest("Quote id not found");
            }

            
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuoteExists(int id)
        {
            return db.Quotes.Count(e => e.QuoteId == id) > 0;
        }*/
    }
}