namespace StackMortalKombat.Interfaces;

public interface IUnit
{
    public uint Id { get; }
    public string Name { get; }
    public int Health { get; }
    public int MaxHP { get; }
    public uint Damage { get; }
    public uint Defense { get; }
    public uint AttackRange { get; }

    public uint Cost { get; }

    public void DamageTaken(uint damageTaken);
/*    public bool IsAbility(); */
}
