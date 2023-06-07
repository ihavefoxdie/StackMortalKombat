using StackMortalKombat.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Factories
{
    public class InfantryFactory : UnitFactory
    {
        public InfantryFactory()
        {
        }

        public override Unit CreateUnit()
        {
            return new Infantry(1, "Infantry", 20, 20, 5, 5, 2);
        }
    }
}
