using StackMortalKombat.Units;

namespace StackMortalKombat.Factories
{
    public class InfantryFactory : AbstractUnitFactory
    {
        public override AbstractUnit CreateUnit()
        {
            return new Infantry(1, "Infantry", 1, 1, 1, 2, 1 + 1 + 2);
        }
    }
}
