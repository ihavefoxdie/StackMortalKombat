using StackMortalKombat.Battle;
using StackMortalKombat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Commands
{
    internal class ChangeStrategyCommand : AbstractCommand
    {
        private IStrategy _newStrategy;
        private IStrategy _oldStrategy;

        public ChangeStrategyCommand(BattleContext battleContext, IStrategy newStrategy) : base(battleContext)
        {
            _newStrategy= newStrategy;
            _oldStrategy= battleContext.Strategy;
        }
        

        public override void Execute()
        {
            _battleContext.Strategy= _newStrategy;
        }

        public override void Undo()
        {
            _battleContext.Strategy = _oldStrategy;
        }

        
    }
}
