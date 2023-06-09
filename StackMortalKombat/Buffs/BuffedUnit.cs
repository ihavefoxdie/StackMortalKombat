using StackMortalKombat.Units;

namespace StackMortalKombat.Buffs;

public abstract class BuffedUnit : AbstractUnit
{
    protected AbstractUnit _unit;

    public List<AbstractBuff> AppliedBuffs { get; set; }

    public BuffedUnit(AbstractUnit unit) : base(unit.Id, unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost)
    {
        AppliedBuffs = new();
        _unit = unit;
    }
}