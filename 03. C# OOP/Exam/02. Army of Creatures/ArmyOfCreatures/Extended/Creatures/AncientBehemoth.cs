namespace ArmyOfCreatures.Extended.Creatures
{
    using System;

    using Logic.Creatures;
    using Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        public const int AncientBehemothAttack = 19;
        public const int AncientBehemothDefense = 19;
        public const int AncientBehemothHealth = 300;
        public const decimal AncientBehemothDamage = 40;
        public const int DefenseReductionPercentage = 80;
        public const int DoubleDefenseRounds = 5;

        public AncientBehemoth()
            : base(AncientBehemoth.AncientBehemothAttack, AncientBehemoth.AncientBehemothDefense,
                    AncientBehemoth.AncientBehemothHealth, AncientBehemoth.AncientBehemothDamage)
        {
            base.AddSpecialty(new ReduceEnemyDefenseByPercentage(AncientBehemoth.DefenseReductionPercentage));
            base.AddSpecialty(new DoubleDefenseWhenDefending(AncientBehemoth.DoubleDefenseRounds));
        }
    }
}