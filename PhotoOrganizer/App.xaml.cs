using System.Windows;
using Ninject;
using PhotoOrganizer.Views;

namespace PhotoOrganizer
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Globals.ClientKernel.Get<PhotoOrganizerView>().Show();
        }
    }
}
