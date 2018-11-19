using System;

namespace PreScript.Core
{
    public class ArrayGet : IOperation
    {
        public void Process(IPreScriptState state)
        {
            int n;
            if (!(state.Stack.Pop() as Number).CheckInteger(out n))
            {
                throw new InvalidOperationException("N parameter should be integer");
            }

            var array = (state.Stack.Pop() as Data<IArray<IOperation>>).Value;

            state.Stack.Push(array[n]);
        }
    }
}