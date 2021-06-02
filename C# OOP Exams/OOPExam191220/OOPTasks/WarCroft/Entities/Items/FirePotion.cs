﻿
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion:Item
    {
        private const int DefaultWeight = 5;
        private const int DefaultHealthDecrease = 20;

        public FirePotion()
            : base(DefaultWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= DefaultHealthDecrease;
            if (character.Health<=0)
            {
                character.IsAlive=false;
                character.Health = 0;
            }
        }
    }
}
