using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Factories
{
    internal class InfantryFactory : UnitFactory
    {
        public InfantryFactory()
        {
        }

        public override IUnit CreateUnit()
        {
            return new Infantry();
        }
    }
}
