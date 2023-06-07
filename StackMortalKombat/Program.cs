using StackMortalKombat.Factories;
using StackMortalKombat.Interfaces;
using StackMortalKombat.Units;

KnightFactory knightFactory = new();
var unit = knightFactory.CreateUnit();
WitcherFactory witcherFactory = new(unit);
var witcher = witcherFactory.CreateUnit();
Console.WriteLine(witcher.Name);
Console.WriteLine(unit is IClone<Unit>);
List<Unit> units = new List<Unit>();
units.Add(((IClone<Unit>)unit).Clone());
Console.WriteLine(units[0] is IClone<Unit>);
Console.WriteLine(witcher is IClone<Unit>);

WalkTheCityAdapter walkTheCityAdapter = new(new WalkTheCity(20, 50, 10, 0.5));
walkTheCityAdapter.DamageTaken(100);