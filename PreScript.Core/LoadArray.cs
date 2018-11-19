namespace PreScript.Core
{
    public class LoadArray : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var arrayOperation = state.Stack.Pop() as Data<IArray<IOperation>>;
            var array = arrayOperation.Value;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = state.Stack.Pop();
            }

            state.Stack.Push(arrayOperation);
        }
    }
}