namespace ArmyOfCreatures.Extended.Specialties
{
    using System;

    using Logic.Battles;
    using Logic.Specialties;

    public class AddAttackWhenSkip : Specialty
    {
        private int attackToAdd;

        public AddAttackWhenSkip(int attackToAdd)
        {
            this.AttackToAdd = attackToAdd;
        }

        public int AttackToAdd
        {
            get
            {
                return this.attackToAdd;
            }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("AttackToAdd", "AttackToAdd must be between 1 and 10.");
                }

                this.attackToAdd = value;
            }
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.AttackToAdd;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", base.ToString(), this.AttackToAdd);
        }
    }
}