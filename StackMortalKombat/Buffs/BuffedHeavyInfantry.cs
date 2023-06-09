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

    private void BuffRemoval()
    {
        for (int i = 0; i < AppliedBuffs.Count; i++)
        {
            if (new Random().Next(0, 100) >= 90)
            {
                AppliedBuffs[i].Defense = 0;
                AppliedBuffs[i].Attack = 0;
            }
        }
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
                }
                break;
            case "Defense":
                for (int i = 0; i < AppliedBuffs.Count; i++)
                {
                    value += AppliedBuffs[i].Defense;
                }
                break;
        }
        return value;
    }

    public override void TakeDamage(uint damageTaken)
    {
        BuffRemoval();
        int defenseBuff = AccumilateBuffEffect("Defense");
        if ((int)damageTaken - defenseBuff < 0)
        {
            damageTaken = 0;
        }
        else
            damageTaken -= (uint)defenseBuff;
        base.TakeDamage(damageTaken);
    }

    public override void TakeTurn(AbstractUnit enemy)
    {
        enemy.TakeDamage(_unit.Damage + (uint)AccumilateBuffEffect("Attack"));
    }
}