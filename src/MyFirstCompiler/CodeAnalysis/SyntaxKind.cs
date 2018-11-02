namespace MyFirstCompiler.CodeAnalysis
{
    enum SyntaxKind
    {
        NumberToken,
        BadToken,
        WhiteSpaceToken,
        AddToken,
        MultiplyToken,
        DivideToken,
        SubtractToken,
        EndOfFileToken,
        NumberExpression,
        BinaryExpression,
        OpenParenthesisToken,
        CloseParenthesisToken,
        ParenthesizedExpression
    }
}