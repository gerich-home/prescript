using PreScript.Core;

namespace PreScript
{
    public class NewPath : IOperation
    {
        private readonly IGraphicsState g;

        public NewPath(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            g.NewPath();
        }
    }
}