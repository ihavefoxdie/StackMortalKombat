using Spectre.Console;
using StackMortalKombat.Commands;

namespace StackMortalKombat.Interfaces
{
    public abstract class AbstractView
    {
        protected BattleHistory _battleHistory;

        public abstract void StartMenu();

        protected abstract void StrategyMenu();

        protected abstract void BattleMenu();

        public abstract void PrintFinishBattleInfo();

        public void GameLoop()
        {
            if (isGameEnded())
            {
                int number = 0;
                if (_battleHistory._battleContext.army1.Count == 0)
                    number = 1;
                else
                    number = 2;

                AnsiConsole.Write(new FigletText($"Army#{number} wins!!!")
                    .Centered()
                    .Color(Color.Yellow3)
                    );
                return;
            }
            BattleMenu();
            GameLoop();
        }

        protected virtual bool isGameEnded()
        {
            if (_battleHistory.isGameEnded)
                return true;
            return false;
        }

        public AbstractView(BattleHistory battleHistory)
        {
            _battleHistory = battleHistory;
        }



    }
}
