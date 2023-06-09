using StackMortalKombat.Buffs;
using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.SpecialUnits;

public class SpecialInfantry : AbstractUnit, ISpecialAbility
{
    public SpecialInfantry(AbstractUnit unit, int specialAbilityRange, int specialAbilityStrength, uint specialAbilityCost) : base(unit.Id, "Archer" + unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost + specialAbilityCost)
    {
        _unit = unit;
        SpecialAbilityCost = specialAbilityCost;
        SpecialAbilityStrength = specialAbilityStrength;
        SpecialAbilityRange = specialAbilityRange;
    }

    private AbstractUnit _unit;

    public int SpecialAbilityRange { get; }

    public int SpecialAbilityStrength { get; }

    public string SpecialAbilityName => "Special Infantry";

    public uint SpecialAbilityCost { get; }

    private void ApplyBuff(BuffedHeavyInfantry unit)
    {
        bool check = false;
        foreach(AbstractBuff buff in unit.AppliedBuffs)
        {
            if(buff is Helmet)
            {
                check = true;
                break;
            }
        }
        if(!check)
        {
            unit.AddBuff(new Helmet());
            return;
        }

        check = false;
        foreach (AbstractBuff buff in unit.AppliedBuffs)
        {
            if (buff is Horse)
            {
                check = true;
                break;
            }
        }
        if (!check)
        {
            unit.AddBuff(new Horse());
            return;
        }

        check = false;
        foreach (AbstractBuff buff in unit.AppliedBuffs)
        {
            if (buff is Shield)
            {
                check = true;
                break;
            }
        }
        if (!check)
        {
            unit.AddBuff(new Shield());
            return;
        }
    }

    public void CastSpecialAbility(List<AbstractUnit> unitsFriendly, List<AbstractUnit> unitsEnemies)
    {
        for (int i = 0; i < unitsFriendly.Count; i++)
        {
            if (unitsFriendly[i] is HeavyInfantry)
            {
                if (unitsFriendly[i] is BuffedHeavyInfantry buffedUnit)
                {
                    ApplyBuff(buffedUnit);
                }
                else
                {
                    BuffedHeavyInfantry buffedInfantry = new (unitsFriendly[i]);
                    ApplyBuff(buffedInfantry);
                    unitsFriendly[i] = buffedInfantry;
                }
            }
        }
    }

    public override SpecialInfantry ReturnCopy()
    {
        return new SpecialInfantry(_unit.ReturnCopy(), SpecialAbilityRange, SpecialAbilityStrength, SpecialAbilityCost);
    }

    public override void TakeTurn(AbstractUnit enemy)
    {
        base.TakeTurn(enemy);
    }
}
