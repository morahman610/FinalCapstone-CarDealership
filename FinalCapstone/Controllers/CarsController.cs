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
using FinalCapstone.Models;

namespace FinalCapstone.Controllers
{
    public class CarsController : ApiController
    {
        private CarEntities db = new CarEntities();

        // GET: api/Cars
        public IQueryable<Car> GetCars()
        {
            return db.Cars;
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpGet]
        public List<Car> GetCarByMake(string id)
        {
            List<Car> car = db.Cars.ToList();
            if (car == null)
            {
                return null;
            }
            else
            {
                 car = (from b in db.Cars
                            where b.Make.Contains(id)
                            select b).ToList();
                return car;
            }
        }

        [HttpGet]
        public List<Car> GetCarByModel(string id)
        {
            List<Car> car = db.Cars.ToList();
            if (car == null)
            {
                return null;
            }
            else
            {
                car = (from b in db.Cars
                       where b.Model.Contains(id)
                       select b).ToList();
                return car;
            }
        }

        [HttpGet]
        public List<Car> GetCarByColor(string id)
        {
            List<Car> car = db.Cars.ToList();
            if (car == null)
            {
                return null;
            }
            else
            {
                car = (from b in db.Cars
                       where b.Color.Contains(id)
                       select b).ToList();
                return car;
            }
        }

        [HttpGet]
        public List<Car> GetCarByYear(int id)
        {
            List<Car> car = db.Cars.ToList();
            if (car == null)
            {
                return null;
            }
            else
            {
                car = (from b in db.Cars
                       where b.Year == id
                       select b).ToList();
                return car;
            }
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.ID)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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



        // POST: api/Cars
        [ResponseType(typeof(Car))]
        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.ID }, car);
        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.ID == id) > 0;
        }
    }
}