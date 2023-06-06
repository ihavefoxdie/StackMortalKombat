using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Factories
{
    internal class HeavyInfantryFactory : UnitFactory
    {
        public override IUnit CreateUnit()
        {
            return new HeavyInfantry();
        }
    }
}
