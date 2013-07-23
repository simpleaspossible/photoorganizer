using Ninject.Modules;

namespace PhotoOrganizer.Commands.Plumbing
{
    public class ViewModelCommandModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ViewModelCommand>().To<SetSourceDirectoryCommand>().WhenTargetHas<SetSourceDirectoryAttribute>();
            Bind<ViewModelCommand>().To<ShowCurrentPhotoCommand>().WhenTargetHas<ShowCurrentPhotoCommandAttribute>();
            Bind<ViewModelCommand>().To<ShowNextPhotoCommand>().WhenTargetHas<ShowNextPhotoCommandAttribute>();
            Bind<ViewModelCommand>().To<ShowPreviousPhotoCommand>().WhenTargetHas<ShowPreviousPhotoCommandAttribute>();
        }
    }
}