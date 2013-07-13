using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PhotoOrganizer.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Errors { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected BaseViewModel()
        {
            Errors = new ObservableCollection<string>();
        }

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}