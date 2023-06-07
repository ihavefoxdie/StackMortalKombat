using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackMortalKombat.Units;

namespace StackMortalKombat.Factories
{
    public abstract class UnitFactory
    {
        public abstract Unit CreateUnit();
    }
}
