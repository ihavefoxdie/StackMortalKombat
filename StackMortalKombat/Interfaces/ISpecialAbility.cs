namespace StackMortalKombat.Interfaces;

public interface ISpecialAbility
{
    public int SpecialAbilityType { get; }
    public int SpecialAbilityRange { get; }
    public int SpecialAbilityStrength { get; }
    public void CastSpecialAbility();
}

