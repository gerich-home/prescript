using System.Collections.Generic;
using System.Linq;

namespace PreScript.Core
{
    public class BuildArray : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var array = new LinkedList<IOperation>();
            
            while (true)
            {
                var item = state.Stack.Pop();
                
                if (item is Marker)
                {
                    state.Stack.Push(new Data<IArray<IOperation>>(new Array<IOperation>(array.ToArray())));
                    break;
                }

                array.AddFirst(item);
            }
        }

        public override string ToString()
        {
            return "]";
        }
    }
}