using StackMortalKombat.Units;

namespace StackMortalKombat.Buffs;

public abstract class AbstractBuff
{
    public string Name { get; protected set; }
    public int Attack { get; set; } = 0;
    public int Defense { get; set; } = 0;

    public abstract void SetBuff(BuffedUnit unit);
}
