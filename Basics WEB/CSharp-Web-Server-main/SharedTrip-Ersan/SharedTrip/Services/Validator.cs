namespace SharedTrip.Services
{
    using SharedTrip.Models;
    using SharedTrip.Models.Trips;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using static Data.DataConst;


    public class Validator : IValidator
    {
      

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {5} and {20} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add($"The provided password is not valid. It must be between {6} and {20} characters long.");
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

        //public ICollection<string> ValidateRepository(CreateRepositoryFormModel model)
        //{
        //    var errors = new List<string>();

        //    if (model.Name.Length < RepositoryMinName || model.Name.Length > RepositoryMaxName)
        //    {
        //        errors.Add($"Repository '{model.Name}' is not valid. It must be between {RepositoryMinName} and {RepositoryMinName} characters long.");
        //    }

        //    if (model.RepositoryType != RepositoryPublicType && model.RepositoryType != RepositoryPrivateType)
        //    {
        //        errors.Add($"Repository type can be either '{RepositoryPublicType}' or '{RepositoryPrivateType}'.");
        //    }

        //    return errors;
        //}


        public ICollection<string> ValidateTrips(TripCreateForm model)
        {
            var error = new List<string>();

            if (model.Seats < 2 || model.Seats > 6)
            {
                error.Add($"Trrips is not valid. It must be between 2 and 6");
            }

            if (model.Description.Length > 80)
            {
                error.Add("To long");
            }

            return error;   
        }
    }
}
