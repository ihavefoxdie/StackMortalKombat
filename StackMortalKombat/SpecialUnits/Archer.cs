using StackMortalKombat.Interfaces;

namespace StackMortalKombat.SpecialUnits;

public class Archer : SpecialAbility
{
    public Archer(IUnit unit) : base(unit, 4, 2, "Archer", 2)
    {
    }

    public override void CastSpecialAbility(ref List<IUnit> unitsFriendly, ref List<IUnit> unitsEnemies)
    {
        throw new NotImplementedException();
    }
}
