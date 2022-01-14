using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CS2ASM
{
    public class Context
    {
        StringBuilder text;

        public Context(StringBuilder sb)
        {
            text = sb;
        }

        internal void Append(string v)
        {
            text.AppendLine(v);
        }
    }
}
