using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimbajeProiect
{
    sealed class ExpresieNumerica : Expresie
    {
        public ExpresieNumerica(AtomLexical atom)
        {
            Atom = atom;
        }

        public override TipAtomLexical tip => TipAtomLexical.NumarAtom;

        public AtomLexical Atom { get; }

        public override IEnumerable<Node> getchildrens()
        {
            yield return Atom;
        }

    }
}
