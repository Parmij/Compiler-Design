using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CD_Project
{
    enum category { variable, function }
    enum categoryType { FingerType, SpineType, SexType }
    class Symbol
    {
        public string s;
        public category Type;
        //public categoryType CT;
        public int ty;
        public override bool Equals(object obj)
        {
            return this.s == ((Symbol)obj).s && this.Type == ((Symbol)obj).Type;
        }
    }

    class SymbolTable
    {
        public List<Symbol> symbol;
        public Stack<List<Symbol>> stackoflist = new Stack<List<Symbol>>();

        Symbol S;

        public void addScope()
        {
            symbol = new List<Symbol>();
            stackoflist.Push(symbol);
        }

        public void removeScope()
        {
            stackoflist.Pop();
        }

        public void insert(string ss, category t, int ty)
        {
            S = new Symbol();
            S.s = ss;
            S.Type = t;
            S.ty = ty;
            symbol = stackoflist.First();
            for (int i = 0; i < symbol.Count; i++)
            {
                Symbol SS = symbol.ElementAt(i);
                string a = SS.s;
                if (SS.s == ss)
                {
                    Console.WriteLine("this lexem is founded befor :  " + S.s);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            symbol.Add(S);
        }
        Symbol SS;
        public bool Search(string ss, category t, out int sty)
        {
            S = new Symbol();
            S.s = ss;
            S.Type = t;
            int x = stackoflist.Count();
            for (int i = 0; i < x; i++)
            {
                symbol = stackoflist.ElementAt(i);
                if (symbol.Contains(S))
                {
                    for (int j = 0; j < symbol.Count; j++)
                    {
                        SS = symbol.ElementAt(j);
                        if (SS.s == S.s && SS.Type == S.Type)
                        {
                            sty = SS.ty;
                            return true;
                        }
                    }          
                    
                }
            }
            sty = -1;
            return false;
        }
    }
}

















//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace CD_Project
//{
//    enum category { variable, function }
//    class Symbol
//    {
//       public string s;
//       public category Type;
//    }
//    class SymbolTable
//    {
//        public Symbol[] symbol = new Symbol[100];
//        public int i = 0;        

//        public void insert(string ss, category t)
//        {
//            if (!search(ss, t))
//            {
//                Console.WriteLine("this lexem is founded befor");
//                Console.ReadKey();
//                Environment.Exit(0);
//            }
//            Symbol S = new Symbol();
//            S.s = ss;
//            S.Type = t;
//            symbol[i++] = S;
//        }
//        public bool search(string sy, category c)
//        {
//            for (int i = 0; i < symbol.Length; i++)
//                if(symbol[i]!=null)
//                    if (symbol[i].s == sy && symbol[i].Type == c)
//                    return false;
//            return true;
//        }
//    }
//}
