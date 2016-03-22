namespace ArmyOfCreatures.Extended.Creatures
{
    using System;

    using Logic.Creatures;
    using Logic.Specialties;

    public class Griffin : Creature
    {
        public const int GriffinAttack = 8;
        public const int GriffinDefense = 8;
        public const int GriffinHealth = 25;
        public const decimal GriffinDamage = 4.5M;
        public const int DoubleDefenseRounds = 5;
        public const int SkipDefenseBonus = 3;

        public Griffin()
            : base(Griffin.GriffinAttack, Griffin.GriffinDefense, Griffin.GriffinHealth, Griffin.GriffinDamage)
        {
            base.AddSpecialty(new DoubleDefenseWhenDefending(Griffin.DoubleDefenseRounds));
            base.AddSpecialty(new AddDefenseWhenSkip(Griffin.SkipDefenseBonus));
            base.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}