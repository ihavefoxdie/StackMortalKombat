using StackMortalKombat.Battle;
using StackMortalKombat.Commands;
using StackMortalKombat.Factories;
using StackMortalKombat.Interfaces;
using StackMortalKombat.Strategies;
using StackMortalKombat.Units;


List<Unit> units1= new List<Unit>();
List<Unit> units2 = new List<Unit>();


BattleContext battleContext = new BattleContext(units1, units2, new StrategyHorizontally(), new InfantryFactory());
BattleHistory battleHistory = new BattleHistory(battleContext);

battleHistory.SetCommand(new AddUnitCommand(battleContext, new HeavyInfantryFactory(), 1));
battleHistory.Execute();
battleHistory.SetCommand(new AddUnitCommand(battleContext, new InfantryFactory(), 2));
battleHistory.Execute();
battleHistory.SetCommand(new AddUnitCommand(battleContext, new HeavyInfantryFactory(), 2));
battleHistory.Execute();

battleHistory.Undo();

battleHistory.SetCommand(new PrintArmiesCommand(battleContext));
battleHistory.Execute();


//KnightFactory knightFactory = new();
//var unit = knightFactory.CreateUnit();
//WitcherFactory witcherFactory = new(unit);
//var witcher = witcherFactory.CreateUnit();
//Console.WriteLine(witcher.Name);
//Console.WriteLine(unit is IClone<Unit>);
//List<Unit> units = new List<Unit>();
//units.Add(((IClone<Unit>)unit).Clone());
//Console.WriteLine(units[0] is IClone<Unit>);
//Console.WriteLine(witcher is IClone<Unit>);

//WalkTheCityAdapter walkTheCityAdapter = new(new WalkTheCity(20, 50, 10, 0.5));
//walkTheCityAdapter.DamageTaken(100);