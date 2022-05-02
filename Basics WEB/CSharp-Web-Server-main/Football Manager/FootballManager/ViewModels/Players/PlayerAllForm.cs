﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.ViewModels.Players
{
    public class PlayerAllForm
    {
        public string Id { get; set; }
        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        public string Position { get; set; }

        public byte Speed { get; set; }

        public byte Endurance { get; set; }

    }
}
