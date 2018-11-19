using System;

namespace PreScript.Core
{
    public class Repeat : IOperation
    {
        class RepeatImpl : IOperation
        {
            private int _counter;
            private readonly IOperation _operation;

            public RepeatImpl(int counter, IOperation operation)
            {
                _counter = counter;
                _operation = operation;
            }

            public void Process(IPreScriptState state)
            {
                _counter--;

                if(_counter > 0)
                    state.ExecStack.Push(this);

                state.ExecStack.Push(_operation);
            }
        }

        public void Process(IPreScriptState state)
        {
            var operation = state.Stack.Pop();

            int count;
            if (!(state.Stack.Pop() as Number).CheckInteger(out count))
            {
                throw new InvalidOperationException("Count parameter should be integer");
            }

            if(count > 0)
                state.ExecStack.Push(new RepeatImpl(count, operation));
        }
    }
}