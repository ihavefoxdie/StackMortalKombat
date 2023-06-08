﻿using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.Strategies;

public class StrategyHorizontally : IStrategy
{
    public StrategyHorizontally()
    {
    }

    public void MakeTurn(List<AbstractUnit> army1, List<AbstractUnit> army2)
    {
        if (army1.Last() != null && army2.Last() != null)
        {
            army1.Last().TakeTurn(army2.Last());
            if (army2.Last().IsAlive)
                army1.Last().TakeDamage(army2.Last().Damage);
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
                special.CastSpecialAbility(friendlyReach, enemyReach);
            }
        }
    }

    private void ScanForReach(int index, int range, List<AbstractUnit> friendlyReach, List<AbstractUnit> enemyReach, List<AbstractUnit> army1, List<AbstractUnit> army2)
    {
        for (int i = index + 1, wentThrough = range - 1; i < army1.Count; i++, wentThrough--)
        {
            friendlyReach.Add(army1[i]);
            if (wentThrough == 0)
                break;
        }

        for (int i = index - 1, wentThrough = range - 1; i >= 0; i++, wentThrough--)
        {
            friendlyReach.Add(army1[i]);
            if(wentThrough == 0)
                break;
        }

        int enemyRange = range + (index - army1.Count - 1);
        for (int i = army2.Count - 1; i >= 0 || enemyRange > 0; i++, enemyRange--)
        {
            enemyReach.Add(army2[i]);
        }
    }

    /*private bool Assist(List<AbstractUnit> friendly, AbstractUnit unit, int wentThrough)
    {
        friendly.Add(unit);
        if (wentThrough == 0)
            return false;
        return true;
    }*/
}
