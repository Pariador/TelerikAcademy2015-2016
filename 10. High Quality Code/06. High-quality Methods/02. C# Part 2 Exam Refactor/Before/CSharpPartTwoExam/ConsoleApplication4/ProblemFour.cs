namespace ProblemFour
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public enum Scopes
    {
        Method,
        Conditional,
        Loop
    }

    //Todo
    internal static class ProblemFour : IEnumerable<int>
    {
        
        private static int a = 5;

        public static readonly string[] primitives = 
        {
            "string",
            "bool",
            "byte",
            "sbyte",
            "short",
            "ushort",
            "int",
            "uint",
            "long",
            "ulong",
            "float",
            "double",
            "decimal",
            "char"
        };

        static List<string> GetIdentifiers(string text, string type)
        {
            char[] endIndentifiers =
            {
                ' ', 
                ';', 
                ',',
                ')',
                '='
            };

            var identifiers = new List<string>();

            int index = -1;
            var strBuilder = new StringBuilder();
            while (true)
            {
                index = text.IndexOf(type, index + 1);
                if (index == -1)
                {
                    break;
                }

                bool another;
                int searchIndex = index + type.Length;

                if (text[searchIndex] == '[' || text[searchIndex] == '<' || text[searchIndex] == '.')
                {
                    continue;
                }

                do
                {
                    another = false;
                    while (searchIndex < text.Length && (text[searchIndex] == ' ' || text[searchIndex] == '?'))
                    {
                        searchIndex++;
                    }

                    if (searchIndex == text.Length - 1)
                    {
                        break;
                    }

                    if (char.IsLower(text[searchIndex]))
                    {
                        while (searchIndex < text.Length && !endIndentifiers.Contains(text[searchIndex]))
                        {
                            strBuilder.Append(text[searchIndex]);
                            searchIndex++;
                        }

                        string identifier = strBuilder.ToString();
                        strBuilder.Clear();
                        if (!ProblemFour.primitives.Contains(identifier))
                        {
                            identifiers.Add(identifier);
                        }

                        if (searchIndex < text.Length && text[searchIndex] == ',')
                        {
                            searchIndex++;
                            another = true;
                        }
                    }
                    
                } while (another);
            }

            return identifiers;
        }
        static List<string> GetPrimitives(string text)
        {
            List<string> result = new List<string>();

            foreach (var type in ProblemFour.primitives)
            {
                result.AddRange(GetIdentifiers(text, type));
            }

            return result;
        }

        static void Main()
        {
            string[] conditionalWords = 
            {
                "if ",
                "if else ",
                "else"
            };

            string[] loopWords = 
            {
                "while ",
                "for ",
                "foreach "
            };

            List<string> methodList = new List<string>();
            List<string> conditionalList = new List<string>();
            List<string> loopList = new List<string>();
            //IEnumerable<string> currentList = methodList;
            Scopes scope = Scopes.Method;


            Stack<Scopes> previuousScopes = new Stack<Scopes>();

            int lineCount = int.Parse(Console.ReadLine());
            for (int c = 0; c < lineCount; c++)
            {
                string line = Console.ReadLine().Trim();

                foreach (var word in conditionalWords)
                {
                    if (line.Contains(word))
                    {
                        previuousScopes.Push(scope);
                        scope = Scopes.Conditional;
                    }
                }

                foreach (var word in loopWords)
                {
                    if (line.Contains(word))
                    {
                        previuousScopes.Push(scope);
                        scope = Scopes.Loop;
                    }
                }

                string trimmedLine = line.Trim();

                if (trimmedLine == "}")
                {
                    if (previuousScopes.Count != 0)
                    {
                        scope = previuousScopes.Pop();
                    }
                }

                switch (scope)
                {
                    case Scopes.Method:
                        methodList.AddRange(GetPrimitives(line));
                        break;
                    case Scopes.Conditional:
                        conditionalList.AddRange(GetPrimitives(line));
                        break;
                    case Scopes.Loop:
                        loopList.AddRange(GetPrimitives(line));
                        break;
                    default:
                        throw new ArgumentException("Switch Error.");
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            //Console.WriteLine("MethodScope:");
            //foreach (var item in methodList)
            //{
            //    Console.WriteLine(item);
            //}
            if (methodList.Count != 0)
            {
                Console.WriteLine(string.Format("Methods -> {0} -> {1}", methodList.Count, string.Join(", ", methodList)));
            }
            else
            {
                Console.WriteLine("Methods -> None");
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (loopList.Count != 0)
            {
                Console.WriteLine(string.Format("Loops -> {0} -> {1}", loopList.Count, string.Join(", ", loopList)));
            }
            else
            {
                Console.WriteLine("Loops -> None");
            }
            
            //Console.WriteLine();
            //Console.WriteLine("ConditionalScope:");
            //foreach (var item in conditionalList)
            //{
            //    Console.WriteLine(item);
            //}

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (conditionalList.Count != 0)
            {
                Console.WriteLine(string.Format("Conditional Statements -> {0} -> {1}", conditionalList.Count, string.Join(", ", conditionalList)));
            }
            else
            {
                Console.WriteLine("Conditional Statements -> None");
            }
            //Console.WriteLine();
            //Console.WriteLine("LoopScope:");
            //foreach (var item in loopList)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}