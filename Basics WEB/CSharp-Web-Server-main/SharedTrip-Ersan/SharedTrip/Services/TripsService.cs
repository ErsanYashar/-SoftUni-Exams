using SharedTrip.Data;
using SharedTrip.Data.Models;
using System;
using System.Linq;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext data;

        public TripsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var user = data.Users
                .FirstOrDefault(u => u.Id == userId);
            var trip = data.Trips
                .FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                throw new ArgumentException("User or trip not found");
            }

            user.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                Trip = trip,
                User = user,
                UserId = userId
            });

            data.SaveChanges();
        }
    }
}
