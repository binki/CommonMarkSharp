﻿using CommonMarkSharp.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarkSharp.BlockParsers
{
    public interface IBlockParser<out T>
        where T: class
    {
        bool Parse(ParserContext context, Subject subject);
    }
}