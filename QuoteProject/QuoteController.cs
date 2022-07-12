﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
/*using System.Data.Entity.Infrastructure;*/
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Domain;
using Repository;

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
        [ResponseType(typeof(Quote))]
        public IHttpActionResult GetTask(int id)
        {
            return Ok(quoteService.GetQuote(id));
        }

        // PUT: api/Quote/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Quote quote)
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
        [ResponseType(typeof(Quote))]
        public IHttpActionResult DeleteQuote(int id)
        {
            quoteService.DeleteQuote(id);

            return Ok();
        }

        /*        protected override void Dispose(bool disposing)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                    base.Dispose(disposing);
                }

                private bool TaskExists(int id)
                {
                    return db.Tasks.Count(e => e.QuoteId == id) > 0;
                }*/
    }
}