using StackMortalKombat.Battle;
using StackMortalKombat.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Commands
{
    internal class ChangeFactoryCommand : AbstractCommand
    {
        private AbstractUnitFactory _newfactory;
        private AbstractUnitFactory _oldfactory;

        public ChangeFactoryCommand(BattleContext battleContext, AbstractUnitFactory unitFactory) : base(battleContext)
        {
            _newfactory = unitFactory;
            _oldfactory = battleContext.Factory;
        }

        public override void Execute()
        {
            _battleContext.Factory = _newfactory;
        }

        public override void Undo()
        {
            _battleContext.Factory = _oldfactory;
        }
    }
}
