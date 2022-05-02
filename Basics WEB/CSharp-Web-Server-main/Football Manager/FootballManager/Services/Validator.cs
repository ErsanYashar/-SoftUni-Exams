using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static FootballManager.Data.Models.DataConst;
namespace FootballManager.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidatePlayer(PlayerCreateForm model)
        {
            var errors = new List<string>();

            if (model.FullName.Length < PlayerFullNameMinLength || model.FullName.Length > PlayerFullNameMaxLength)
            {
                errors.Add($"FullName '{model.FullName}' is not valid. It must be between {PlayerFullNameMinLength} and {PlayerFullNameMaxLength} characters long.");
            }

            if (model.Position.Length < PositionMinlength || model.Position.Length > PositionMaxlength)
            {
                errors.Add($"Position '{model.Position}' is not valid. It must be between {PositionMinlength} and {PositionMaxlength} characters long.");
            }

            if (model.Speed < SpeedMinLength || model.Speed > SpeedMaxLength)
            {
                errors.Add($"Speed '{model.Speed}' is not valid. It must be between {SpeedMinLength} and {SpeedMaxLength} characters long.");
            }

            if (model.Endurance < EnduranceMinLength || model.Endurance > EnduranceMaxLength)
            {
                errors.Add($"Endurance '{model.Endurance}' is not valid. It must be between {EnduranceMinLength} and {EnduranceMaxLength} characters long.");
            }

            if (model.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description '{model.Description} is not valid {DescriptionMaxLength} characters long.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserNameMinLength || model.Username.Length > UserNameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserNameMinLength} and {UserNameMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserEmailMinPassword || model.Password.Length > UserEmailMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserEmailMinPassword} and {UserEmailMaxLength} characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
