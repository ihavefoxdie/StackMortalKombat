namespace StackMortalKombat.Units;

public abstract class Unit
{
    public uint Id { get; }
    public string Name { get; }
    public int Health { get; set; } 
    public int MaxHP { get; }
    public uint Damage { get; }
    public uint Defense { get; }
    public uint Cost { get; }


    public Unit(uint id, string name, int health, int maxHP, uint damage, uint defense, uint cost)
    {
        Id = id;
        Name = name;
        Health = health;
        MaxHP = maxHP;
        Damage = damage;
        Defense = defense;
        Cost = cost;
    }


    public virtual void DamageTaken(uint damageTaken)
    {
        Health -= (int)damageTaken;
    }

    public virtual void TakeTurn(Unit enemy)
    {
        enemy.Health -= (int)Damage;
    }
}