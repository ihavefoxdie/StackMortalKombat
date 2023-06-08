﻿using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.SpecialUnits;

public class Healer : AbstractUnit, ISpecialAbility
{
    public Healer(AbstractUnit unit, int specialAbilityRange, int specialAbilityStrength, uint specialAbilityCost) : base(unit.Id, "Healer" + unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost + specialAbilityCost)
    {
        SpecialAbilityCost = specialAbilityCost;
        SpecialAbilityStrength = specialAbilityStrength;
        SpecialAbilityRange = specialAbilityRange;
    }

    public int SpecialAbilityRange { get; }

    public int SpecialAbilityStrength { get; }

    public string SpecialAbilityName => "Healer";

    public uint SpecialAbilityCost { get; }

    public void CastSpecialAbility(List<AbstractUnit> unitsFriendly, List<AbstractUnit> unitsEnemies)
    {
        foreach (AbstractUnit unit in unitsFriendly)
        {
            if (unit is IHealable healable)
                healable.ReceiveHealing((uint)SpecialAbilityStrength);
        }
    }

    public override void TakeTurn(AbstractUnit enemy)
    {
        base.TakeTurn(enemy);
    }
}