namespace StackMortalKombat.Buffs;

public class Helmet : AbstractBuff
{
    public Helmet()
    {
        Name = "Helmet";
        Defense = 1;
    }

    public override void SetBuff(BuffedUnit unit)
    {
        unit.AppliedBuffs.Add(this);
    }
}
