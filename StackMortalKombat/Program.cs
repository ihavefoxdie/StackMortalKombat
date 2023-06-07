using StackMortalKombat.Factories;
using StackMortalKombat.Units;
using StackMortalKombat.Interfaces;
using StackMortalKombat.SpecialUnits;

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
