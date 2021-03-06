﻿using System.Text.RegularExpressions;

namespace CommonMarkSharp.Blocks
{
    public class IndentedCode : LeafBlock
    {
        private static readonly Regex TrailingEmptyLinesRe = new Regex(@"(?:\n *)+$", RegexOptions.Compiled);

        public override bool AcceptsLines { get { return true; } }
        public override bool IsCode { get { return true; } }

        public override void Close(ParserContext context)
        {
            base.Close(context);
            Contents = TrailingEmptyLinesRe.Replace(string.Join("\n", Strings), "") + "\n";
        }

        public override bool MatchNextLine(Subject subject)
        {
            if (subject.Indent >= CommonMarkParser.CODE_INDENT)
            {
                subject.Advance(CommonMarkParser.CODE_INDENT);
            }
            else if (subject.IsBlank)
            {
                subject.AdvanceToFirstNonSpace();
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
