namespace StackMortalKombat.Buffs;

public class Shield : AbstractBuff
{
    public Shield()
    {
        Name = "Shield";
        Defense = 2;
    }

    public override void SetBuff(BuffedUnit unit)
    {
        unit.AppliedBuffs.Add(this);
    }
}
