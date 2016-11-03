using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CD_Project
{
    class Program
    {

        static void Main(string[] args)
        {
            Lexer lexer = new Lexer(@"d:\cd.txt");
            Parser parser = new Parser(lexer);
            parser.parse();
            
            Console.WriteLine("Parser Succecflly");
            Console.ReadKey();
        }
    }
}

