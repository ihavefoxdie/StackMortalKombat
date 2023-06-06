using StackMortalKombat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMortalKombat.Units
{
    internal class HeavyInfantry : IUnit, IHealable
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

        public void ReceiveHealing(uint value)
        {
            throw new NotImplementedException();
        }

        public HeavyInfantry()
        {
            Id = 2;
            Name = "HeavyInfantry";
            Health = 20;
            MaxHP = 50;
            Damage = 3;
            Defense = 20;
            AttackRange = 3;
            Cost = 10;
        }

    }
}
