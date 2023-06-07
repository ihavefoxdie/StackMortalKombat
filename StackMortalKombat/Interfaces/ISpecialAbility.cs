﻿using StackMortalKombat.Units;

namespace StackMortalKombat.Interfaces;

public interface ISpecialAbility
{
    #region SpecialAbility related
    public int SpecialAbilityRange { get; }
    public int SpecialAbilityStrength { get; }
    public string SpecialAbilityName { get; }
    public uint SpecialAbilityCost { get; }
    #endregion

    public void CastSpecialAbility(ref List<Unit> unitsFriendly, ref List<Unit> unitsEnemies);
}