using System.Collections.Generic;

namespace PhotoOrganizer.Commands
{
    public enum CommandErrorTypes
    {
        Critical,Warning
    }

    public abstract class CustomCommand
    {
        public ParameterResolver ParameterResolver { get; set; }

        public IList<string> CommandErrors { get; protected set; }

        protected CustomCommand()
        {
            ParameterResolver = new ParameterResolver();
            CommandErrors = new List<string>();
        }

        protected abstract bool CanExecute();

        public abstract void Execute();

        protected abstract void SetParameters();
    }
}
