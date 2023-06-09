using StackMortalKombat.Units;

namespace StackMortalKombat.Buffs;

public abstract class BuffedUnit : AbstractUnit
{
    protected AbstractUnit _unit;
    private List<AbstractBuff> _appliedBuffs;
    public IReadOnlyList<AbstractBuff> AppliedBuffs
    {
        get { return _appliedBuffs; }
    }

    public void AddBuff(AbstractBuff buff)
    {
        _appliedBuffs.Add(buff);
    }

    public BuffedUnit(AbstractUnit unit) : base(unit.Id, unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost)
    {
        _appliedBuffs = new();
        _unit = unit;
    }
}