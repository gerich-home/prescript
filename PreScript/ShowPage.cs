using PreScript.Core;

namespace PreScript
{
    public class ShowPage : IOperation
    {
        private IGraphicsState g;

        public ShowPage(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            g.ShowPage();
        }
    }
}