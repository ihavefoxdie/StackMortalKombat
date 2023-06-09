using StackMortalKombat.Units;

namespace StackMortalKombat.Buffs;

public class BuffedHeavyInfantry : BuffedUnit
{
    public BuffedHeavyInfantry(AbstractUnit unit) : base(unit)
    {
    }

    public override BuffedHeavyInfantry ReturnCopy()
    {
        return new BuffedHeavyInfantry(_unit.ReturnCopy());
    }

    private int AccumilateBuffEffect(string key)
    {
        int value = 0;
        switch (key)
        {
            case "Attack":
                for (int i = 0; i < AppliedBuffs.Count; i++)
                {
                    value += AppliedBuffs[i].Attack;
                    AppliedBuffs[i].BuffRemovalChance();
                }
                break;
            case "Defense":
                for (int i = 0; i < AppliedBuffs.Count; i++)
                {
                    value += AppliedBuffs[i].Defense;
                    AppliedBuffs[i].BuffRemovalChance();
                }
                break;
        }
        return value;
    }

    public override void TakeDamage(uint damageTaken)
    {
        int defenseBuff = AccumilateBuffEffect("Defense");
        if ((int)damageTaken - defenseBuff < 0)
        {
            damageTaken = 0;
        }
        else
            damageTaken -= (uint)defenseBuff;
        base.TakeDamage(damageTaken);
    }

    public override void TakeTurn(AbstractUnit enemy, uint armyCost)
    {
        decimal damage = (((decimal)armyCost - (decimal)enemy.Defense) * ((decimal)Damage+AccumilateBuffEffect("Attack")) / 100);
        damage = Math.Round(damage, MidpointRounding.AwayFromZero);
        uint roundedDamage = Convert.ToUInt32(damage);
        if (roundedDamage == 0)
            roundedDamage = 1;
        enemy.TakeDamage(roundedDamage);
    }
}