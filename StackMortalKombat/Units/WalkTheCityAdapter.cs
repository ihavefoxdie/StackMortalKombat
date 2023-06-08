namespace StackMortalKombat.Units;

public class WalkTheCityAdapter : Unit
{
    private WalkTheCity _walkTheCity;

    public WalkTheCityAdapter(WalkTheCity adapteeUnit) : base(10, "WalkTheCity", adapteeUnit.GetCurrentHealth(), adapteeUnit.GetHealth(), adapteeUnit.GetStrength(), adapteeUnit.GetDefence(), adapteeUnit.GetCost())
    {
        _walkTheCity = adapteeUnit;
    }

    // Отличие в получаемом дамаге (cтена слегка режет получаемый урон)
    public override void DamageTaken(uint damageTaken)
    {
        if (_walkTheCity.DamageAbsorber > 0 && _walkTheCity.DamageAbsorber < 1)
            Health -= (int)(damageTaken * _walkTheCity.DamageAbsorber);
        else
            base.DamageTaken(damageTaken);
    }

    public override void TakeTurn(Unit enemy)
    {
        base.TakeTurn(enemy);
    }
}
