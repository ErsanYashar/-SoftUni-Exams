using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FootballManager.Data.Models.DataConst;

namespace FootballManager.Data.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(UserEmailMaxPassword)]
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new List<UserPlayer>();


    }
}
