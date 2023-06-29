using StackMortalKombat.Battle;

namespace StackMortalKombat.Commands
{
    internal class ToFinishCommand : AbstractCommand
    {
        private BattleHistory _battleHistory;

        public ToFinishCommand(BattleContext battleContext, BattleHistory battleHistory) : base(battleContext)
        {
            _battleHistory = battleHistory;
        }

        public override void Execute()
        {
            AbstractCommand abstractCommand;

            //AbstractCommand abstractCommand = new NextTurnCommand(_battleContext);
            //_battleHistory.SetCommand(new LoggedCommand(abstractCommand, _battleContext));
            //_battleHistory.Execute();

            while (!_battleHistory.isGameEnded)
            {
                abstractCommand = new NextTurnCommand(_battleContext);
                _battleHistory.SetCommand(new LoggedCommand(abstractCommand, _battleContext));
                _battleHistory.Execute();
            }
            
        }

        public override void Undo()
        {

        }

        public override void Redo()
        {

        }
    }
}
