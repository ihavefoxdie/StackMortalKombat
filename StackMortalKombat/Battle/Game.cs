using StackMortalKombat.Commands;
using StackMortalKombat.Interfaces;

namespace StackMortalKombat.Battle
{
    public class Game
    {
        private BattleContext _battleContext;
        private BattleHistory _battleHistory;
        private AbstractView _view;

        public Game(BattleContext battleContext, BattleHistory battleHistory, AbstractView view)
        {
            _battleContext = battleContext;
            _battleHistory = battleHistory;
            _view = view;
            _view.StartMenu();
            _view.GameLoop();
            _view.PrintFinishBattleInfo();
        }

    }
}
