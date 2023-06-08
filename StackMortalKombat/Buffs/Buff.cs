using StackMortalKombat.Units;

namespace StackMortalKombat.Buffs;

public abstract class Buff : AbstractUnit
{
    protected AbstractUnit _unit;

    public Buff(AbstractUnit unit) : base(unit.Id, unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost)
    {
        _unit = unit;
    }
}