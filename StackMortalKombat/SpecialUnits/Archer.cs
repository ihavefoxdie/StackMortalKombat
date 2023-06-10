using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.SpecialUnits;

public class Archer : AbstractUnit, ISpecialAbility
{
    public Archer(AbstractUnit unit, int specialAbilityRange, int specialAbilityStrength, uint specialAbilityCost) : base(unit.Id, "Archer" + unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost + specialAbilityCost)
    {
        _unit = unit;
        SpecialAbilityCost = specialAbilityCost;
        SpecialAbilityStrength = specialAbilityStrength;
        SpecialAbilityRange = specialAbilityRange;
    }

    private AbstractUnit _unit;

    public int SpecialAbilityRange { get; }

    public int SpecialAbilityStrength { get; }

    public string SpecialAbilityName => "Archer";

    public uint SpecialAbilityCost { get; }

    public void CastSpecialAbility(List<AbstractUnit> unitsFriendly, List<AbstractUnit> unitsEnemies)
    {
        if (unitsEnemies.Count > 0)
            unitsEnemies[new Random().Next(0, unitsEnemies.Count - 1)].Health -= SpecialAbilityStrength;
    }

    public override Archer ReturnCopy()
    {
        return new Archer(_unit.ReturnCopy(), SpecialAbilityRange, SpecialAbilityStrength, SpecialAbilityCost);
    }

    public override void TakeTurn(AbstractUnit enemy, uint armyCost)
    {
        base.TakeTurn(enemy, armyCost);
    }
}
