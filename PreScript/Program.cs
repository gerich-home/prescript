using System;
using System.Collections.Generic;
using System.IO;
using PreScript.Core;

namespace PreScript
{
    class Program
    {
        private static readonly CodeParser _codeParser = new CodeParser();

        class RunConfig
        {
            public string FileName;
            public int PageWidth;
            public int PageHeight;
        }

        static void Main(string[] args)
        {
            RunConfig runConfig;
            if (!TryParseArguments(args, out runConfig))
            {
                Usage();
                return;
            }

            var code = File.ReadAllText(args[0]);

            var pageState = new GraphicsState();

            var stack = new LinearList<IOperation>();
            var execStack = new LinearList<IOperation>();
            var dictStack = new LinearList<IDictionary<string, IOperation>>();

            var system = new Dictionary<string, IOperation>();

            system["add"] = new Add();
            system["sub"] = new Substract();
            system["mul"] = new Multiplicate();
            system["div"] = new Divide();
            system["mod"] = new Mod();
            system["def"] = new Define();
            system["for"] = new For();
            system["dup"] = new Duplicate();
            system["index"] = new Index();
            system["pop"] = new Pop();
            system["exch"] = new Exchange();
            system["repeat"] = new Repeat();
            system["array"] = new EmptyArray();
            system["astore"] = new LoadArray();
            system["rand"] = new Rand();
            system["cvi"] = new ConvertToInteger();
            system["copy"] = new Copy();
            system["roll"] = new Roll();
            system["get"] = new ArrayGet();
            system["put"] = new ArrayPut();
            system["ne"] = new NotEqual();
            system["eq"] = new Equal();
            system["or"] = new Or();
            system["ifelse"] = new IfElse();
            system["if"] = new If();
            system["neg"] = new Neg();
            system["not"] = new Not();
            system["sqrt"] = new Sqrt();
            system["lt"] = new LessThan();
            system["ge"] = new GreaterOrEqualThan();

            dictStack.Push(system);


            var graphics = new Dictionary<string, IOperation>();

            graphics["newpath"] = new NewPath(pageState);
            graphics["closepath"] = new ClosePath(pageState);
            graphics["fillpath"] = new FillPath(pageState);
            graphics["setgray"] = new SetGray(pageState);
            graphics["setrgbcolor"] = new SetRGB(pageState);
            graphics["setlinewidth"] = new SetLineWidth(pageState);
            graphics["fill"] = new FillPath(pageState);
            graphics["showpage"] = new ShowPage(pageState);
            graphics["moveto"] = new MoveTo(pageState);
            graphics["lineto"] = new LineTo(pageState);
            graphics["rlineto"] = new RelativeLineTo(pageState);
            graphics["gsave"] = new SaveGraphicsState(pageState);
            graphics["grestore"] = new RestoreGraphicsState(pageState);
            graphics["stroke"] = new StrokePath(pageState);
            graphics["curveto"] = new CurveTo(pageState);
            graphics["arc"] = new Arc(pageState);

            dictStack.Push(graphics);

            dictStack.Push(new Dictionary<string, IOperation>());

            //execStack.Push(start);


            CodeParser.LoadCode(execStack,
@"
/findfont { pop (somefont) } def
/scalefont { exch pop } def
/setfont { pop } def
/setlinecap { pop } def
/srand { pop } def
");

            CodeParser.LoadCode(execStack, code);

            var state = new PreScriptState(stack, execStack, dictStack);

            while (execStack.Count > 0)
            {
                var operation = execStack.Pop();
                operation.Process(state);
            }
        }

        private static bool TryParseArguments(string[] args, out RunConfig runConfig)
        {
            throw new NotImplementedException();
        }

        private static void Usage()
        {
            var appName = Environment.GetCommandLineArgs()[0];
            Console.WriteLine("{0} <post script>", appName.Substring(appName.LastIndexOf('\\') + 1));
        }
    }
}
