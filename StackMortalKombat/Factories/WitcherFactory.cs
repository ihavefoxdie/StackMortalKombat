﻿using StackMortalKombat.SpecialUnits;
using StackMortalKombat.Units;

namespace StackMortalKombat.Factories
{
    public class WitcherFactory : AbstractUnitFactory
    {
        private AbstractUnit _unit;

        public WitcherFactory(AbstractUnit unit) : base ("Witcher")
        {
            _unit = unit;
        }

        public override AbstractUnit CreateUnit()
        {
           return new Witcher(_unit, 2, 3, 2*(2+3));
        }

        public override int GetCost()
        {
            return (int)_unit.Cost + 2 * (2 + 3);
        }
    }
}