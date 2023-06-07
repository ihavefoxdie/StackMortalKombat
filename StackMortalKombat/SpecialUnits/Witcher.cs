﻿using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.SpecialUnits;

public class Witcher : Unit, ISpecialAbility
{
    public Witcher(Unit unit, int specialAbilityRange, int specialAbilityStrength, uint specialAbilityCost) : base(unit.Id, unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost + specialAbilityCost)
    {
        SpecialAbilityCost = specialAbilityCost;
        SpecialAbilityStrength = specialAbilityStrength;
        SpecialAbilityRange = specialAbilityRange;
    }

    public int SpecialAbilityRange { get; }

    public int SpecialAbilityStrength { get; }

    public string SpecialAbilityName => "Witcher";

    public uint SpecialAbilityCost { get; }

    public void CastSpecialAbility(ref List<Unit> unitsFriendly, ref List<Unit> unitsEnemies)
    {
        unitsFriendly[new Random().Next(0, unitsEnemies.Count)].Health += SpecialAbilityStrength;
    }

    public override void TakeTurn()
    {
        base.TakeTurn();
    }
}
