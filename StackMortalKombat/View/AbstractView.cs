using Spectre.Console;
using StackMortalKombat.Battle;
using StackMortalKombat.Commands;
using StackMortalKombat.Units;

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
                if (_battleHistory._battleContext.army1.All(p1 => p1 is WalkTheCityAdapter) && _battleHistory._battleContext.army2.All(p2 => p2 is WalkTheCityAdapter))
                {
                    AnsiConsole.Write(new FigletText($"Goalless Draw!!!")
                    .Centered()
                    .Color(Color.Yellow3)
                    );
                }
                else
                {
                    if (_battleHistory._battleContext.army1.Count == 0)
                        number = 2;
                    else
                        number = 1;

                    AnsiConsole.Write(new FigletText($"Army#{number} wins!!!")
                        .Centered()
                        .Color(Color.Yellow3)
                        );
                }
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
