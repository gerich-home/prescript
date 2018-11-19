using PreScript.Core;

namespace PreScript
{
    public class FillPath : IOperation
    {
        private readonly IGraphicsState g;

        public FillPath(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            g.FillPath();
        }
    }
}