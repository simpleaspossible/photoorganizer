using System;
using System.IO;
using System.Windows.Forms;
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
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog(){ShowNewFolderButton = true};

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                _viewModel.Directory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                _viewModel.SelectedDirectory = _viewModel.Directory.FullName;
            }
        }
    }
}