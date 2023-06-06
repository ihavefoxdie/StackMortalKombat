using StackMortalKombat.Interfaces;
using StackMortalKombat.SpecialUnits;

namespace StackMortalKombat.Factories
{
    internal class ArcherFactory : UnitFactory
    {
        private IUnit _unit;
        public ArcherFactory(IUnit unit)
        {
            _unit = unit;
        }


        public override IUnit CreateUnit()
        {
            return new Archer(_unit);
        }
    }
}
