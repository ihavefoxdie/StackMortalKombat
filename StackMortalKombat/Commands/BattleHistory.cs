using StackMortalKombat.Battle;
using System.Diagnostics;

namespace StackMortalKombat.Commands
{
    //Invoker
    public class BattleHistory
    {
        private AbstractCommand _command;
        private Stack<AbstractCommand> _undoCommands = new();
        private Stack<AbstractCommand> _redoCommands = new();
        private readonly BattleContext _battleContext;

        public void SetCommand(AbstractCommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            if (_command != null)
            {
                _command.Execute();
                _undoCommands.Push(_command);
            }
            else
                Debug.WriteLine("Command doesn't exist");
        }

        public void Undo()
        {
            if (_undoCommands.Any())
            {
                AbstractCommand command = _undoCommands.Pop();
                command.Undo();
                _redoCommands.Push(command);
            }

            else
                Debug.WriteLine("UndoStack is empty");
        }

        public void Redo()
        {
            if (_redoCommands.Any())
            {
                AbstractCommand command = _redoCommands.Pop();
                command.Execute();
                _undoCommands.Push(command);
            }

            else
                Debug.WriteLine("RedoStack is empty");
        }

        public BattleHistory(BattleContext battleContext)
        {
            _battleContext = battleContext;
        }
    }
}
