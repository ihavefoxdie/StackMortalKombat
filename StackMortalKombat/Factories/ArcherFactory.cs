using StackMortalKombat.SpecialUnits;
using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public class ArcherFactory : UnitFactory
{
    private Unit _unit;

    public ArcherFactory(Unit unit)
    {
        _unit = unit;
    }

    public override Unit CreateUnit()
    {
        return new Archer(_unit, 4, 2, 2 * (4 + 2));
    }
}