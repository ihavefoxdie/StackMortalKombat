using StackMortalKombat.Units;
namespace StackMortalKombat.Interfaces;

public interface IClone<T> where T : AbstractUnit
{
    public T Clone();
}
