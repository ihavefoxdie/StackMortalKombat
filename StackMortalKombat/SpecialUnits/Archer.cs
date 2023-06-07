using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.SpecialUnits;

public class Archer : Unit, ISpecialAbility
{
    /*public Archer(Unit unit) : base(unit, 4, 2, "Archer", 2)
    {
    }*/

    public Archer(Unit unit, int specialAbilityRange, int specialAbilityStrength, uint specialAbilityCost) : base(unit.Id, "Archer" + unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost + specialAbilityCost)
    {
        SpecialAbilityCost = specialAbilityCost;
        SpecialAbilityStrength = specialAbilityStrength;
        SpecialAbilityRange = specialAbilityRange;
    }

    public int SpecialAbilityRange { get; }

    public int SpecialAbilityStrength { get; }

    public string SpecialAbilityName => "Archer";

    public uint SpecialAbilityCost { get; }

    public void CastSpecialAbility(ref List<Unit> unitsFriendly, ref List<Unit> unitsEnemies)
    {
        unitsEnemies[new Random().Next(0, unitsEnemies.Count)].Health -= SpecialAbilityStrength;
    }

    public override void TakeTurn()
    {
        base.TakeTurn();
    }
}
