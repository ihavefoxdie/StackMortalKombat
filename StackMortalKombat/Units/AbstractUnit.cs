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
        int damage = (int)damageTaken;
        if (damage > 0)
        {
            if (this is WalkTheCityAdapter)
            {
                Health -= 1;
                return;
            }

            Health -= damage;
        }
    }

    public virtual void TakeTurn(AbstractUnit enemy, uint armyCost)
    {
        decimal damage = (((decimal)armyCost - (decimal)enemy.Defense) * (decimal)Damage) / 100;
        damage = Math.Round(damage, MidpointRounding.AwayFromZero);
        uint roundedDamage = Convert.ToUInt32(damage);
        if (roundedDamage == 0 && this is not WalkTheCityAdapter)
            roundedDamage = 1;



        enemy.TakeDamage(roundedDamage);
    }

    public bool IsAlive { get { return (Health > 0); } }

    public abstract AbstractUnit ReturnCopy();
}