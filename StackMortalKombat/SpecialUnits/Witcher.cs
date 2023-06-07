using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.SpecialUnits;

public class Witcher : Unit, ISpecialAbility
{
    public Witcher(Unit unit, int specialAbilityRange, int specialAbilityStrength, uint specialAbilityCost) : base(unit.Id, "Witcher" + unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost + specialAbilityCost)
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
        List<int> clonables = new List<int>();
        for (int i = 0; i < unitsFriendly.Count; i++)
        {
            if (unitsFriendly[i] is IClone<Unit>)
                clonables.Add(i);
        }
        if (clonables.Count > 0)
        {
            unitsFriendly.Add(((IClone<Unit>)unitsFriendly[clonables[new Random().Next(0, clonables.Count)]]).Clone());
        }
    }

    public override void TakeTurn()
    {
        base.TakeTurn();
    }
}
