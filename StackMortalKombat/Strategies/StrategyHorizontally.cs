using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.Strategies;

public class StrategyHorizontally : IStrategy
{
    public StrategyHorizontally()
    {
    }

    private static uint GetArmyCost(List<AbstractUnit> army)
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
        if (army1.Last() != null && army2.Last() != null)
        {
            army1.Last().TakeTurn(army2.Last(), GetArmyCost(army2));
            if (army2.Last().IsAlive)
                army2.Last().TakeTurn(army1.Last(), GetArmyCost(army1));
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

        for (int i = index - 1, travelled = range - 1; i >= 0; i++, travelled--)
        {
            friendlyReach.Add(army1[i]);
            if(travelled == 0)
                break;
        }

        int enemyRange = range + (index - (army1.Count - 1));
        for (int i = army2.Count - 1; i >= 0 && enemyRange > 0 && i < army2.Count; i--, enemyRange--)
        {
            enemyReach.Add(army2[i]);
        }
    }

    /*private bool Assist(List<AbstractUnit> friendly, AbstractUnit unit, int travelled)
    {
        friendly.Add(unit);
        if (travelled == 0)
            return false;
        return true;
    }*/
}
