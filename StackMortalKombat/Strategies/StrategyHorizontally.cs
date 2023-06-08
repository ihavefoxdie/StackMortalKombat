using StackMortalKombat.Battle;
using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.Strategies;

public class StrategyHorizontally : IStrategy
{

    public StrategyHorizontally()
    {

    }

    public void MakeTurn(List<Unit> army1, List<Unit> army2)
    {
        army1.Last().TakeTurn(army2.Last());
        if (army2.Last().IsAlive)
            army1.Last().TakeDamage(army2.Last().Damage);
    }

    public void UseSpecialAbility(List<Unit> army1, List<Unit> army2)
    {
        throw new NotImplementedException();
    }

}
