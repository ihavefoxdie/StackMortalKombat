﻿using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.Strategies;

public class StrategyRows : IStrategy
{
    private uint _cost = 0;

    public StrategyRows()
    {
    }

    private uint GetArmyCost(List<AbstractUnit> army)
    {
        if (_cost == 0)
        {
            foreach (AbstractUnit unit in army)
            {
                _cost += unit.Cost;
            }
            return _cost;
        }
        return _cost;
    }

    public void MakeTurn(List<AbstractUnit> army1, List<AbstractUnit> army2)
    {
        for (int i = 1; i < 4; i++)
        {
            if (army1.Count - i < 0 || army2.Count - i < 0)
                break;
            army1.ElementAt(army1.Count - i).TakeTurn(army2.ElementAt(army2.Count - i), GetArmyCost(army2));
        }

        for (int i = 1; i < 4; i++)
        {
            if (army1.Count - i < 0 || army2.Count - i < 0)
                break;
            if (army2.ElementAt(army2.Count - i).IsAlive)
            {
                army2.ElementAt(army2.Count - i).TakeTurn(army1[army1.Count - i], GetArmyCost(army1));
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

    private void MovingDown(int index, List<AbstractUnit> friendlyReach, List<AbstractUnit> army1)
    {
        if (index - 1 >= 0)
            friendlyReach.Add(army1[index - 1]);
        if (index - 2 >= 0)
            friendlyReach.Add(army1[index - 2]);
    }

    private void MovingUp(int index, List<AbstractUnit> friendlyReach, List<AbstractUnit> army1)
    {
        if (army1.Count > index + 1)
            friendlyReach.Add(army1[index + 1]);
        if (army1.Count > index + 2)
            friendlyReach.Add(army1[index + 2]);
    }

    private void MovingUpDown(int index, List<AbstractUnit> friendlyReach, List<AbstractUnit> army1)
    {
        if (index - 1 >= 0)
            friendlyReach.Add(army1[index - 1]);
        if (army1.Count > index + 1)
            friendlyReach.Add(army1[index + 1]);
    }

    private void ScanForReach(int index, int range, List<AbstractUnit> friendlyReach, List<AbstractUnit> enemyReach, List<AbstractUnit> army1, List<AbstractUnit> army2)
    {
        #region Horizontal Ally Inclusion
        for (int i = index + 3, travelled = range - 1; i < army1.Count; i += 3, travelled--)
        {
            friendlyReach.Add(army1[i]);
            if (travelled == 0)
                break;
        }

        for (int i = index - 3, travelled = range - 1; i >= 0; i -= 3, travelled--)
        {
            friendlyReach.Add(army1[i]);
            if (travelled == 0)
                break;
        }
        #endregion

        #region Vertical Ally Inclusion
        int j = index;
        if (j < 3)
            j += 3;
        int size = army1.Count;
        if (size < 3)
            size += 3;

        switch (size % 3)
        {
            case 0:
                {
                    switch (j % 3)
                    {
                        case 0:
                            MovingUp(index, friendlyReach, army1);
                            break;
                        case 1:
                            MovingUpDown(index, friendlyReach, army1);
                            break;
                        case 2:
                            MovingDown(index, friendlyReach, army1);
                            break;
                    }
                    break;
                }
            case 1:
                {
                    switch (j % 3)
                    {
                        case 0:
                            MovingDown(index, friendlyReach, army1);
                            break;
                        case 1:
                            MovingUp(index, friendlyReach, army1);
                            break;
                        case 2:
                            MovingUpDown(index, friendlyReach, army1);
                            break;
                    }
                    break;
                }
            case 2:
                {
                    switch (j % 3)
                    {
                        case 0:
                            MovingUpDown(index, friendlyReach, army1);
                            break;
                        case 1:
                            MovingDown(index, friendlyReach, army1);
                            break;
                        case 2:
                            MovingUp(index, friendlyReach, army1);
                            break;
                    }
                    break;
                }
        }
        #endregion

        #region Enemy Inclusion
        int enemyRange = range;
        int n = index;
        int referenceIndex = n;
        while (true)
        {
            n += 3;
            if (army1.Count >= n)
                break;
            referenceIndex += 3;
            enemyRange--;
        }

        for (int i = referenceIndex; i >= 0 && enemyRange > 0 && i < army2.Count; i -= 3, enemyRange--)
        {
            enemyReach.Add(army2[i]);
        }
        #endregion
    }
}
