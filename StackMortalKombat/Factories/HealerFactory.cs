using StackMortalKombat.SpecialUnits;
using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public class HealerFactory : AbstractUnitFactory
{
    private Unit _unit;

    public HealerFactory(Unit unit)
    {
        _unit = unit;
    }

    public override Unit CreateUnit()
    {
        return new Healer(_unit, 5, 5, 2 * (5 + 5));
    }
}