using StackMortalKombat.Interfaces;

namespace StackMortalKombat.SpecialUnits;

public abstract class SpecialAbility : IUnit
{
    #region SpecialAbility related
    protected IUnit _unit;
    public int SpecialAbilityRange { get; }
    public int SpecialAbilityStrength { get; }
    public string SpecialAbilityName { get; }
    public uint SpecialAbilityCost { get; }
    #endregion

    #region IUnit related
    public uint Id => _unit.Id;
    public string Name => SpecialAbilityName + " " + _unit.Name;
    public int Health => _unit.Health;
    public int MaxHP => _unit.MaxHP;
    public uint Damage => _unit.Damage;
    public uint Defense => _unit.Defense;
    public uint AttackRange => _unit.AttackRange;
    public uint Cost => SpecialAbilityCost + _unit.Cost;
    #endregion


    public SpecialAbility(IUnit unit, int specialAbilityRange, int specialAbilityStrength, string specialAbilityName, uint specialAbilityCost)
    {
        _unit = unit;
        SpecialAbilityRange = specialAbilityRange;
        SpecialAbilityStrength = specialAbilityStrength;
        SpecialAbilityName = specialAbilityName;
        SpecialAbilityCost = specialAbilityCost;
    }


    public abstract void CastSpecialAbility(ref List<IUnit> unitsFriendly, ref List<IUnit> unitsEnemies);

    public virtual void DamageTaken(uint damageTaken)
    {
        _unit.DamageTaken(damageTaken);
    }

    public virtual void TakeTurn()
    {
        _unit.TakeTurn();
    }
}