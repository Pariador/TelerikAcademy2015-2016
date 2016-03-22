namespace ArmyOfCreatures.Extended.Specialties
{
    using System;

    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleDamage : Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }

        private int Rounds
        {
            get
            {
                return this.rounds;
            }
            set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Rounds", "Rounds must be between 1 and 10.");
                }

                this.rounds = value;
            }
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                return 0.00M;
            }

            this.rounds--;
            return currentDamage * 2;
        }
        public override string ToString()
        {
            return string.Format("{0}({1})", base.ToString(), this.Rounds);
        }
    }
}