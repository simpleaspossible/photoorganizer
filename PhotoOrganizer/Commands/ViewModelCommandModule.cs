﻿using Ninject.Modules;

namespace PhotoOrganizer.Commands
{
    public class ViewModelCommandModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ViewModelCommand>().To<SetSourceDirectoryCommand>().WhenTargetHas<SetSourceDirectoryAttribute>();
        }
    }
}