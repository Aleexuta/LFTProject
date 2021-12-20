using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimbajeProiect
{
    class Arbore
    {
        public Arbore(Expresie root, AtomLexical end)
        {
            Root = root;
            End = end;
        }

        public Expresie Root { get; }
        public AtomLexical End { get; }
    }
}
