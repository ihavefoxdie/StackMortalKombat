using StackMortalKombat.Interfaces;
using System.Runtime.CompilerServices;

namespace StackMortalKombat.Units;

public class HeavyInfantry : AbstractUnit, IHealable, IClone<AbstractUnit>
{

    public HeavyInfantry(uint id, string name, int health, int maxHP, uint damage, uint defense, uint cost) : base(id, name, health, maxHP, damage, defense, cost)
    {
    }

    public AbstractUnit Clone()
    {
        return new HeavyInfantry(this.Id, this.Name, this.Health, this.MaxHP, this.Damage, this.Defense, this.Cost);
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

    public override void TakeTurn(AbstractUnit enemy)
    {
        base.TakeTurn(enemy);
    }
}