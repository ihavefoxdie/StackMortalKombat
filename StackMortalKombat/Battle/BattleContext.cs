using StackMortalKombat.Factories;
using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Battle
{

    //All info about battle, like armies, strategies and so on
    //It is better to use singletone
    public class BattleContext
    {
        public IStrategy Strategy { get; set; }

        public AbstractUnitFactory Factory { get; set; }

        public List<AbstractUnit> army1 { get; set; }
        public List<AbstractUnit> army2 { get; set; }
        public int TurnNumber { get; set; }


        void NextTurn()
        {
            TurnNumber++;
        }

        public BattleContext(List<AbstractUnit> army1, List<AbstractUnit> army2, IStrategy strategy, AbstractUnitFactory factory)
        {
            this.army1 = army1;
            this.army2 = army2;
            Strategy = strategy;
            Factory = factory;
            TurnNumber = 0;
        }

        public void ClearArmies()
        {
            foreach (var item in army1)
            {
                if (!item.IsAlive)
                    army1.Remove(item);
            }

            foreach (var item in army2)
            {
                if (!item.IsAlive)
                    army2.Remove(item);
            }
        }

    }
}
