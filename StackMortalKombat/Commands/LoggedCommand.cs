using StackMortalKombat.Battle;

namespace StackMortalKombat.Commands
{
    internal class LoggedCommand : AbstractCommand
    {
        private AbstractCommand _command;
        private string _logPath;

        public LoggedCommand(AbstractCommand abstractCommand, BattleContext battleContext) : base(battleContext)
        {
            _logPath = Path.Combine(Environment.CurrentDirectory, "log.txt");
            _command = abstractCommand;
        }

        public override void Execute()
        {
            if (_battleContext.TurnNumber == 1)
            {
                using (StreamWriter writer = new(_logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now}\tBattle Started");
                }
            }

            _command.Execute();
            using (StreamWriter writer = new(_logPath, true))
            {
                writer.WriteLine(Log("is executed"));
            }
        }

        public override void Redo()
        {
            _command.Redo();
            using (StreamWriter writer = new(_logPath, true))
            {
                writer.WriteLine(Log("is redone"));
            }
        }

        public override void Undo()
        {
            _command.Undo();
            using (StreamWriter writer = new(_logPath, true))
            {
                writer.WriteLine(Log("is undone"));
            }
        }

        private string Log(string additionalInfo)
        {
            if (_command is ToFinishCommand)
                return "";

            string result = "";
            string currentPlayer;
            string commandName = _command.GetType().Name;
            int turnNumber = _battleContext.TurnNumber;


            if (turnNumber % 2 == 0)
                currentPlayer = "Player#1";
            else
                currentPlayer = "Player#2";


            if (_battleContext.army1.Count == 0 || _battleContext.army2.Count == 0)
                return $"{DateTime.Now}\tBattle Finished\tWinner : {currentPlayer}\n";


            return result + $"{DateTime.Now}\tTurn : {turnNumber - 1}\tPlayer : {currentPlayer}\tCommand : {commandName}\t{additionalInfo}";
        }
    }
}
