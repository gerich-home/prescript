using System;
using System.Globalization;
using System.Text;
using PreScript.Core;

namespace PreScript
{
    class CodeParser
    {
        private enum ParseState
        {
            SearchNextToken,
            InsideString,
            EscapingCharacter,
            InsideToken,
            Comment
        }

        private static string LineFrom(string code, int lineStart)
        {
            var nextLine = code.IndexOf('\n', lineStart);
            return nextLine == -1 ? code.Substring(lineStart) : code.Substring(lineStart, nextLine - 1);
        }

        private static bool IsDelimiter(char c)
        {
            return c == '(' || c == ')' || c == '%' || c == '{' || c == '}' || c == '[' || c == ']' || char.IsWhiteSpace(c);
        }

        public static void LoadCode(ILinearList<IOperation> execStack, string code)
        {
            var state = ParseState.SearchNextToken;

            StringBuilder sb = null;
            int tokenStart = -1;
            int linesCount = 1;
            int lineStart = 0;

            for (int i = 0; i < code.Length; i++)
            {
                var c = code[i];

                if (c == '\r')
                {
                    linesCount++;
                    lineStart = i + 1;
                }

                switch (state)
                {
                    case ParseState.SearchNextToken:

                        if (!IsDelimiter(c))
                        {
                            state = ParseState.InsideToken;
                            tokenStart = i;
                            break;
                        }

                        switch (c)
                        {
                            case '(':
                                state = ParseState.InsideString;
                                sb = new StringBuilder();
                                break;
                            case ')':
                                throw new FormatException(string.Format("Unexpected right parenthesis:\n{0}\n{1}^", LineFrom(code, lineStart), new string(' ', i - lineStart)));
                                break;
                            case '{':
                                execStack.InsertAt(0, new OpenCodeMarker());
                                break;
                            case '}':
                                execStack.InsertAt(0, new CloseCodeMarker());
                                break;
                            case '[':
                                execStack.InsertAt(0, new Marker());
                                break;
                            case ']':
                                execStack.InsertAt(0, new BuildArray());
                                break;
                            case '%':
                                state = ParseState.Comment;
                                break;
                        }

                        break;

                    case ParseState.Comment:

                        if (c == '\r' || c == '\n')
                        {
                            state = ParseState.SearchNextToken;
                        }

                        break;

                    case ParseState.InsideString:

                        switch (c)
                        {
                            case '\\':
                                state = ParseState.EscapingCharacter;
                                break;
                            case ')':
                                execStack.InsertAt(0, new Data<string>(sb.ToString()));
                                sb = null;
                                state = ParseState.SearchNextToken;

                                break;

                            case '\r': case '\n':
                                break;

                            default:
                                sb.Append(c);
                                break;
                        }

                        //TODO: handle line break

                        break;
                    case ParseState.EscapingCharacter:

                        switch (c)
                        {
                            case '\\':
                                sb.Append('\\');
                                break;
                            case 'r':
                                sb.Append('\r');
                                break;
                            case 'n':
                                sb.Append('\n');
                                break;
                            case 't':
                                sb.Append('\t');
                                break;
                            case 'b':
                                sb.Append('\b');
                                break;
                            case 'f':
                                sb.Append('\f');
                                break;
                            case '(':
                                sb.Append('(');
                                break;
                            case ')':
                                sb.Append(')');
                                break;
                            default:
                                throw new FormatException(string.Format("Unexpected escape sequence:\n{0}\n{1}^", LineFrom(code, lineStart), new string(' ', i - lineStart)));
                        }
                        
                        state = ParseState.InsideString;

                        break;
                    case ParseState.InsideToken:

                        if (!IsDelimiter(c))
                        {
                            break;
                        }

                        if (code[tokenStart] == '/')
                        {
                            execStack.InsertAt(0, new Identifier(code.Substring(tokenStart + 1, i - tokenStart - 1)));
                        }
                        else
                        {
                            var token = code.Substring(tokenStart, i - tokenStart);
                            double doubleValue;

                            if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleValue))
                            {
                                execStack.InsertAt(0, new Number(doubleValue));
                            }
                            else
                            {
                                execStack.InsertAt(0, new Access(token));
                            }
                        }

                        state = ParseState.SearchNextToken;
                        goto case ParseState.SearchNextToken;

                        break;
                }
            }
        }
    }
}