namespace ArmyOfCreatures.Extended.Creatures
{
    using System;

    using Logic.Creatures;
    using Specialties;

    public class WolfRaider : Creature
    {
        public const int WolfRiderAttack = 8;
        public const int WolfRiderDefense = 5;
        public const int WolfRiderHealth = 10;
        public const decimal WolfRiderDamage = 3.5M;
        public const int DoubleDamageRounds = 7;

        public WolfRaider()
            : base(WolfRaider.WolfRiderAttack, WolfRaider.WolfRiderDefense, WolfRaider.WolfRiderHealth, WolfRaider.WolfRiderDamage)
        {
            base.AddSpecialty(new DoubleDamage(WolfRaider.DoubleDamageRounds));
        }
    }
}