namespace Ludo
{
    public interface ICellStatusViewModel
    {
        EFieldColor ColorType { get; }
        EFieldType FieldType { get;  }
    }
}