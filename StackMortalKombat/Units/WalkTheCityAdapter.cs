namespace StackMortalKombat.Units;

public class WalkTheCityAdapter : AbstractUnit
{
    private WalkTheCity _walkTheCity;

    public WalkTheCityAdapter(WalkTheCity adapteeUnit) : base(10, "WalkTheCity", adapteeUnit.GetCurrentHealth(), adapteeUnit.GetHealth(), adapteeUnit.GetStrength(), adapteeUnit.GetDefence(), adapteeUnit.GetCost())
    {
        _walkTheCity = adapteeUnit;
    }

    public override WalkTheCityAdapter ReturnCopy()
    {
        return new WalkTheCityAdapter(_walkTheCity);
    }

    // Отличие в получаемом дамаге (cтена слегка режет получаемый урон)
    public override void TakeDamage(uint damageTaken)
    {
        if (_walkTheCity.DamageAbsorber > 0 && _walkTheCity.DamageAbsorber < 1)
            Health -= (int)(damageTaken * _walkTheCity.DamageAbsorber);
        else
            base.TakeDamage(damageTaken);
    }

    public override void TakeTurn(AbstractUnit enemy, uint armyCost)
    {
        base.TakeTurn(enemy, armyCost);
    }
}
