using StackMortalKombat.Interfaces;

namespace StackMortalKombat.Units;

internal class Infantry : AbstractUnit, IHealable, IClone<AbstractUnit>
{
    
    public Infantry(uint id, string name, int health, int maxHP, uint damage, uint defense, uint cost) : base(id, name, health, maxHP, damage, defense, cost)
    {
    }

    public AbstractUnit Clone()
    {
        return new Infantry(this.Id, this.Name, this.Health, this.MaxHP, this.Damage, this.Defense, this.Cost);
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

    public override void TakeTurn(AbstractUnit enemy, uint armyCost)
    {
        base.TakeTurn(enemy, armyCost);
    }

    public override Infantry ReturnCopy()
    {
        return new Infantry(this.Id, this.Name, this.Health, this.MaxHP, this.Damage, this.Defense, this.Cost);
    }
}