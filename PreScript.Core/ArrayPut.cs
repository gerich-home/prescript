using System;

namespace PreScript.Core
{
    public class ArrayPut : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var item = state.Stack.Pop();

            int n;
            if (!(state.Stack.Pop() as Number).CheckInteger(out n))
            {
                throw new InvalidOperationException("N parameter should be integer");
            }

            var array = (state.Stack.Pop() as Data<IArray<IOperation>>).Value;

            array[n] = item;
        }
    }
}