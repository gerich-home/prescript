namespace PreScript.Core
{
    public class Identifier : IOperation
    {
        public readonly string Name;

        public Identifier(string name)
        {
            Name = name;
        }

        public void Process(IPreScriptState state)
        {
            state.Stack.Push(this);
        }

        public override string ToString()
        {
            return '/' + Name;
        }
    }
}