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

        public AddUnitCommand(BattleContext battleContext, AbstractUnitFactory unit, int armyNumber) : base(battleContext)
        {
            _unitFactory = unit;
            _armyNumber = armyNumber;
        }

        public override void Execute()
        {
            switch (_armyNumber)
            {
                case 1:
                    {
                        _battleContext.army1.Add(_unitFactory.CreateUnit());
                        break;
                    }

                case 2:
                    {
                        _battleContext.army2.Add(_unitFactory.CreateUnit());
                        break;
                    }

                default:
                    {
                        Debug.WriteLine("ArmyNumber is incorrect");
                        break;
                    }

            }
        }

        public override void Redo()
        {
            throw new NotImplementedException();
        }

        public override void Undo()
        {
            List<Unit> units = GetArmyByNumber();
            GetArmyByNumber().RemoveAt(GetArmyByNumber().Count - 1);
        }

        //TODO To make out about default branch
        private List<Unit> GetArmyByNumber()
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
