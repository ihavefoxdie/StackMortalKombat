using StackMortalKombat.Commands;
using StackMortalKombat.Interfaces;
using StackMortalKombat.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Battle
{
    public class Game
    {
        private BattleContext _battleContext;
        private BattleHistory _battleHistory;
        public AbstractView View;

        public Game(AbstractView view)
        {
            _battleHistory = new BattleHistory(_battleContext);
            View = view;
            View.SetBattleHistory(_battleHistory);
        }

    }
}
