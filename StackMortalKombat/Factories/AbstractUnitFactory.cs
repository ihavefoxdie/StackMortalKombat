using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public abstract class AbstractUnitFactory
{
    public abstract int GetCost();
    public string Name { get; set; } = "Undefined";
    public abstract AbstractUnit CreateUnit();

    public AbstractUnitFactory(string name)
    {
        Name = name;
    }
}