using StackMortalKombat.Interfaces;

namespace StackMortalKombat.Units;

public class HeavyInfantry : Unit, IHealable
{
    public HeavyInfantry(uint id, string name, int health, int maxHP, uint damage, uint defense, uint cost) : base(id, name, health, maxHP, damage, defense, cost)
    {
    }

    public void ReceiveHealing(uint value)
    {
        if (Health + (int)value >= MaxHP)
            Health = MaxHP;
        else if (Health <= 0)
            return;
        else
            Health += (int)value;
    }

    public override void TakeTurn()
    {
        base.TakeTurn();
    }
}
