using PreScript.Core;

namespace PreScript
{
    public class RestoreGraphicsState : IOperation
    {
        private readonly IGraphicsState g;

        public RestoreGraphicsState(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            g.Restore();
        }
    }
}