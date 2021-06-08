using System.ComponentModel;
using Ludo.Model;

namespace Ludo
{
    public interface ICellStatusViewModel : INotifyPropertyChanged
    {
        EPlayerColor ColorType { get; }
        EFieldType FieldType { get;  }
    }
}