using StackMortalKombat.Units;

namespace StackMortalKombat.Buffs;

public class BuffedHeavyInfantry : Buff
{
    public BuffedHeavyInfantry(Unit unit) : base(unit)
    {
    }

    public override void DamageTaken(uint damageTaken)
    {
        if ((int)damageTaken - 2 < 0)
        {
            damageTaken = 0;
        }
        else
            damageTaken -= 2;
        base.DamageTaken(damageTaken);
    }
}
