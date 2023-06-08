using StackMortalKombat.Battle;

namespace StackMortalKombat.Commands
{
    internal class NextTurnCommand : AbstractCommand
    {


        public NextTurnCommand(BattleContext battleContext) : base(battleContext)
        {

        }

        public override void Execute()
        {
            if (_battleContext.TurnNumber % 2 != 0)
            {
                _battleContext.Strategy.MakeTurn(_battleContext.army1, _battleContext.army2);
                _battleContext.Strategy.UseSpecialAbility(_battleContext.army1, _battleContext.army2);
                _battleContext.ClearArmies();
            }

            else
            {
                _battleContext.Strategy.MakeTurn(_battleContext.army2, _battleContext.army1);
                _battleContext.Strategy.UseSpecialAbility(_battleContext.army2, _battleContext.army1);
                _battleContext.ClearArmies();
            }
            
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
