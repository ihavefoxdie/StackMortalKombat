using StackMortalKombat.Battle;

namespace StackMortalKombat.Commands
{
    public abstract class AbstractCommand
    {
        protected BattleContext _battleContext;

        public abstract void Execute();

        public abstract void Undo();

        public AbstractCommand(BattleContext battleContext)
        {
            _battleContext = battleContext;
        }
    }


}

