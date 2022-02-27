using FootballManager.Data;
using FootballManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class PlayersService : IPlayersService
    {

        private readonly FootballManagerDbContext data;

        public PlayersService(FootballManagerDbContext data)
        {
            this.data = data;
        }
        public void AddToCollection(string playerId, string userId)
        {
            var user = data.Users
                .FirstOrDefault(u => u.Id == userId);
            var player = data.Players
                .FirstOrDefault(t => t.Id == playerId);



            if (user == null || player == null)
            {
                throw new ArgumentException("User not found");
            }

            player.UserPlayers.Add(new UserPlayer()
            {
                PlayerId = playerId,
                Player = player,
                User = user,
                UserId = userId
            });

            data.SaveChanges();
        }
    }
}
