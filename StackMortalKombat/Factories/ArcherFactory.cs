using StackMortalKombat.SpecialUnits;
using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public class ArcherFactory : AbstractUnitFactory
{
    private AbstractUnit _unit;

    public ArcherFactory(AbstractUnit unit) : base("Archer")
    {
        _unit = unit;
    }


    public override AbstractUnit CreateUnit()
    {
        return new Archer(_unit, 4, 2, 2 * (4 + 2));
    }

    public override int GetCost()
    {
        return (int)_unit.Cost + 2 * (4 + 2);
    }
}