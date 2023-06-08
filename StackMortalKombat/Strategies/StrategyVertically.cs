using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.Strategies;

internal class StrategyVertically : IStrategy
{
    public StrategyVertically()
    {
    }

    public void MakeTurn(List<Unit> army1, List<Unit> army2)
    {
        for (int i = 0; i < army1.Count; i++)
        {
            if (i >= army2.Count)
            {
                return;
            }
            army1.ElementAt(i).TakeTurn(army2.ElementAt(i));
        }

        for (int i = 0; i < army2.Count; i++)
        {
            if (army2.ElementAt(i).IsAlive)
            {
                if (i >= army1.Count)
                {
                    return;
                }
                army1.ElementAt(i).TakeDamage(army2.ElementAt(i).Damage);
            }
        }
    }

    public void UseSpecialAbility(List<Unit> army1, List<Unit> army2)
    {
        throw new NotImplementedException();
    }
}
