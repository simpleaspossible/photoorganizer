using System;
using System.IO;
using System.Windows.Forms;
using PhotoOrganizer.Commands.Plumbing;
using PhotoOrganizer.ViewModels;

namespace PhotoOrganizer.Commands
{
    public class SetSourceDirectoryAttribute : Attribute
    {
    }

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
            _viewModel.NumberOfFiles = 0;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog() { ShowNewFolderButton = true };

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _viewModel.Directory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                _viewModel.SelectedDirectory = _viewModel.Directory.FullName;

                if (_viewModel.Directory.GetFiles().Length > 0)
                {
                    foreach (FileInfo file in _viewModel.Directory.GetFiles())
                    {
                        _viewModel.PhotosToView.Add(file);
                        _viewModel.NumberOfFiles++;
                    }
                }

                if (_viewModel.Directory.GetDirectories().Length > 0)
                {
                    _viewModel.StatusMessage = "There are sub-directories that may need to be looked at.";
                }
            }
        }
    }
}