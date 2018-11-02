namespace MyFirstCompiler.CodeAnalysis
{
    internal class SyntaxToken : SyntaxNode
    {
        public SyntaxKind Kind { get; }
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }

        public SyntaxToken(SyntaxKind kind, int position, string text, object value)
        {
            Kind = kind;
            Position = position;
            Text = text;
            Value = value;
        }

        public SyntaxToken(SyntaxKind kind, int position, char text, object value) : this(kind, position, text.ToString(), value) 
        {
            
        }
    }
}