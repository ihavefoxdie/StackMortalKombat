using StackMortalKombat.Units;
using System.Runtime.CompilerServices;

namespace StackMortalKombat.Factories
{
    public class InfantryFactory : AbstractUnitFactory
    {
        public InfantryFactory() : base("Infantry")
        {
        }

        public override AbstractUnit CreateUnit()
        {
            return new Infantry(1, "Infantry", 1, 1, 1, 2, 1 + 1 + 2);
        }

        public override int GetCost()
        {
            return 1 + 1 + 2;
        }
    }
}
