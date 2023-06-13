using StackMortalKombat.Factories;
using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

namespace StackMortalKombat.Battle
{

    public class BattleContext
    {
        public IStrategy Strategy { get; set; }

        public AbstractUnitFactory Factory { get; set; }

        public List<AbstractUnit> army1 { get; set; }
        public List<AbstractUnit> army2 { get; set; }
        public int TurnNumber { get; set; } = 1;
        public uint Value { get; set; }

        public BattleContext()
        {

        }

        public BattleContext(List<AbstractUnit> army1, List<AbstractUnit> army2, IStrategy strategy, AbstractUnitFactory factory = null)
        {
            this.army1 = army1;
            this.army2 = army2;
            Strategy = strategy;
            if (factory == null)
                Factory = new InfantryFactory();
            else
                Factory = factory;
        }

        public BattleContext(BattleContext previousBattleContext)
        {
            /*army1 = new List<AbstractUnit>(previousBattleContext.army1);
            army1 = previousBattleContext.army1.ToList();
            army2 = new List<AbstractUnit>(previousBattleContext.army2);*/

            army1 = new();
            for (int i = 0; i < previousBattleContext.army1.Count; i++)
            {
                army1.Add(previousBattleContext.army1[i].ReturnCopy());
            }

            army2 = new();
            for (int i = 0; i < previousBattleContext.army2.Count; i++)
            {
                army2.Add(previousBattleContext.army2[i].ReturnCopy());
            }

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

    }
}
