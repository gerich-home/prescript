namespace PreScript.Core
{
    public class Not : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var a = (state.Stack.Pop() as Data<bool>).Value;
            state.Stack.Push(new Data<bool>(!a));
        }
    }
}