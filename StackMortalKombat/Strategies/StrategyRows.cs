using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.Strategies
{
    internal class StrategyRows : IStrategy
    {
        public StrategyRows()
        {
        }

        public void MakeTurn(List<AbstractUnit> army1, List<AbstractUnit> army2)
        {
            for (int i = 1; i < 4; i++)
            {
                army1.ElementAt(army1.Count - i).TakeTurn(army2.ElementAt(army2.Count - i));
            }

            for (int i = 1; i < 4; i++)
            {
                if (army2.ElementAt(army2.Count - i).IsAlive)
                    army1.ElementAt(army2.Count - i).TakeDamage(army2.ElementAt(army1.Count - i).Damage);
            }

        }

        public void UseSpecialAbility(List<AbstractUnit> army1, List<AbstractUnit> army2)
        {
            throw new NotImplementedException();
        }


    }
}
