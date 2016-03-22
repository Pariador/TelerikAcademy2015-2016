namespace ArmyOfCreatures.Extended.Specialties
{
    using System;

    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rounds", "Rounds must be greater than 0.");
                }

                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
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
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.rounds--;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", base.ToString(), this.Rounds);
        }
    }
}