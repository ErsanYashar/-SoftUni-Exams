using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public interface IValidator
    {
       ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidatePlayer(PlayerCreateForm model);
    }
}
