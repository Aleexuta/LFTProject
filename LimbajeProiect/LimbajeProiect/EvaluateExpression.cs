using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimbajeProiect
{
    class EvaluateExpression
    {
        private readonly Expresie expresie;
        public EvaluateExpression(Expresie exp)
        {
            expresie = exp;
        }
        private double EvalueazaNumber(Expresie exp)
        {
            if (exp is ExpresieNumerica n)
            {
                if (n.Atom.tip == TipAtomLexical.IntAtom)
                    return Convert.ToDouble( n.Atom.value);
                if (n.Atom.tip == TipAtomLexical.FloatAtom)
                    return Convert.ToDouble(n.Atom.value);
                if (n.Atom.tip == TipAtomLexical.DoubleAtom)
                    return (double)n.Atom.value;
                if (n.Atom.tip == TipAtomLexical.StringAtom)
                    throw new Exception("Invalid Datatypes.Expected <number> got <string>");
                if (n.Atom.tip == TipAtomLexical.StringConst)
                    throw new Exception("Invalid Datatypes.Expected <number> got <string>");
                if (n.Atom.tip == TipAtomLexical.NumarAtom)
                    return Convert.ToDouble(n.Atom.value);
            }
            if (exp is ExpresieParanteze p)
            {
                return EvalueazaNumber(p.exp);
            }
            if (exp is ExpresieBinara b)
            {
                var stg = b.Stg;
                var dr = b.Drt;
                var op = b.Oper;
                if (op.tip == TipAtomLexical.PlusAtom)
                {
                    return EvalueazaNumber(stg) + EvalueazaNumber(dr);
                }
                if (op.tip == TipAtomLexical.MinusAtom)
                {
                    return EvalueazaNumber(stg) - EvalueazaNumber(dr);
                }
                if (op.tip == TipAtomLexical.ImpartireAtom)
                {
                    return EvalueazaNumber(stg) / EvalueazaNumber(dr);
                }
                if (op.tip == TipAtomLexical.InmultireAtom)
                {
                    return EvalueazaNumber(stg) * EvalueazaNumber(dr);
                }
            }
            //eroare;
            throw new Exception("Expresie invalida");
        }

        private string EvalueazaString(Expresie exp)
        {
            if (exp is ExpresieNumerica n)
            {
                if (n.Atom.tip == TipAtomLexical.IntAtom)
                    return Convert.ToString( n.Atom.value);
                if (n.Atom.tip == TipAtomLexical.FloatAtom)
                    return Convert.ToString(n.Atom.value);
                if (n.Atom.tip == TipAtomLexical.DoubleAtom)
                    return Convert.ToString(n.Atom.value);
                if (n.Atom.tip == TipAtomLexical.StringAtom)
                    return (string)n.Atom.value;
                if (n.Atom.tip == TipAtomLexical.StringConst)
                    return (string)n.Atom.value;
                if (n.Atom.tip == TipAtomLexical.NumarAtom)
                    return Convert.ToString(n.Atom.value);
            }
            if (exp is ExpresieParanteze p)
            {
                return EvalueazaString(p.exp);
            }
            if (exp is ExpresieBinara b)
            {
                var stg = b.Stg;
                var dr = b.Drt;
                var op = b.Oper;
                if (op.tip == TipAtomLexical.PlusAtom)
                {
                    return EvalueazaString(stg) + EvalueazaString(dr);
                }
                if (op.tip == TipAtomLexical.MinusAtom)
                {
                    throw new Exception("Invalid operation for <string>");
                }
                if (op.tip == TipAtomLexical.ImpartireAtom)
                {
                    throw new Exception("Invalid operation for <string>");
                }
                if (op.tip == TipAtomLexical.InmultireAtom)
                {
                    throw new Exception("Invalid operation for <string>");
                }
            }
            //eroare;
            throw new Exception("Expresie invalida");
        }
        public double getEvaluationNumber => EvalueazaNumber(expresie);
        public string getEvaluationString => EvalueazaString(expresie);
    }
}
