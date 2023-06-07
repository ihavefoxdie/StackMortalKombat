using StackMortalKombat.Units;

namespace StackMortalKombat.Factories
{
    public class InfantryFactory : UnitFactory
    {
        public override Unit CreateUnit()
        {
            return new Infantry(1, "Infantry", 1, 1, 1, 2, 1 + 1 + 2);
        }
    }
}
