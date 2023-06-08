using StackMortalKombat.Battle;
using StackMortalKombat.Factories;
using StackMortalKombat.Units;
using System.Diagnostics;

namespace StackMortalKombat.Commands
{
    public class AddUnitCommand : AbstractCommand
    {
        private readonly AbstractUnitFactory _unitFactory;
        private readonly int _armyNumber;
        private AbstractUnit _newUnit;
        
        public AddUnitCommand(BattleContext battleContext, AbstractUnitFactory unit, int armyNumber) : base(battleContext)
        {
            _unitFactory = unit;
            _armyNumber = armyNumber;
            _newUnit = _unitFactory.CreateUnit();
        }

        public override void Execute()
        {
            GetArmyByNumber().Add(_newUnit);
        }


        public override void Undo()
        {
            GetArmyByNumber().Remove(_newUnit);
        }

        //TODO To make out about default branch
        private List<AbstractUnit> GetArmyByNumber()
        {
            switch (_armyNumber)
            {
                case 1:
                    {
                        return _battleContext.army1;

                    }

                case 2:
                    {
                        return _battleContext.army2;

                    }

                default:
                    {
                        Debug.WriteLine("ArmyNumber is incorrect, try again");
                        return null;
                    }

            }

        }
    }
}
