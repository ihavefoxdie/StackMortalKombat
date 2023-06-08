using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.SpecialUnits;

public class Healer : Unit, ISpecialAbility
{
    public Healer(Unit unit, int specialAbilityRange, int specialAbilityStrength, uint specialAbilityCost) : base(unit.Id, "Healer" + unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost + specialAbilityCost)
    {
        SpecialAbilityCost = specialAbilityCost;
        SpecialAbilityStrength = specialAbilityStrength;
        SpecialAbilityRange = specialAbilityRange;
    }

    public int SpecialAbilityRange { get; }

    public int SpecialAbilityStrength { get; }

    public string SpecialAbilityName => "Healer";

    public uint SpecialAbilityCost { get; }

    public void CastSpecialAbility(List<Unit> unitsFriendly, List<Unit> unitsEnemies)
    {
        foreach (Unit unit in unitsFriendly)
        {
            if (unit is IHealable healable)
                healable.ReceiveHealing((uint)SpecialAbilityStrength);
        }
    }

    public override void TakeTurn(Unit enemy)
    {
        base.TakeTurn(enemy);
    }
}