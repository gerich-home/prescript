namespace PreScript.Core
{
    public class For : IOperation
    {
        private class ForImpl : IOperation
        {
            private double _counter;
            private readonly double _step;
            private readonly double _end;
            private readonly bool _increasing;
            private readonly IOperation _body;

            public ForImpl(double start, double step, double end, IOperation body)
            {
                _increasing = start < end;
                _counter = start;
                _step = step;
                _end = end;
                _body = body;
            }

            public void Process(IPreScriptState state)
            {
                state.Stack.Push(new Number(_counter));
                
                _counter += _step;

                if (!(_increasing && _counter > _end) && !(!_increasing && _counter < _end))
                    state.ExecStack.Push(this);

                state.ExecStack.Push(_body);
            }
        }

        public void Process(IPreScriptState state)
        {
            var body = state.Stack.Pop();
            var b = (state.Stack.Pop() as Number).Value;
            var step = (state.Stack.Pop() as Number).Value;
            var a = (state.Stack.Pop() as Number).Value;

            if (a == b || step == 0 || (a < b && step < 0) || (a > b && step > 0))
                return;

            state.ExecStack.Push(new ForImpl(a, step, b, body));
        }
    }
}