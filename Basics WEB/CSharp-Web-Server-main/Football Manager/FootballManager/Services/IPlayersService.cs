using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public interface IPlayersService
    {
        void AddToCollection(string playerId, string userId);
    }
}
