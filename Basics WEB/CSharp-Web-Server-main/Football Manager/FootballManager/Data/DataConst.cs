using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Data.Models
{
    public class DataConst
    {
        public const int UserNameMaxLength = 20;
        public const int UserNameMinLength = 5;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //public const string UserTypeClient = "Client";
       // public const string UserTypeMechanic = "Mechanic";

        public const int UserEmailMaxLength = 60;
        public const int UserEmailMinLength = 10;


        public const int UserEmailMaxPassword = 64;
        public const int UserEmailMinPassword = 5;


        public const int PlayerFullNameMaxLength = 80;
        public const int PlayerFullNameMinLength = 5;

      //  public const string CarPlateNumberRegularExpression = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const int PositionMinlength = 5;
        public const int PositionMaxlength = 20;

        public const int SpeedMaxLength = 10;
        public const int SpeedMinLength = 0;

        public const int EnduranceMaxLength = 10;
        public const int EnduranceMinLength = 0;

        public const int DescriptionMaxLength = 200;



        public const int IssueMinDescription = 5;
    }
}
