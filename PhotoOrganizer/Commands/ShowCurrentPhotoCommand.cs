using System;
using System.Windows.Media.Imaging;
using PhotoOrganizer.Commands.Plumbing;
using PhotoOrganizer.ViewModels;

namespace PhotoOrganizer.Commands
{
    public class ShowCurrentPhotoCommandAttribute : Attribute {}

    public class ShowCurrentPhotoCommand : ViewModelCommand
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
            
            _viewModel = (PhotoOrganizerViewModel) parameter;

            _viewModel.CurrentImage = new BitmapImage(new Uri(_viewModel.SelectedPhoto.FullName));
        }
    }
}