namespace ArmyOfCreatures.Extended.Creatures
{
    using System;

    using Logic.Creatures;
    using Specialties;

    public class CyclopsKing : Creature
    {
        public const int CyclopsKingAttack = 17;
        public const int CyclopsKingDefense = 13;
        public const int CyclopsKingHealth = 70;
        public const decimal CyclopsKingDamage = 18;
        public const int AttackBonus = 3;
        public const int DoubleAttackRounds = 4;
        public const int DoubleDamageRounds = 1;

        public CyclopsKing()
            : base(CyclopsKing.CyclopsKingAttack, CyclopsKing.CyclopsKingDefense, CyclopsKing.CyclopsKingHealth, CyclopsKing.CyclopsKingDamage)
        {
            base.AddSpecialty(new AddAttackWhenSkip(CyclopsKing.AttackBonus));
            base.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKing.DoubleAttackRounds));
            base.AddSpecialty(new DoubleDamage(CyclopsKing.DoubleDamageRounds));
        }
    }
}