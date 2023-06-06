using StackMortalKombat.Interfaces;

namespace StackMortalKombat.SpecialUnits;

public class Witcher : SpecialAbility
{
    public Witcher(IUnit unit) : base(unit, 2, 3, "Witcher", 5)
    {
    }

    public override void CastSpecialAbility(ref List<IUnit> unitsFriendly, ref List<IUnit> unitsEnemies)
    {
        throw new NotImplementedException();
    }
}
