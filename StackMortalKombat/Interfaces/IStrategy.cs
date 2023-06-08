using StackMortalKombat.Units;

namespace StackMortalKombat.Interfaces
{
    public interface IStrategy
    {
        //army1 атакует, army 2 терпит
        void MakeTurn(List<Unit> army1, List<Unit> army2);

        void UseSpecialAbility(List<Unit> army1, List<Unit> army2);

    }
}
