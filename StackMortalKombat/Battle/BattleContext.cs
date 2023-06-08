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

    public class BattleContext
    {
        public IStrategy Strategy { get; set; }

        public AbstractUnitFactory Factory { get; set; }

        public List<AbstractUnit> army1 { get; set; }
        public List<AbstractUnit> army2 { get; set; }
        public int TurnNumber { get; set; }


        public BattleContext(List<AbstractUnit> army1, List<AbstractUnit> army2, IStrategy strategy, AbstractUnitFactory factory)
        {
            this.army1 = army1;
            this.army2 = army2;
            Strategy = strategy;
            Factory = factory;
            TurnNumber = 1;
        }

        public BattleContext(BattleContext previousBattleContext)
        {
            army1= previousBattleContext.army1;
            army2= previousBattleContext.army2;
            Strategy = previousBattleContext.Strategy;
            Factory = previousBattleContext.Factory;
            TurnNumber = previousBattleContext.TurnNumber;
        }

        public void ClearArmies()
        {

            for (int i = 0; i < army1.Count; i++)
            {
                if (!army1.ElementAt(i).IsAlive)
                {
                    army1.Remove(army1.ElementAt(i));
                    i--;
                }
            }

            for (int i = 0; i < army2.Count; i++)
            {
                if (!army2.ElementAt(i).IsAlive)
                {
                    army2.Remove(army2.ElementAt(i));
                    i--;
                }
            }

        }

        public void PrintArmies()
        {
            Console.Write("[ ");
            foreach (var item in army1)
            {
                Console.Write($"{item.Name} ");
            }
            Console.Write("] ");

            Console.Write("[ ");
            foreach (var item in army2)
            {
                Console.Write($"{item.Name} ");
            }

            Console.Write("]");
            Console.WriteLine();
        }

    }
}
