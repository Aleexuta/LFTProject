using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimbajeProiect
{
    sealed class ExpresieBinara:Expresie
    {
        public ExpresieBinara(Expresie stg, Expresie drt, AtomLexical oper)
        {
            Stg = stg;
            Drt = drt;
            Oper = oper;
        }
        public AtomLexical Atom { get; }
        public Expresie Stg { get; }
        public Expresie Drt { get; }
        public AtomLexical Oper { get; }

        public override TipAtomLexical tip => TipAtomLexical.ExpresieBinara;

        public override IEnumerable<Node> getchildrens()
        {
            yield return Stg;
            yield return Oper;
            yield return Drt;
        }
    }
}
