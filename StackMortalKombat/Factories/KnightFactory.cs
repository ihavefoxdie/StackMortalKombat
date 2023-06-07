using StackMortalKombat.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Factories
{
    public class KnightFactory : UnitFactory
    {
        public KnightFactory()
        {
        }

        public override Unit CreateUnit()
        {
            return new Knight(3, "Knight", 40, 20, 15, 10, 2);
        }
    }
}
