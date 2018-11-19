using PreScript.Core;

namespace PreScript
{
    public class Arc : IOperation
    {
        private readonly IGraphicsState g;

        public Arc(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            var ang2 = (state.Stack.Pop() as Number).Value;
            var ang1 = (state.Stack.Pop() as Number).Value;
            var r = (state.Stack.Pop() as Number).Value;
            var y = (state.Stack.Pop() as Number).Value;
            var x = (state.Stack.Pop() as Number).Value;

            g.Arc(x, y, r, ang1, ang2);
        }
    }
}