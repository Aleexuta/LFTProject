using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimbajeProiect
{
    public enum TipAtomLexical
    {
        NumarAtom,
        SpatiuAtom,
        PlusAtom,
        MinusAtom,
        InmultireAtom,
        ImpartireAtom,
        ParantezaDeschisaAtom,
        ParantezaInchisaAtom,
        InvalidAtom,
        TerminatorAtom,
        IntAtom,
        FloatAtom,
        DoubleAtom,
        StringAtom,
        EgalAtom,
        ExpresieBinara,
        ExpresieParanteza,
        DataAtom,
        StringConst
    }
    class AtomLexical : Node
    {
        public TipAtomLexical type { get; set; }
        public String name { get; set; }
        public object value { get; set; }

        public override TipAtomLexical tip => type;

        public AtomLexical(TipAtomLexical tip, String nume, object valoare)
        {
            type = tip;
            name = nume;
            value = valoare;
        }

        public override IEnumerable<Node> getchildrens()
        {
            return Enumerable.Empty<Node>();
        }
    }
}
