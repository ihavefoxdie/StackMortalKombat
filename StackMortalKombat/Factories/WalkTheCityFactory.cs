using StackMortalKombat.Units;

namespace StackMortalKombat.Factories;

public class WalkTheCityFactory : AbstractUnitFactory
{
    private WalkTheCity _city;

    public WalkTheCityFactory() : base("WalkTheCity")
    {
        _city = new(40, 10, 10 + 40);
    }

    public override AbstractUnit CreateUnit()
    {
        return new WalkTheCityAdapter(_city);
    }

    public override int GetCost()
    {
        return 10 + 40;
    }
}
