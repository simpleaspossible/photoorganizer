using System.Windows;
using Ninject;
using PhotoOrganizer.ViewModels;

namespace PhotoOrganizer.Views
{
    /// <summary>
    /// Interaction logic for PhotoOrganizer.xaml
    /// </summary>
    public partial class PhotoOrganizerView
    {
        public PhotoOrganizerViewModel ViewModel { get; set; }

        [Inject]
        public PhotoOrganizerView(PhotoOrganizerViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
