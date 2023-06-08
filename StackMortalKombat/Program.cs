using StackMortalKombat.Battle;
using StackMortalKombat.Commands;
using StackMortalKombat.Factories;
using StackMortalKombat.Interfaces;
using StackMortalKombat.Strategies;
using StackMortalKombat.Units;
using StackMortalKombat.View;

ConsoleView consoleView = new();

Game game = new(consoleView);
game.View.StartMenu();
game.View.GameLoop();


//List<AbstractUnit> units1= new List<AbstractUnit>();
//List<AbstractUnit> units2 = new List<AbstractUnit>();


//BattleContext battleContext = new BattleContext(units1, units2, new StrategyHorizontally(), new InfantryFactory());
//BattleHistory battleHistory = new BattleHistory(battleContext);

//battleHistory.SetCommand(new AddUnitCommand(battleContext, new HeavyInfantryFactory(), 1));
//battleHistory.Execute();
//battleHistory.SetCommand(new AddUnitCommand(battleContext, new InfantryFactory(), 2));
//battleHistory.Execute();
//battleHistory.SetCommand(new AddUnitCommand(battleContext, new HeavyInfantryFactory(), 2));
//battleHistory.Execute();
//battleHistory.Undo();
//battleHistory.Redo();
//battleContext.PrintArmies();
//battleHistory.SetCommand(new NextTurnCommand(battleContext));
//battleHistory.Execute();
//battleHistory.SetCommand(new NextTurnCommand(battleContext));
//battleHistory.Execute();
//battleHistory.Undo();
//battleContext.PrintArmies();


//KnightFactory knightFactory = new();
//var unit = knightFactory.CreateUnit();
//WitcherFactory witcherFactory = new(unit);
//var witcher = witcherFactory.CreateUnit();
//Console.WriteLine(witcher.Name);
//Console.WriteLine(unit is IClone<AbstractUnit>);
//List<AbstractUnit> units = new List<AbstractUnit>();
//units.Add(((IClone<AbstractUnit>)unit).Clone());
//Console.WriteLine(units[0] is IClone<AbstractUnit>);
//Console.WriteLine(witcher is IClone<AbstractUnit>);

//WalkTheCityAdapter walkTheCityAdapter = new(new WalkTheCity(20, 50, 10, 0.5));
//walkTheCityAdapter.DamageTaken(100);