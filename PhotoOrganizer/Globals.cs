using Ninject;
using PhotoOrganizer.Commands;

namespace PhotoOrganizer
{
    public class Globals
    {
        private static IKernel _clientKernel;

        public static IKernel ClientKernel { get { return _clientKernel ?? (_clientKernel = new StandardKernel(new ViewModelCommandModule())); } }

    }
}