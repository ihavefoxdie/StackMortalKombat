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
        Health -= (int)damageTaken;
    }

    public virtual void TakeTurn(AbstractUnit enemy)
    {
        enemy.TakeDamage(Damage);
    }

    public bool IsAlive { get { return (Health > 0); } }
}