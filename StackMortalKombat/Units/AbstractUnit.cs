namespace StackMortalKombat.Units;

public abstract class AbstractUnit
{
    public uint Id { get; }
    public string Name { get; }
    public int Health { get; set; }
    public int MaxHP { get; }
    public uint Damage { get; }
    public uint Defense { get; }
    public uint Cost { get; }

    public AbstractUnit(AbstractUnit unit)
    {
        Id = unit.Id;
        Name = unit.Name;
        Health = unit.Health;
        MaxHP = unit.MaxHP;
        Damage = unit.Damage;
        Defense = unit.Defense;
        Cost = unit.Cost;
    }

    public AbstractUnit(uint id, string name, int health, int maxHP, uint damage, uint defense, uint cost)
    {
        Id = id;
        Name = name;
        Health = health;
        MaxHP = maxHP;
        Damage = damage;
        Defense = defense;
        Cost = cost;
    }

    public virtual void TakeDamage(uint damageTaken)
    {
        int damage = (int)damageTaken - (int)Defense;
        if (damage > 0)
            Health -= damage;
    }

    public virtual void TakeTurn(AbstractUnit enemy)
    {
        enemy.TakeDamage(Damage);
    }

    public bool IsAlive { get { return (Health > 0); } }

    public abstract AbstractUnit ReturnCopy();
}