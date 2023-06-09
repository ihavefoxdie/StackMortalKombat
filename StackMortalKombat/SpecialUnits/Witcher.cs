﻿using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;
using System;

namespace StackMortalKombat.SpecialUnits;

public class Witcher : AbstractUnit, ISpecialAbility
{
    public Witcher(AbstractUnit unit, int specialAbilityRange, int specialAbilityStrength, uint specialAbilityCost) : base(unit.Id, "Witcher" + unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost + specialAbilityCost)
    {
        _unit = unit;
        SpecialAbilityCost = specialAbilityCost;
        SpecialAbilityStrength = specialAbilityStrength;
        SpecialAbilityRange = specialAbilityRange;
    }

    private AbstractUnit _unit;

    public int SpecialAbilityRange { get; }

    public int SpecialAbilityStrength { get; }

    public string SpecialAbilityName => "Witcher";

    public uint SpecialAbilityCost { get; }

    public void CastSpecialAbility(List<AbstractUnit> unitsFriendly, List<AbstractUnit> unitsEnemies)
    {
        Random random = new();
        if (random.Next(0,100) > 70)
        {
            List<int> clonables = new();
            for (int i = 0; i < unitsFriendly.Count; i++)
            {
                if (unitsFriendly[i] is IClone<AbstractUnit>)
                    clonables.Add(i);
            }
            if (clonables.Count > 0)
            {
                unitsFriendly.Add(((IClone<AbstractUnit>)unitsFriendly[clonables[new Random().Next(0, clonables.Count - 1)]]).Clone());
            }
        }
    }

    public override Witcher ReturnCopy()
    {
        return new Witcher(_unit.ReturnCopy(), SpecialAbilityRange, SpecialAbilityStrength, SpecialAbilityCost);
    }

    public override void TakeTurn(AbstractUnit enemy, uint armyCost)
    {
        base.TakeTurn(enemy, armyCost);
    }
}
