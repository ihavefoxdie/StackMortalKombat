using StackMortalKombat.Battle;
using StackMortalKombat.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StackMortalKombat.Commands
{
    internal class PrintArmiesCommand : AbstractCommand
    {


        public PrintArmiesCommand(BattleContext battleContext) : base(battleContext)
        {
        }

        public override void Execute()
        {
            PrintArmy(_battleContext.army1);
            PrintArmy(_battleContext.army2);
        }

        public override void Redo()
        {

        }

        public override void Undo()
        {
            
        }

        private void PrintArmy(List<Unit> units)
        {
            Console.Write("[ ");
            foreach (var item in units)
            {
                Console.Write($"{item.Name} ");
            }
            Console.Write("]");

        }
    }
}
