using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Labb1OOAD.VieModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
