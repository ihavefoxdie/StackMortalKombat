using StackMortalKombat.SpecialUnits;
using StackMortalKombat.Units;

namespace StackMortalKombat.Factories
{
    public class WitcherFactory : UnitFactory
    {
        private Unit _unit;

        public WitcherFactory(Unit unit)
        {
            _unit = unit;
        }

        public override Unit CreateUnit()
        {
           return new Witcher(_unit, 2, 3, 5);
        }
    }
}
