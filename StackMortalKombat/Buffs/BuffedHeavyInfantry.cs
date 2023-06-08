using StackMortalKombat.Units;

namespace StackMortalKombat.Buffs;

public class BuffedHeavyInfantry : Buff
{
    public BuffedHeavyInfantry(AbstractUnit unit) : base(unit)
    {
    }

    public override void TakeDamage(uint damageTaken)
    {
        if ((int)damageTaken - 2 < 0)
        {
            damageTaken = 0;
        }
        else
            damageTaken -= 2;
        base.TakeDamage(damageTaken);
    }
}