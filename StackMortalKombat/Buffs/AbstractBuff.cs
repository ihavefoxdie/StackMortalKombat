namespace StackMortalKombat.Buffs;

public abstract class AbstractBuff
{
    public string Name { get; protected set; }
    public int Attack { get; set; } = 0;
    public int Defense { get; set; } = 0;

    public virtual void BuffRemovalChance()
    {
        if (new Random().Next(0, 100) >= 90)
        {
            this.Defense = 0;
            this.Attack = 0;
        }
    }
}
