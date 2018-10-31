using System;
using System.Collections.Generic;
using System.Linq;
//Stack Problems
//Evaluate an expression given only single digits and only 2 operators* and +.
namespace Stack2
{
    class Program
    {
        static int CountSum(string expr)
        {
            //считает результат
            //Evaluate an expression given only single digits and only 2 operators* and +.
            var stack = new Stack<string>();
            for (int i = 0; i < expr.Length; i++)
            {
                string str = Convert.ToString(expr[i]);
                if (expr[i] == '*')
                {
                    if ((i+1) >= expr.Length) return 0;
                    string str1 = Convert.ToString(expr[i+1]);
                    if (int.TryParse(str1, out int num1))
                    {
                        int num = int.Parse(stack.Pop()) * num1;
                        stack.Push(num.ToString());
                    }
                    i = i + 1;
                }
                else if (int.TryParse(str, out int num1))
                    stack.Push(str);
            }
            int result = 0;
            while (stack.Count > 0)
            {
                result += int.Parse(stack.Pop());
             }
            return result;
        }

        //Infix To Postfix
        static string InfixToPostfix(string infix)
        {
            var stack = new Stack<char>();
            string postfix = "";
            for (int i = 0; i < infix.Length; i++)
            {
                char ch = infix[i];
                if (ch == '+' || ch == '*')
                {
                    if (stack.Count > 0 && stack.Peek() == '*') //high precedence
                    {
                        postfix = postfix + stack.Peek();
                        stack.Pop();
                    }
                    stack.Push(ch);
                }
                else if (int.TryParse(ch.ToString(), out int num1))
                    postfix += ch;
                else
                    return "Expression does not contain a number value";
            }
            while (stack.Count > 0) //переносим все из стека в строку
            {
                postfix = postfix + stack.Peek();
                stack.Pop();
            }
            return postfix;
        }

        static void Main()
        {
            string text1 = "4+2*3*3*3";
            string mes = InfixToPostfix(text1);
            Console.WriteLine(mes);
            //int result = CountSum(text1);
            //if (result == 0)
            //    Console.WriteLine("There was encountered an unexpected character or end of the row.");
            //else
            //    Console.WriteLine(text1 + " = " +result);
        }
    }
}
