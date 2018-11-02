using System;

namespace MyFirstCompiler.CodeAnalysis
{
    public enum SyntaxType
    {
        Add, Subtract, Multiply, Devide
    }

    public static class SyntaxTypeHelper
    {
        public static char ToChar(SyntaxType type)
        {
            if (!Enum.IsDefined(typeof(SyntaxType), type)) return '\0';

            if (type == SyntaxType.Add) return '+';
            if (type == SyntaxType.Subtract) return '-';
            if (type == SyntaxType.Multiply) return '*';
            if (type == SyntaxType.Devide) return '/';


            return '\0';
        }
    }
}