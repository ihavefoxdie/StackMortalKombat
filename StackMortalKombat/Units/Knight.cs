namespace StackMortalKombat.Units;

internal class Knight : Unit
{
    public Knight(uint id, string name, int health, int maxHP, uint damage, uint defense, uint cost) : base(id, name, health, maxHP, damage, defense, cost)
    {
    }

    public override void TakeTurn()
    {
        base.TakeTurn();
    }
}