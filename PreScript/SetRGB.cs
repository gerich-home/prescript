using PreScript.Core;

namespace PreScript
{
    public class SetRGB : IOperation
    {
        private readonly IGraphicsState g;

        public SetRGB(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            var blue = (state.Stack.Pop() as Number).Value;
            var green = (state.Stack.Pop() as Number).Value;
            var red = (state.Stack.Pop() as Number).Value;

            g.Red = red;
            g.Green = green;
            g.Blue = blue;
        }
    }
}