using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public class KnightFactory : UnitFactory
{
    public override Unit CreateUnit()
    {
        return new Knight(3, "Knight", 10, 10, 3, 3, 10 + 3 + 3);
    }
}