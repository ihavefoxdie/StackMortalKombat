using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.Strategies;

public class StrategyVertically : IStrategy
{
    public StrategyVertically()
    {
    }

    private uint GetArmyCost(List<AbstractUnit> army)
    {
        uint cost = 0;
        foreach (AbstractUnit unit in army)
        {
            cost += unit.Cost;
        }

        return cost;
    }

    public void MakeTurn(List<AbstractUnit> army1, List<AbstractUnit> army2)
    {
        for (int i = 0; i < army1.Count; i++)
        {
            if (i >= army2.Count)
            {
                break;
            }
            army1.ElementAt(i).TakeTurn(army2.ElementAt(i), GetArmyCost(army2));
        }

        for (int i = 0; i < army2.Count; i++)
        {
            if (army2.ElementAt(i).IsAlive)
            {
                if (i >= army1.Count)
                {
                    break;
                }
                army2.ElementAt(i).TakeTurn(army1[i], GetArmyCost(army1));
            }
        }
    }

    public void UseSpecialAbility(List<AbstractUnit> army1, List<AbstractUnit> army2)
    {
        for (int i = 0; i < army1.Count; i++)
        {
            if (army1[i].IsAlive && army1[i] is ISpecialAbility special)
            {
                List<AbstractUnit> friendlyReach = new();
                List<AbstractUnit> enemyReach = new();
                ScanForReach(i, special.SpecialAbilityRange, friendlyReach, enemyReach, army1, army2);
                int size = friendlyReach.Count;
                special.CastSpecialAbility(friendlyReach, enemyReach);
                if (size < friendlyReach.Count)
                {
                    for (int j = size; j < friendlyReach.Count; j++)
                    {
                        army1.Add(friendlyReach[j]);
                    }
                }
            }
        }
    }

    private void ScanForReach(int index, int range, List<AbstractUnit> friendlyReach, List<AbstractUnit> enemyReach, List<AbstractUnit> army1, List<AbstractUnit> army2)
    {
        for (int i = index + 1, travelled = range - 1; i < army1.Count; i++, travelled--)
        {
            friendlyReach.Add(army1[i]);
            if (travelled == 0)
                break;
        }

        for (int i = index - 1, travelled = range - 1; i >= 0; i--, travelled--)
        {
            friendlyReach.Add(army1[i]);
            if (travelled == 0)
                break;
        }

        if (army2.Count > index)
            enemyReach.Add(army2[index]);
    }
}
