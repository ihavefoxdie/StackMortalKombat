using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public class WalkTheCityFactory : AbstractUnitFactory
{
    private WalkTheCity _city;

    public WalkTheCityFactory() : base("WalkTheCity")
    {
        _city = new(10, 0, 10);
    }

    public override AbstractUnit CreateUnit()
    {
        return new WalkTheCityAdapter(_city);
    }

    public override int GetCost()
    {
        return 10;
    }
}
