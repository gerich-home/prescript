using System;

namespace PreScript.Core
{
    public class Copy : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var argument = state.Stack.Pop();

            var number = argument as Number;
            if (number != null)
            {
                int n;
                if (!number.CheckInteger(out n))
                {
                    throw new InvalidOperationException("N parameter should be integer");
                }

                int top = state.Stack.Count - 1;
                for (int i = top - n + 1; i <= top; i++)
                    state.Stack.Push(state.Stack[i]);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}