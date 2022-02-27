using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static FootballManager.Data.Models.DataConst;
using System.Threading.Tasks;

namespace FootballManager.Data.Models
{
    public class Player
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(PlayerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(PositionMaxlength)]
        public string Position { get; set; }

        [Required]
        [Range(SpeedMinLength, SpeedMaxLength)]
        public byte Speed { get; set; }

        [Required]
        [Range(EnduranceMinLength, EnduranceMaxLength)]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new List<UserPlayer>();
    }
}
