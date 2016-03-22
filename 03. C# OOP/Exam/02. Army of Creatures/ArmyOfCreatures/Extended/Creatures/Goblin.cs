namespace ArmyOfCreatures.Extended.Creatures
{
    using System;

    using Logic.Creatures;

    public class Goblin : Creature
    {
        public const int GoblinAttack = 4;
        public const int GoblinDefense = 2;
        public const int GoblinHealth = 5;
        public const decimal GoblinDamage = 1.5M;

        public Goblin()
            : base(Goblin.GoblinAttack, Goblin.GoblinDefense, Goblin.GoblinHealth, Goblin.GoblinDamage)
        {
            ;
        }
    }
}