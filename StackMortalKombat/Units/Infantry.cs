using StackMortalKombat.Interfaces;

namespace StackMortalKombat.Units
{
    internal class Infantry : IUnit, IHealable
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

        public Infantry()
        {
            Id = 1;
            Name = "Infantry";
            Health = 20;
            MaxHP = 20;
            Damage = 5;
            Defense = 5;
            AttackRange = 3;
            Cost = 2;
        }
    }
}
