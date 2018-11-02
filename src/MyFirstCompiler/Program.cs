using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using MyFirstCompiler.CodeAnalysis;

namespace MyFirstCompiler
{
    // 1 + 2 * 3
    //   +
    //  / \ 
    // 1   *
    //    / \
    //   2   3

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write(">");
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) return;

                var lexer = new Lexer(line);
                while (true)
                {
                    var token = lexer.NextToken();
                    if (token.Kind == SyntaxKind.EndOfFileToken) break;
                    Console.Write($"{token.Kind}: {token.Text}");
                    if(token.Value != null)
                        Console.Write($": {token.Value}");

                    Console.WriteLine();
                }

            }
        }
    }




    sealed class SyntaxTree
    {
        public SyntaxTree(IEnumerable<string> diagnostics, ExpressionSyntax root, SyntaxToken endOfFileToken)
        {
            Diagnostics = diagnostics.ToArray();
            Root = root;
            EndOfFileToken = endOfFileToken;
        }
        public IReadOnlyList<string> Diagnostics { get; }
        public ExpressionSyntax Root { get; }
        public SyntaxToken EndOfFileToken { get; }
        public static SyntaxTree Parse(string text)
        {
            var parser = new Parser(text);
            return parser.Parse();
        }
    }

    abstract class SyntaxNode
    {
        public abstract  SyntaxKind Kind { get;  }

        public abstract IEnumerable<SyntaxNode> GetChildren();
    }

    abstract class ExpressionSyntax : SyntaxNode
    {

    }

    sealed class NumberExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken NumberToken { get; }
        public override SyntaxKind Kind => SyntaxKind.NumberExpression;
        public override IEnumerable<SyntaxNode> GetChildren()
        {
            throw new NotImplementedException();
        }

        public NumberExpressionSyntax(SyntaxToken numberToken)
        {
            NumberToken = numberToken;
        }
    }

    sealed class BinaryExpressionSyntax : ExpressionSyntax
    {
        public ExpressionSyntax Left { get; }
        public SyntaxToken OperatorToken { get; }
        public ExpressionSyntax Right { get; }

        public BinaryExpressionSyntax(ExpressionSyntax left, SyntaxToken operatorToken, ExpressionSyntax right)
        {
            Left = left;
            OperatorToken = operatorToken;
            Right = right;
        }

        public override SyntaxKind Kind => SyntaxKind.BinaryExpression;
        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return Left;
            yield return OperatorToken;
            yield return Right;
        }
    }


}

// a Lexer takes a string and brakes into works.  parser makes sentinces.