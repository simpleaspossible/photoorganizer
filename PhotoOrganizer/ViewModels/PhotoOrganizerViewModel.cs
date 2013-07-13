using System;
using System.IO;
using System.Linq.Expressions;
using Ninject;
using PhotoOrganizer.Commands;

namespace PhotoOrganizer.ViewModels
{
    public class PhotoOrganizerViewModel : BaseViewModel
    {
        private string _directoryPath;

        public ViewModelCommand SetDirectoryCommand { get; set; }

        public DirectoryInfo Directory { get; set; }

        public string SelectedDirectory
        {
            get { return _directoryPath; }
            set
            {
                if (_directoryPath == value) return;
                _directoryPath = value;
                OnPropertyChanged(x => x.SelectedDirectory);
            }
        }

        [Inject]
        public PhotoOrganizerViewModel([SetSourceDirectory]ViewModelCommand setDirectoryCommand)
        {
            SetDirectoryCommand = setDirectoryCommand;
        }

        private void OnPropertyChanged<R>(Expression<Func<PhotoOrganizerViewModel, R>> propertyExpr)
        {
            RaisePropertyChangedEvent(this.GetPropertySymbol(propertyExpr));
        }
    }
}