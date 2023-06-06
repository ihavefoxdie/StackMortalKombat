using StackMortalKombat.Interfaces;
using StackMortalKombat.SpecialUnits;

namespace StackMortalKombat.Factories
{
    internal class WitcherFactory : UnitFactory
    {
        private IUnit _unit;
        public WitcherFactory(IUnit unit)
        {
            _unit = unit;
        }
        public override IUnit CreateUnit()
        {
           return new Witcher(_unit);
        }
    }
}
