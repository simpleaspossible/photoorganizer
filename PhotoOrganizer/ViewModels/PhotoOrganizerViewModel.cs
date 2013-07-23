using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Windows.Controls;
using System.Windows.Media;
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
        private ImageSource _image;
        private FileInfo _selectedPhoto;

        public ViewModelCommand SetDirectoryCommand { get; set; }

        public ViewModelCommand MovePhotoCommand { get; set; }

        public ViewModelCommand ShowCurrentPhotoCommand { get; set; }

        public ViewModelCommand ShowNextPhotoCommand { get; set; }

        public ViewModelCommand ShowPreviousPhotoCommand { get; set; }

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

        public ImageSource CurrentImage
        {
            get { return _image; }
            set
            {
                if (Equals(_image, value)) return;
                _image = value;
                OnPropertyChanged(x => x.CurrentImage);
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

        public FileInfo SelectedPhoto
        {
            get { return _selectedPhoto; }
            set
            {
                if (_selectedPhoto == value) return;
                _selectedPhoto = value;
                OnPropertyChanged(x => x.SelectedPhoto);
            }
        }

        [Inject]
        public PhotoOrganizerViewModel([SetSourceDirectory]ViewModelCommand setDirectoryCommand, [ShowCurrentPhotoCommand]ViewModelCommand showCurrentPhotoCommand, [ShowPreviousPhotoCommand]ViewModelCommand showPrevoiusPhotoCommand, [ShowNextPhotoCommand]ViewModelCommand showNextPhotoCommand)
        {
            SetDirectoryCommand = setDirectoryCommand;
            ShowCurrentPhotoCommand = showCurrentPhotoCommand;
            ShowPreviousPhotoCommand = showPrevoiusPhotoCommand;
            ShowNextPhotoCommand = showNextPhotoCommand;
            PhotosToView = new List<FileInfo>();
        }

        private void OnPropertyChanged<R>(Expression<Func<PhotoOrganizerViewModel, R>> propertyExpr)
        {
            RaisePropertyChangedEvent(this.GetPropertySymbol(propertyExpr));
        }
    }
}