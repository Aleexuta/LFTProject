using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimbajeProiect
{
    class Lexer
    {
        private readonly string TextInput;

        private int currentIndex;
        private List<string> errorList;
        public Lexer(string input)
        {
            TextInput = input;
            errorList = new List<string>();
        }

        public List<string> getErrorList()
        {
            return errorList;
        }
        private char getCurrentSymbol
        {
            get
            {
                if (currentIndex >= TextInput.Length)
                    return '\0';

                while (TextInput[currentIndex] == ' ') { incrementIndex(); }
                return TextInput[currentIndex];

            }

        }
        public void restartCount()
        {
            currentIndex = 0;
        }
        private void incrementIndex()
        {
            currentIndex++;
        }
        public string getdeclarname()
        {
            string name = "";
            char curr = getCurrentSymbol;
            while (curr != ' ' && curr != '=' && curr != ',' && curr != ';' && curr!='\0')
            {
                name += curr;
                incrementIndex();
                curr = getCurrentSymbol;
                
            }
            if (curr == '\0')
                errorList.Add(new string("Invalid char"));
            return name;
        }
        public string getValue()
        {
            string appendNr = "";
            if (getCurrentSymbol == '\"')
                incrementIndex();
            while (char.IsDigit(getCurrentSymbol) || getCurrentSymbol=='.' || char.IsLetter(getCurrentSymbol))
            {
                appendNr += getCurrentSymbol;
                incrementIndex();
            }
            if (getCurrentSymbol == '\"')
                incrementIndex();
            return appendNr;
        }
        public List<AtomLexical> getAtomLexical()
        {
            List<AtomLexical> ceva=new List<AtomLexical> { };
                ;
            if (currentIndex >= TextInput.Length)
            {
                ceva.Add( new AtomLexical(TipAtomLexical.TerminatorAtom, "\n", "\n") );
                return ceva;
            }
            if(getCurrentSymbol==';')
            {
                ceva.Add(new AtomLexical(TipAtomLexical.TerminatorAtom, ";", ";"));
                return ceva;
            }
            if(char.IsWhiteSpace(getCurrentSymbol))
            {
                string appendNr = "";
                while (char.IsWhiteSpace(getCurrentSymbol))
                {
                    appendNr += getCurrentSymbol;
                    incrementIndex();
                }
                ceva.Add(new AtomLexical(TipAtomLexical.SpatiuAtom, appendNr, null));
                return ceva;
            }
            if (getCurrentSymbol == '+')
            {
                ceva.Add(new AtomLexical(TipAtomLexical.PlusAtom, "+", null));
                incrementIndex();
                return ceva;
            }
            if (getCurrentSymbol == '-')
            {
                ceva.Add(new AtomLexical(TipAtomLexical.MinusAtom, "-", null));
                incrementIndex();
                return ceva;
            }
            if (getCurrentSymbol == '*')
            {
                ceva.Add( new AtomLexical(TipAtomLexical.InmultireAtom, "*", null));
                incrementIndex();
                return ceva;
            }
            if (getCurrentSymbol == '/')
            { 
                ceva.Add(new AtomLexical(TipAtomLexical.ImpartireAtom, "/", null));
                incrementIndex();
                return ceva;
            }
            if (getCurrentSymbol == '(')
            {
                ceva.Add( new AtomLexical(TipAtomLexical.ParantezaDeschisaAtom, "(", null));
                incrementIndex();
                return ceva;
            }
            if (getCurrentSymbol == ')')
            {
                ceva.Add(new AtomLexical(TipAtomLexical.ParantezaInchisaAtom, ")", null));
                return ceva;
            }
            if(getCurrentSymbol=='=')
            {
                ceva.Add(new AtomLexical(TipAtomLexical.EgalAtom, "=", null)) ;
                incrementIndex();
                return ceva;
            }
            if (char.IsDigit(getCurrentSymbol))
            {
                string appendNr = "";
                while (char.IsDigit(getCurrentSymbol))
                {
                    appendNr += getCurrentSymbol;
                    incrementIndex();
                }
                if (!double.TryParse(appendNr, out double result))
                    errorList.Add("~~~Eroare! Numarul este prea mare. nu putem face conversia la int");

                ceva.Add( new AtomLexical(TipAtomLexical.NumarAtom, "const", result));
                return ceva;
            }
            if (getCurrentSymbol == '\"')
            {
                string value=getValue();
                ceva.Add(new AtomLexical(TipAtomLexical.StringConst, " ", value));
                return ceva;
            }
            if (TextInput.Length>=3 && TextInput.Substring(0, 3) == "int")
            {
                currentIndex += 2;
                do
                {
                    incrementIndex();
                    string name = getdeclarname();
                    if (getCurrentSymbol == '=')
                    {
                        incrementIndex();
                        string value = getValue();
                        AtomLexical nou = new AtomLexical(TipAtomLexical.IntAtom, name, Convert.ToInt32(value));
                        ceva.Add(nou);
                    }
                    else
                    {
                        AtomLexical nou = new AtomLexical(TipAtomLexical.IntAtom, name, 0);
                        ceva.Add(nou);
                    }
                }
                while (getCurrentSymbol == ',');
                if (getCurrentSymbol == ';')
                {
                    incrementIndex();
                    return ceva;
                }
            }
            if (TextInput.Length >= 5 && TextInput.Substring(0, 5) == "float")
            {
                currentIndex += 4;


                do
                {
                    incrementIndex();
                    string name = getdeclarname();
                    if (getCurrentSymbol == '=')
                    {
                        incrementIndex();
                        string value = getValue();
                        AtomLexical nou = new AtomLexical(TipAtomLexical.FloatAtom, name, Convert.ToDouble(value));
                        ceva.Add(nou);
                    }
                    else
                    {
                        AtomLexical nou = new AtomLexical(TipAtomLexical.FloatAtom, name, 0);
                        ceva.Add(nou);
                    }
                }
                while (getCurrentSymbol == ',');
                if (getCurrentSymbol == ';')
                {
                    incrementIndex();
                    return ceva;
                }
            }
            
            if (TextInput.Length >= 6 && TextInput.Substring(0, 6) == "string")
            {
                currentIndex += 5;


                do
                {
                    incrementIndex();
                    string name = getdeclarname();
                    if (getCurrentSymbol == '=')
                    {
                        incrementIndex();

                        string value = getValue();
                        AtomLexical nou = new AtomLexical(TipAtomLexical.StringAtom, name, value);
                        ceva.Add(nou);
                    }
                    else
                    {
                        AtomLexical nou = new AtomLexical(TipAtomLexical.StringAtom, name, 0);
                        ceva.Add(nou);
                    }
                }
                while (getCurrentSymbol == ',');
                if (getCurrentSymbol == ';')
                {
                    incrementIndex();
                    return ceva;
                }
            }
            if (TextInput.Length >= 6 && TextInput.Substring(0, 6) == "double")
            {
                currentIndex += 5;


                do
                {
                    incrementIndex();
                    string name = getdeclarname();
                    if (getCurrentSymbol == '=')
                    {
                        incrementIndex();
                        string value = getValue();
                        AtomLexical nou = new AtomLexical(TipAtomLexical.DoubleAtom, name, Convert.ToDouble(value));
                        ceva.Add(nou);
                    }
                    else
                    {
                        AtomLexical nou = new AtomLexical(TipAtomLexical.DoubleAtom, name, 0);
                        ceva.Add(nou);
                    }
                }
                while (getCurrentSymbol == ',');
                if (getCurrentSymbol == ';')
                {
                    incrementIndex();
                    return ceva;
                }
            }
            {
                //vezi sa pui si varianta de constanta;
                string str = getValue();
                ceva.Add(new AtomLexical(TipAtomLexical.StringConst, str, " "));
                return ceva;

            }

            ceva = new List<AtomLexical> { new AtomLexical(TipAtomLexical.InvalidAtom, " ", null) };
            return ceva;
        }
        public AtomLexical GetAtomLexical()
        {
            
            return new AtomLexical(TipAtomLexical.InvalidAtom, TextInput[currentIndex - 1].ToString(), null);
        }
    }
}
