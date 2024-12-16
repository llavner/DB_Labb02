using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace GameManager.Assets.Event
{
    public class ObservebleObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void PropertyChangedAlert([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
