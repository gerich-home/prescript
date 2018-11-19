using PreScript.Core;

namespace PreScript
{
    public class StrokePath : IOperation
    {
        private readonly IGraphicsState g;

        public StrokePath(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            g.StrokePath();
        }
    }
}