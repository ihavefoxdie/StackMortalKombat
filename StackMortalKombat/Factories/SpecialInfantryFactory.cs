using StackMortalKombat.SpecialUnits;
using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public class SpecialInfantryFactory : AbstractUnitFactory
{
    private AbstractUnit _infantry;

    public SpecialInfantryFactory() : base("SpecialInfantry")
    {
        InfantryFactory factory = new();
        _infantry = factory.CreateUnit();
    }

    public override AbstractUnit CreateUnit()
    {
        return new SpecialInfantry(_infantry, 1, 0, 2 * (1 + 0));
    }

    public override int GetCost()
    {
        return (int)_infantry.Cost + 2;
    }
}
