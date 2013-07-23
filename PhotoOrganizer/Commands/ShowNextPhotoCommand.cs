using System;
using PhotoOrganizer.Commands.Plumbing;
using PhotoOrganizer.ViewModels;

namespace PhotoOrganizer.Commands
{
    public class ShowNextPhotoCommandAttribute : Attribute {}

    public class ShowNextPhotoCommand : ViewModelCommand
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

            _viewModel.SelectedPhoto = _viewModel.PhotosToView[_viewModel.PhotosToView.IndexOf(_viewModel.SelectedPhoto) + 1];

            _viewModel.ShowCurrentPhotoCommand.Execute(parameter);
        }
    }
}