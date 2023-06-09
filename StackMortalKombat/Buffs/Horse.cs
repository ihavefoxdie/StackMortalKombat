namespace StackMortalKombat.Buffs;

public class Horse : AbstractBuff
{
    public Horse()
    {
        Name = "Horse";
        Attack = 1;
    }

    public override void SetBuff(BuffedUnit unit)
    {
        unit.AppliedBuffs.Add(this);
    }
}
