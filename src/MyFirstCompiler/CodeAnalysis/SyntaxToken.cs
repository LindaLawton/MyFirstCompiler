using System.Collections.Generic;
using System.Linq;

namespace MyFirstCompiler.CodeAnalysis
{
    class SyntaxToken : SyntaxNode
    {
        public override SyntaxKind Kind { get; }
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            return Enumerable.Empty<SyntaxNode>();
        }

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