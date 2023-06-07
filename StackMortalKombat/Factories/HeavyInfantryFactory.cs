using StackMortalKombat.Units;

namespace StackMortalKombat.Factories
{
    public class HeavyInfantryFactory : UnitFactory
    {
        public override Unit CreateUnit()
        {
            return new HeavyInfantry(2, "HeavyInfantry", 2, 2, 2, 2, 2 + 2 + 2);
        }
    }
}
