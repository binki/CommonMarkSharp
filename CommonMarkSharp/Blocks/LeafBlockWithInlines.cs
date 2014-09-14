﻿using CommonMarkSharp.Inlines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMarkSharp.Blocks
{
    public abstract class LeafBlockWithInlines : LeafBlock
    {
        public IEnumerable<Inline> Inlines { get; set; }
    }
}