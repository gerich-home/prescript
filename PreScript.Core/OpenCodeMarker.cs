using System.Collections.Generic;

namespace PreScript.Core
{
    public class OpenCodeMarker : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var array = new List<IOperation>();

            int deep = 1;

            while (true)
            {
                var item = state.ExecStack.Pop();

                if (item is OpenCodeMarker)
                {
                    deep++;
                }
                else if (item is CloseCodeMarker)
                {
                    if (deep == 1)
                    {
                        state.Stack.Push(new Execute(array));
                        break;
                    }

                    deep--;
                }

                array.Add(item);
            }
        }

        public override string ToString()
        {
            return "{";
        }
    }
}