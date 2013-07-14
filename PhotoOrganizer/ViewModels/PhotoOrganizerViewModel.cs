using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Ninject;
using PhotoOrganizer.Commands;
using PhotoOrganizer.Commands.Plumbing;

namespace PhotoOrganizer.ViewModels
{
    public class PhotoOrganizerViewModel : BaseViewModel
    {
        private string _directoryPath;
        private int _numberOfFiles;
        private string _statusMessage;
        private IList<FileInfo> _photosToView;

        public ViewModelCommand SetDirectoryCommand { get; set; }

        public ViewModelCommand MovePhotoCommand { get; set; }

        public ViewModelCommand ShowCurrentPhotoCommand { get; set; }

        public ViewModelCommand ShowNextPhotoCommand { get; set; }

        public ViewModelCommand ShowPreviousCommand { get; set; }

        public ViewModelCommand DeleteCurrentPhotoCommand { get; set; }

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

        public int NumberOfFiles
        {
            get { return _numberOfFiles; }
            set
            {
                if (_numberOfFiles == value) return;
                _numberOfFiles = value;
                OnPropertyChanged(x => x.NumberOfFiles);
            }
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                if (_statusMessage == value) return;
                _statusMessage = value;
                OnPropertyChanged(x => x.StatusMessage);
            }
        }

        public IList<FileInfo> PhotosToView
        {
            get { return _photosToView; }
            set
            {
                if(_photosToView == value) return;
                _photosToView = value;
                OnPropertyChanged(x => x.PhotosToView);
            }
        }

        [Inject]
        public PhotoOrganizerViewModel([SetSourceDirectory]ViewModelCommand setDirectoryCommand )
        {
            SetDirectoryCommand = setDirectoryCommand;
            PhotosToView = new List<FileInfo>();
        }

        private void OnPropertyChanged<R>(Expression<Func<PhotoOrganizerViewModel, R>> propertyExpr)
        {
            RaisePropertyChangedEvent(this.GetPropertySymbol(propertyExpr));
        }
    }
}