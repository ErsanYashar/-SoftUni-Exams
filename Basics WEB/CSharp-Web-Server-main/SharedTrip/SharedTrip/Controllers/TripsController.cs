using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.Trips;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController: Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;
        private readonly ITripsService tripsService;

        public TripsController(ApplicationDbContext data, IValidator validator,
            ITripsService tripsService )
        {
            this.data = data;
            this.validator = validator;
            this.tripsService = tripsService;
        }



        [Authorize]
        public HttpResponse Add() => View();


        [HttpPost]
        [Authorize]
        public HttpResponse Add(TripCreateForm model) 
        {
            //if (!this.data.Users.Any(r => r.Id == model.Id))
            //{
            //    return NotFound();
            //}

            var modelErrors = this.validator.ValidateTrips(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = model.DepartureTime,
                ImagePath = model.CarImage,
                Seats = model.Seats,
                Description = model.Description,
            };

            this.data.Trips.Add(trip);
            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }


        [Authorize]
        public HttpResponse All()
        {
            var trip = data.Trips
                .Select(t => new TipsAllForm
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    Seats = t.Seats,
                    Description=t.Description,
                    
                }).ToList();
               

            if (trip == null)
            {
                return BadRequest();
            }
             return View(trip);

        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var tripDet = this.data.Trips
                .Where(x => x.Id == tripId)
                .Select(t => new TripDetailModel
                {
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime,
                    Seats = t.Seats,
                    Description = t.Description,
                    Id = t.Id,
                    ImagePath = t.ImagePath,    
                })
                .FirstOrDefault();

            if (tripDet == null)
            {
                return BadRequest();
            }


            return View(tripDet);

        }

        //[Authorize]
        //public HttpResponse AddUserToTrip(string id)
        //{

        //}

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            try 
            {
                tripsService.AddUserToTrip(tripId, this.User.Id);
            }
            catch (Exception aex)
            {
                return Error(aex.Message);
            }

            return Redirect("/Trips/All");
        }

    }
}
