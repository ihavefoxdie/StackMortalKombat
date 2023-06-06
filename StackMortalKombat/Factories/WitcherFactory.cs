using StackMortalKombat.Interfaces;

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
            



            throw new NotImplementedException();

        }
    }
}
