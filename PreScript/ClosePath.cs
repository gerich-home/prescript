using PreScript.Core;

namespace PreScript
{
    public class ClosePath : IOperation
    {
        private readonly IGraphicsState g;

        public ClosePath(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            g.ClosePath();
        }
    }
}