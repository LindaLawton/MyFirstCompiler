﻿using System;
using MyFirstCompiler.CodeAnalysis;

namespace MyFirstCompiler
{
    class Evaluator
    {
        private readonly ExpressionSyntax _root;
        public Evaluator(ExpressionSyntax root)
        {
            this._root = root;
        }
        public int Evaluate()
        {
            return EvaluateExpression(_root);
        }
        private int EvaluateExpression(ExpressionSyntax node)
        {
            if (node is NumberExpressionSyntax n)
                return (int)n.NumberToken.Value;
            if (node is BinaryExpressionSyntax b)
            {
                var left = EvaluateExpression(b.Left);
                var right = EvaluateExpression(b.Right);
                if (b.OperatorToken.Kind == SyntaxKind.AddToken)
                    return left + right;
                else if (b.OperatorToken.Kind == SyntaxKind.SubtractToken)
                    return left - right;
                else if (b.OperatorToken.Kind == SyntaxKind.MultiplyToken)
                    return left * right;
                else if (b.OperatorToken.Kind == SyntaxKind.DivideToken)
                    return left / right;
                else
                    throw new Exception($"Unexpected binary operator {b.OperatorToken.Kind}");
            }
            if (node is ParenthesizedExpressionSyntax p)
                return EvaluateExpression(p.Expression);
            throw new Exception($"Unexpected node {node.Kind}");
        }
    }
}