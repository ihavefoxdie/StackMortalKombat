using StackMortalKombat.Battle;
using StackMortalKombat.Units;
using System.Collections.Generic;
using System.Diagnostics;

namespace StackMortalKombat.Commands
{
    //Invoker
    public class BattleHistory
    {
        private AbstractCommand _command;
        public Stack<AbstractCommand> undoCommands { get; private set; }
        public Stack<AbstractCommand> redoCommands { get; private set; }

        public bool isGameEnded = false;
        public BattleContext _battleContext { get; set; }

        public void SetCommand(AbstractCommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            if (_command != null)
            {
                _command.Execute();
                undoCommands.Push(_command);
                if ((_battleContext.army1.Count == 0 || _battleContext.army2.Count == 0) || (_battleContext.army1.All(p1 => p1 is WalkTheCityAdapter) && _battleContext.army2.All(p2 => p2 is WalkTheCityAdapter)))
                    isGameEnded = true;
            }
            else
                Debug.WriteLine("Command doesn't exist");
        }

        public void Undo()
        {
            if (undoCommands.Any())
            {
                AbstractCommand command = undoCommands.Pop();
                command.Undo();
                redoCommands.Push(command);
            }

            else
                Debug.WriteLine("UndoStack is empty");
        }

        public void Redo()
        {
            if (redoCommands.Any())
            {
                AbstractCommand command = redoCommands.Pop();
                command.Redo();
                undoCommands.Push(command);
            }

            else
                Debug.WriteLine("RedoStack is empty");
        }

        public BattleHistory(BattleContext battleContext)
        {
            undoCommands = new Stack<AbstractCommand>();
            redoCommands = new Stack<AbstractCommand>();
            _battleContext = battleContext;
        }


    }
}
