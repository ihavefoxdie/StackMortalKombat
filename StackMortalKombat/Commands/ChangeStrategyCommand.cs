using StackMortalKombat.Battle;
using StackMortalKombat.Interfaces;

namespace StackMortalKombat.Commands
{
    internal class ChangeStrategyCommand : AbstractCommand
    {
        private IStrategy _newStrategy;
        private IStrategy _oldStrategy;

        public ChangeStrategyCommand(BattleContext battleContext, IStrategy newStrategy = null) : base(battleContext)
        {
            _newStrategy = newStrategy;
            _oldStrategy = battleContext.Strategy;
        }

        public void SetStrategy(IStrategy newStrategy)
        {
            _newStrategy = newStrategy;
        }


        public override void Execute()
        {
            _battleContext.Strategy = _newStrategy;
        }

        public override void Undo()
        {
            _battleContext.Strategy = _oldStrategy;
        }


    }
}
