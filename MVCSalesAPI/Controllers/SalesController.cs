using MVCSalesAPI.Models;
using MVCSalesAPI.ViewModels;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MVCSalesAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SalesController : ApiController
    {
        private ApplicationBdContext db = new ApplicationBdContext();

        // GET: api/Sales
        public IQueryable<Sales> GetSales()
        {
            return db.Sales;
        }

        // GET: api/SearchSales
        public IQueryable<Sales> GetSearchSales(string query)
        {
            return db.Sales.Where(s => s.FOLIO_NUMBER.Contains(query));
        }


        // GET: api/Sales/5
        [ResponseType(typeof(Sales))]
        public IHttpActionResult GetSales(string id)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }

            SalesViewModel vm = new SalesViewModel
            {
                FOLIO_NUMBER = sales.FOLIO_NUMBER,
                SALE_DATE = sales.SALE_DATE.ToShortDateString(),
                SALE_AMOUNT = sales.SALE_AMOUNT.ToString()

            };

            return Ok(vm);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSales(string id, SalesViewModel sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sales.FOLIO_NUMBER)
            {
                return BadRequest();
            }

            Sales obj = db.Sales.Find(id);

            obj.SALE_AMOUNT = Double.Parse(sales.SALE_AMOUNT);
            obj.SALE_DATE = sales.GET_SALE_DATE();



            db.Entry(obj).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sales
        [ResponseType(typeof(Sales))]
        public IHttpActionResult PostSales(SalesViewModel sales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obj = new Sales
            {
                FOLIO_NUMBER = sales.FOLIO_NUMBER,
                SALE_DATE = sales.GET_SALE_DATE(),
                SALE_AMOUNT = Double.Parse(sales.SALE_AMOUNT)
            };

            db.Sales.Add(obj);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SalesExists(sales.FOLIO_NUMBER))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sales.FOLIO_NUMBER }, sales);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sales))]
        public IHttpActionResult DeleteSales(string id)
        {
            Sales sales = db.Sales.Find(id);
            if (sales == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sales);
            db.SaveChanges();

            return Ok(sales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesExists(string id)
        {
            return db.Sales.Count(e => e.FOLIO_NUMBER == id) > 0;
        }
    }
}