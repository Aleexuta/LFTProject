using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimbajeProiect
{
    abstract class Node
    {
        public abstract TipAtomLexical tip { get; }
        public abstract IEnumerable<Node> getchildrens();
    }
}
