using StackMortalKombat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Factories
{
    internal class WitcherFactory : UnitFactory
    {
        public override IUnit CreateUnit()
        {
            InfantryFactory infantryFactory = new InfantryFactory();
            IUnit unit = infantryFactory.CreateUnit();

            throw new NotImplementedException();

        }
    }
}
