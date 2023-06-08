using StackMortalKombat.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Commands
{
    internal class ChangeStrategyCommand : AbstractCommand
    {
        public ChangeStrategyCommand(BattleContext battleContext) : base(battleContext)
        {

        }
        

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void Redo()
        {
            throw new NotImplementedException();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }

        
    }
}
