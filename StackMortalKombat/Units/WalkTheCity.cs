namespace StackMortalKombat.Units
{
    internal class WalkTheCity
    {
        private readonly int _health;
        private readonly uint _defence;
        private readonly uint _cost;
        private int _currentHealth;

        public readonly double DamageAbsorber;

        public WalkTheCity(int health, uint defence, uint cost, double damageAbsorb = 0.2)
        {
            _defence = defence;
            _health = _currentHealth = health;
            DamageAbsorber = damageAbsorb;
            _cost = cost;
        }

        public uint GetDefence()
        {
            return _defence;
        }

        public uint GetStrength()
        {
            return 0;
        }

        public int GetHealth()
        {
            return _health;
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public uint GetCost()
        {
            return _cost;
        }

        public void TakeDamage(int damage)
        {
            if (_currentHealth == 0)
                throw new Exception("Unit are death!");

            if (damage < 0)
                throw new ArgumentException("Argument must be greater than zero", "damage");

            _currentHealth -= (int)Math.Max(damage - _defence, 0);

            if (_currentHealth < 0)
                _currentHealth = 0;
        }

        public bool IsDead
        {
            get { return _currentHealth <= 0; }
        }
    }
}
