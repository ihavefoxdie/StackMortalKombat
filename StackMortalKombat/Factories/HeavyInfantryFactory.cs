using StackMortalKombat.Units;

namespace StackMortalKombat.Factories
{
    public class HeavyInfantryFactory : AbstractUnitFactory
    {
        public HeavyInfantryFactory() : base("HeavyInfantry")
        {

        }

        public override AbstractUnit CreateUnit()
        {
            return new HeavyInfantry(2, "HeavyInfantry", 2, 2, 2, 2, 2 + 2 + 2);
        }
    }
}
