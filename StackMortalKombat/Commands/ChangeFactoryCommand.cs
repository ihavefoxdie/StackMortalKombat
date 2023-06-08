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
        private readonly AbstractUnitFactory _factory;

        public ChangeFactoryCommand(BattleContext battleContext, AbstractUnitFactory unitFactory) : base(battleContext)
        {
            _factory = unitFactory;
        }

        public override void Execute()
        {
            _battleContext.Factory = _factory;
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
