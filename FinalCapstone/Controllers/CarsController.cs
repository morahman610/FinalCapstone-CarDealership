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
        public List<Car> GetCars()
        {
            List<Car> car = db.Cars.ToList();
            if (car == null)
            {
                return null;
            }
            else
            {
                car = (from b in db.Cars
                       select b).ToList();
                return car;
            }
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

        [ResponseType(typeof(Car))]
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

        [ResponseType(typeof(Car))]
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


        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCarByAll(string make, string model, int? year, string color)
        {
            //if (string.IsNullOrEmpty(color))
            //{
            //    throw new ArgumentException("message", nameof(color));
            //}

            //if (string.IsNullOrEmpty(model))
            //{
            //    throw new ArgumentException("message", nameof(model));
            //}

            //if (string.IsNullOrEmpty(make))
            //{
            //    throw new ArgumentException("message", nameof(make));
            //}

            List<Car> cars = (from c in db.Cars
                              select c).ToList();
            if (make != "" && make != null)
            {
                cars = (from c in cars
                        where c.Make.Contains(make)
                        select c
                        ).ToList();
            }
            if (model != "" && model != null)
            {
                cars = (from c in cars
                        where c.Model.Contains(model)
                        select c).ToList();
            }
            if (year != 0)
            {
                cars = (from c in cars
                        where c.Year == year
                        select c).ToList();
            }
            if (color != "" && color != null)
            {
                cars = (from c in cars
                        where c.Color.Contains(color)
                        select c).ToList();
            }

            return Ok(cars);
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