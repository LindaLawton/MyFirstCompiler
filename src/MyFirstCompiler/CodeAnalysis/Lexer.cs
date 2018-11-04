using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyFirstCompiler.CodeAnalysis
{
    // a Lexer takes a string and brakes into words.  
    class Lexer
    {
        private readonly string _text;
        private int _position;

        public Lexer(string text)
        {
            _text = text;
        }

        private char Current
        {
            get
            {
                if (_position >= _text.Length) return '\0';
                return _text[_position];
            }
        }
        private void Next()
        {
            _position++;
        }

        private bool MatchCharToSyntaxTypes(char current, SyntaxType type)
        {
            return current == SyntaxTypeHelper.ToChar(type);
        }


        public SyntaxToken NextToken()
        {
            // <numbers>
            // + - * / 
            // <whitespace>

            if (_position >= _text.Length)
            {
                return new SyntaxToken(SyntaxKind.EndOfFileToken, _position, "\0", null);
            }

            if (char.IsDigit((Current)))
            {
                var start = _position;

                while (char.IsDigit(Current))
                    Next();

                var length = _position - start;
                var text = _text.Substring(start, length);
                int.TryParse(text, out var value);
                return new SyntaxToken(SyntaxKind.NumberToken, _position, text, value);
            }

            if (char.IsWhiteSpace(Current))
            {
                var start = _position;
                while (char.IsWhiteSpace(Current))
                    Next();

                var length = _position - start;
                var text = _text.Substring(start, length);
                return new SyntaxToken(SyntaxKind.WhiteSpaceToken, start, text, null);
            }

            // TODO not happy with SyntaxTypeHelper.ToString(SyntaxType.Add) I should be able to just send Current casted as a string.
            var current = Current;

            if (MatchCharToSyntaxTypes(current, SyntaxType.Add))
                return new SyntaxToken(SyntaxKind.AddToken, _position++, current, null);
            if (MatchCharToSyntaxTypes(current, SyntaxType.Subtract))
                return new SyntaxToken(SyntaxKind.MultiplyToken, _position++, current, null);
            if (MatchCharToSyntaxTypes(Current, SyntaxType.Multiply))
                return new SyntaxToken(SyntaxKind.DivideToken, _position++, current, null);
            if (MatchCharToSyntaxTypes(Current, SyntaxType.Devide))
                return new SyntaxToken(SyntaxKind.SubtractToken, _position++, current, null);

            return new SyntaxToken(SyntaxKind.BadToken, _position++, _text.Substring(_position - 1, 1), null);
        }

    }


}
