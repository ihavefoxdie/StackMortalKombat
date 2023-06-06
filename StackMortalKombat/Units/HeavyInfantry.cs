using StackMortalKombat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Units
{
    public class HeavyInfantry : IUnit, ICloneable, IBuffable
    {
        public HeavyInfantry()
        {
        }

        public uint Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public int Health => throw new NotImplementedException();

        public int MaxHP => throw new NotImplementedException();

        public uint Damage => throw new NotImplementedException();

        public uint Defense => throw new NotImplementedException();

        public uint AttackRange => throw new NotImplementedException();

        public uint Cost => throw new NotImplementedException();

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void DamageTaken(uint damageTaken)
        {
            throw new NotImplementedException();
        }

        public void ReceiveBuff()
        {
            throw new NotImplementedException();
        }

        public void TakeTurn()
        {
            throw new NotImplementedException();
        }
    }
}
