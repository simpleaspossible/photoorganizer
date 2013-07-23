using System;
using System.IO;
using System.Windows.Forms;
using PhotoOrganizer.Commands.Plumbing;
using PhotoOrganizer.ViewModels;

namespace PhotoOrganizer.Commands
{
    public class SetSourceDirectoryAttribute : Attribute {}

    public class SetSourceDirectoryCommand : ViewModelCommand
    {
        private PhotoOrganizerViewModel _viewModel;

        public override bool CanExecute(object parameter)
        {
            _viewModel = parameter as PhotoOrganizerViewModel;

            return _viewModel != null;
        }

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            _viewModel.NumberOfFiles = 0;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog() { ShowNewFolderButton = true };

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult != DialogResult.OK) return;

            _viewModel.Directory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
            _viewModel.SelectedDirectory = _viewModel.Directory.FullName;

            RecursiveGetFiles(_viewModel.Directory);

            if(_viewModel.ShowCurrentPhotoCommand.CanExecute(_viewModel) && _viewModel.PhotosToView.Count > 0)
            {
                _viewModel.SelectedPhoto = _viewModel.PhotosToView[0];
                _viewModel.ShowCurrentPhotoCommand.Execute(_viewModel);
            }
        }

        private void RecursiveGetFiles(DirectoryInfo dir)
        {
            if (dir.GetFiles().Length > 0)
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    _viewModel.PhotosToView.Add(file);
                    //this prop will eventually be deduced from PhotosToView.Count
                    _viewModel.NumberOfFiles++;
                }
            }

            if (dir.GetDirectories().Length <= 0) return;

            foreach(DirectoryInfo directory in dir.GetDirectories())
            {
                RecursiveGetFiles(directory);
            }
        }
    }
}