using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public class KnightFactory : AbstractUnitFactory
{
    public override AbstractUnit CreateUnit()
    {
        return new Knight(3, "Knight", 10, 10, 3, 3, 10 + 3 + 3);
    }
}