using StackMortalKombat.Units;

namespace StackMortalKombat.Interfaces
{
    public interface IStrategy
    {
        //army1 атакует, army 2 терпит
        void MakeTurn(List<AbstractUnit> army1, List<AbstractUnit> army2);

        void UseSpecialAbility(List<AbstractUnit> army1, List<AbstractUnit> army2);

    }
}
