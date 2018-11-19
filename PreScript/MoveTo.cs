using PreScript.Core;

namespace PreScript
{
    public class MoveTo : IOperation
    {
        private readonly IGraphicsState g;

        public MoveTo(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            var y = (state.Stack.Pop() as Number).Value;
            var x = (state.Stack.Pop() as Number).Value;

            g.MoveTo(x, y);
        }
    }
}