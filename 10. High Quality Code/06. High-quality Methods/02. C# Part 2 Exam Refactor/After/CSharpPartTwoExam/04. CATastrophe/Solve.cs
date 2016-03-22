namespace CATastrophe
{
    using System;
    using System.Text;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public enum Scopes
    {
        Method,
        Loop,
        Conditional
    }

    public static class Solve
    {

        public static Scopes DetermineScope(int matchIndex, string text)
        {
            string[] scopeDeclarations = {"do", "while", "for", "if", "else" };

            int ignoreScopeCount = 0;
            for (int i = matchIndex - 1; i >= 1; i--)
            {
                foreach (var declaration in scopeDeclarations)
                {
                    int startIndex = i - (declaration.Length - 1);
                    if (startIndex < 0)
                    {
                        continue;
                    }

                    string check = text.Substring(startIndex, declaration.Length);
                    if (check.Contains("}"))
                    {
                        i -= declaration.Length + 1;
                        ignoreScopeCount++;
                    }

                    if (check == declaration && char.IsWhiteSpace(text[startIndex - 1]))
                    {
                        if (ignoreScopeCount == 0)
                        {
                            if ((declaration == "if") || (declaration == "else"))
                            {
                                return Scopes.Conditional;
                            }
                            else
                            {
                                return Scopes.Loop;
                            }    
                        }
                        else
                        {
                            ignoreScopeCount--;
                        }
                    }
                }
            }

            return Scopes.Method;
        }

        internal static void Main()
        {
            int lineCount = int.Parse(Console.ReadLine());
            StringBuilder inputBuilder = new StringBuilder();
            for (int i = 0; i < lineCount; i++)
            {
                inputBuilder.AppendLine(Console.ReadLine());
            }

            string input = inputBuilder.ToString();
            Regex findVeriables = new Regex(@"(?:sbyte|byte|short|ushort|int|uint|long|ulong|float|double|decimal|bool|char|string)(?:\s*\?)?\s*([a-z]\w*)");

            List<string> methodScope = new List<string>();
            List<string> loopScope = new List<string>();
            List<string> conditionalScope = new List<string>();

            var foundVariables = findVeriables.Matches(input, 0);

            for (int i = 0; i < foundVariables.Count; i++)
            {
                Scopes scope = Solve.DetermineScope(foundVariables[i].Index, input);

                string variableIdentifier = foundVariables[i].Groups[1].ToString();
                switch (scope)
                {
                    case Scopes.Method:
                        methodScope.Add(variableIdentifier);
                        break;
                    case Scopes.Loop:
                        loopScope.Add(variableIdentifier);
                        break;
                    case Scopes.Conditional:
                        conditionalScope.Add(variableIdentifier);
                        break;
                    default:
                        throw new InvalidEnumArgumentException("Unknown scope.");
                }
            }

            const string normalOutputFormat = "{0} -> {1} -> {2}";
            const string emptyOutputFormat = "{0} -> None";

            const string methodScopeLabel = "Methods";
            string methodOutput;
            if (methodScope.Count > 0)
            {
                methodOutput = string.Format(normalOutputFormat, methodScopeLabel, methodScope.Count, string.Join(", ", methodScope));
            }
            else
            {
                methodOutput = string.Format(emptyOutputFormat, methodScopeLabel);
            }

            const string loopScopeLabel = "Loops";
            string loopOutput;
            if (loopScope.Count > 0)
            {
                loopOutput = string.Format(normalOutputFormat, loopScopeLabel, loopScope.Count, string.Join(", ", loopScope));
            }
            else
            {
                loopOutput = string.Format(emptyOutputFormat, loopScopeLabel);
            }

            const string conditionalScopeLabel = "Conditional Statements";
            string conditionalOutput;
            if (conditionalScope.Count > 0)
            {
                conditionalOutput = string.Format(normalOutputFormat, conditionalScopeLabel, conditionalScope.Count, string.Join(", ", conditionalScope));
            }
            else
            {
                conditionalOutput = string.Format(emptyOutputFormat, conditionalScopeLabel);
            }

            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.AppendLine(methodOutput);
            outputBuilder.AppendLine(loopOutput);
            outputBuilder.AppendLine(conditionalOutput);

            Console.Write(outputBuilder);
        }
    }
}