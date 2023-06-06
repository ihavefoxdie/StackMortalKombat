using StackMortalKombat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.SpecialUnits;

public class Healer : SpecialAbility
{
    public Healer(IUnit unit) : base(unit, 5, 5, "Healer", 5)
    {
    }

    public override void CastSpecialAbility(ref List<IUnit> unitsFriendly, ref List<IUnit> unitsEnemies)
    {
        throw new NotImplementedException();
    }
}
