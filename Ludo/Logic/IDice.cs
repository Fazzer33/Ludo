namespace Ludo.Model
{
    public interface IDice
    {
        int Result { get; }
        int Role();
    }
}