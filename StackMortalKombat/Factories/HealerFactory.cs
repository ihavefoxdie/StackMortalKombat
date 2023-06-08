using StackMortalKombat.SpecialUnits;
using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public class HealerFactory : AbstractUnitFactory
{
    private AbstractUnit _unit;

    public HealerFactory(AbstractUnit unit)
    {
        _unit = unit;
    }

    public override AbstractUnit CreateUnit()
    {
        return new Healer(_unit, 5, 5, 2 * (5 + 5));
    }
}