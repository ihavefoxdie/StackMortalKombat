using StackMortalKombat.Units;
namespace StackMortalKombat.Interfaces;

public interface IClone<T> where T : Unit
{
    public T Clone();
}
