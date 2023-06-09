using StackMortalKombat.Interfaces;

namespace StackMortalKombat.Units;

public class Knight : AbstractUnit, IClone<AbstractUnit>
{
    public Knight(uint id, string name, int health, int maxHP, uint damage, uint defense, uint cost) : base(id, name, health, maxHP, damage, defense, cost)
    {
    }

    public AbstractUnit Clone()
    {
        return new Knight(this.Id, this.Name, this.Health, this.MaxHP, this.Damage, this.Defense, this.Cost);
    }

    public override Knight ReturnCopy()
    {
        return new Knight(this.Id, this.Name, this.Health, this.MaxHP, this.Damage, this.Defense, this.Cost);
    }

    public override void TakeTurn(AbstractUnit enemy)
    {
        base.TakeTurn(enemy);
    }
}