using StackMortalKombat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Units
{
    internal class Knight : IUnit
    {
        public uint Id { get; }

        public string Name { get; }

        public int Health { get; }

        public int MaxHP { get; }

        public uint Damage { get; }

        public uint Defense { get; }

        public uint AttackRange { get; }

        public uint Cost { get; }

        public void DamageTaken(uint damageTaken)
        {
            throw new NotImplementedException();
        }

        public void TakeTurn()
        {
            throw new NotImplementedException();
        }

        public Knight()
        {
            Id = 3;
            Name = "Knight";
            Health = 40;
            MaxHP = 20;
            Damage = 15;
            Defense = 10;
            AttackRange = 3;
            Cost = 2;
        }
    }
}
