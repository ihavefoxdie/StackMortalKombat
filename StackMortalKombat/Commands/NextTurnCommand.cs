﻿using StackMortalKombat.Battle;

namespace StackMortalKombat.Commands;

internal class NextTurnCommand : AbstractCommand
{
    private readonly BattleContext _oldBattleContext;

    public NextTurnCommand(BattleContext battleContext) : base(battleContext)
    {
        _oldBattleContext = new BattleContext(_battleContext);
    }

    public override void Execute()
    {
        if (_battleContext.TurnNumber % 2 != 0)
        {
            _battleContext.Strategy.MakeTurn(_battleContext.army1, _battleContext.army2);
            _battleContext.Strategy.UseSpecialAbility(_battleContext.army1, _battleContext.army2);
            _battleContext.ClearArmies();
            _battleContext.TurnNumber++;
        }

        else
        {
            _battleContext.Strategy.MakeTurn(_battleContext.army2, _battleContext.army1);
            _battleContext.Strategy.UseSpecialAbility(_battleContext.army2, _battleContext.army1);
            _battleContext.ClearArmies();
        }
    }

    public override void Undo()
    {
        _battleContext.army1 = _oldBattleContext.army1;
        _battleContext.army2 = _oldBattleContext.army2;
        _battleContext.Strategy = _oldBattleContext.Strategy;
        _battleContext.Factory = _oldBattleContext.Factory;
        _battleContext.TurnNumber = _oldBattleContext.TurnNumber;
    }
}
