using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.SpecialUnits;

public class Witcher : AbstractUnit, ISpecialAbility
{
    public Witcher(AbstractUnit unit, int specialAbilityRange, int specialAbilityStrength, uint specialAbilityCost) : base(unit.Id, "Witcher" + unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost + specialAbilityCost)
    {
        SpecialAbilityCost = specialAbilityCost;
        SpecialAbilityStrength = specialAbilityStrength;
        SpecialAbilityRange = specialAbilityRange;
    }

    public int SpecialAbilityRange { get; }

    public int SpecialAbilityStrength { get; }

    public string SpecialAbilityName => "Witcher";

    public uint SpecialAbilityCost { get; }

    public void CastSpecialAbility(List<AbstractUnit> unitsFriendly, List<AbstractUnit> unitsEnemies)
    {
        List<int> clonables = new();
        for (int i = 0; i < unitsFriendly.Count; i++)
        {
            if (unitsFriendly[i] is IClone<AbstractUnit>)
                clonables.Add(i);
        }
        if (clonables.Count > 0)
        {
            unitsFriendly.Add(((IClone<AbstractUnit>)unitsFriendly[clonables[new Random().Next(0, clonables.Count)]]).Clone());
        }
    }

    public override void TakeTurn(AbstractUnit enemy)
    {
        base.TakeTurn(enemy);
    }
}
