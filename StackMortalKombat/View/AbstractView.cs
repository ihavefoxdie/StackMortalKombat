using StackMortalKombat.Commands;

namespace StackMortalKombat.Interfaces
{
    public abstract class AbstractView
    {
        protected BattleHistory _battleHistory;

        public abstract void StartMenu();
        protected abstract void ValueMenu();
        protected abstract void UnitsToAddMenu();
        protected abstract void StrategyMenu();

        public abstract void ShowBattleInfo();

        public void SetBattleHistory(BattleHistory battleHistory)
        {
            _battleHistory = battleHistory;
        }

        public void GameLoop()
        {
            if (isGameEnded())
                return;

            ShowBattleInfo();
        }

        protected virtual bool isGameEnded()
        {
            if (_battleHistory.isGameEnded)
                return true;
            return false;
        }

        public AbstractView()
        {

        }



    }
}
