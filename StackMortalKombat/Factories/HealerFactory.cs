﻿using StackMortalKombat.Interfaces;
using StackMortalKombat.SpecialUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Factories
{
    internal class HealerFactory : UnitFactory
    {
        private IUnit _unit;

        public HealerFactory(IUnit unit)
        {
            _unit = unit;
        }

        public override IUnit CreateUnit()
        {
            return new Healer(_unit);
        }
    }
}
