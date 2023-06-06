using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Interfaces
{
    abstract class UnitFactory
    {
       public abstract IUnit CreateUnit();
    }
}
