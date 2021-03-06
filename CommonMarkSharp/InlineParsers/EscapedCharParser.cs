﻿using CommonMarkSharp.Inlines;
using System.Collections.Generic;

namespace CommonMarkSharp.InlineParsers
{
    public class EscapedCharParser : IInlineParser<InlineString>
    {
        public static readonly CharSet PunctuationChars = @"!""#$%&'()*+,-./:;<=>?@[\]^_`{|}~";

        public string StartsWithChars { get { return "\\"; } }

        public bool CanParse(Subject subject)
        {
            return subject.Char == '\\';
        }

        public InlineString Parse(ParserContext context, Subject subject)
        {
            if (!CanParse(subject)) return null;

            if (subject.Char == '\\' && PunctuationChars.Contains(subject[1]))
            {
                subject.Advance(2);
                return new InlineString(subject[-1]);
            }
            return null;
        }
    }
}
