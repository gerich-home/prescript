using PreScript.Core;

namespace PreScript
{
    public class SaveGraphicsState : IOperation
    {
        private readonly IGraphicsState g;

        public SaveGraphicsState(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            g.Save();
        }
    }
}