using StackMortalKombat.Units;

namespace StackMortalKombat.Buffs;

public abstract class Buff : Unit
{
    protected Unit _unit;

    public Buff(Unit unit) : base(unit.Id, unit.Name, unit.Health, unit.MaxHP, unit.Damage, unit.Defense, unit.Cost)
    {
        _unit = unit;
    }
}