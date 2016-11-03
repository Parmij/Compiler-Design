using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CD_Project
{
    class Lexer
    {
        public Char ca;
        public int lineNo;
        private char ch;
        public int i = 0;
        public char[] txt;
        public char[] txt1;

        public Lexer(string path)
        {
            //int x = System.IO.File.
            txt1 = System.IO.File.ReadAllText(path).ToCharArray();
            txt = new char[txt1.Length+1] ;
            txt1.CopyTo(txt,0);
            ch = nextChar();
        }

        public bool isLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        public bool isDigit(char c)
        {
            return (c >= '0' && c <= '9');
        }

        public Token idOrKeyword(string s)
        {
            if (s == "listen")
                return new Token(TokenType.Listen_Type, s);
            else if (s == "kick")
                return new Token(TokenType.Kick_Type, s);
            else if (s == "circulation")
                return new Token(TokenType.Circulation_Type, s);
            else if (s == "heart")
                return new Token(TokenType.Heart_Type, s);
            else if (s == "finger")
                return new Token(TokenType.Finger_Type, s);
            else if (s == "sex")
                return new Token(TokenType.Sex_Type, s);
            else if (s == "spine")
                return new Token(TokenType.Spine_Type, s);
            else if (s == "listenagain")
                return new Token(TokenType.ListenAgain_Type, s);
            else if (s == "inhale")
                return new Token(TokenType.Inhale_Type, s);
            else if (s == "exhale")
                return new Token(TokenType.Exhale_Type, s);
            else if (s == "brain")
                return new Token(TokenType.Brain_Type, s);
            else if (s == "talk")
                return new Token(TokenType.Talk_Type, s);
            else if (s == "man")
                return new Token(TokenType.BoolLiteral_Type, s);
            else if (s == "woman")
                return new Token(TokenType.BoolLiteral_Type, s);
            else if (s == "mouth")
                return new Token(TokenType.Mouth_Type, s);
            else
                return new Token(TokenType.Identifier_Type, s);

        }

        void error(string message)
        {
            Console.Write(message);
            Console.WriteLine("  @Line No:  {0}", lineNo);
            Console.ReadKey();
            Environment.Exit(0);
        }

        public char nextChar()
        {
            if (i < txt.Length)
                ca = txt[i++];
            return ca;
        }
        //int b = 1;
        //public void backToken()
        //{
        //    b = 0;
        //}

        public Token nextToken()
        {
            //if (b == 0)
            //{
            //    b = 1;
            //    return new Token(t,v);
            //}
            do
            {
                switch (ch)
                {
                    case ' ':
                    case '\t':
                    case '\r':
                        ch = nextChar();
                        continue;
                    case '\n':
                        lineNo++;
                        ch = nextChar();
                        continue;
                    case '/':
                        ch = nextChar();
                        if (ch == '/')
                        {
                            do
                            {//comment, loop till the end of the line
                                ch = nextChar();
                            } while (ch != '\n');
                            lineNo++;
                            ch = nextChar();
                            continue;
                        }
                        else if (ch == '*')
                        {
                            while (true)
                            {
                                ch = nextChar();
                                if (ch == '*')
                                {
                                    ch = nextChar();
                                    if (ch == '/')
                                    {
                                        ch = nextChar();
                                        break;
                                    }
                                }
                            }
                        }

                        else//division operation
                            return new Token(TokenType.Divide_Type, "/");
                        continue;
                    case '\'':
                        {
                            char letter = nextChar();
                            ch = nextChar();
                            if (ch != '\'')
                                error("One char charecter is expected.");
                            else
                            {
                                ch = nextChar();
                                //char [] letterString = {letter, '\0'};
                                return new Token(TokenType.CharLiteral_Type, letter.ToString());
                            }
                        }
                        break;

                    case '>':
                        ch = nextChar();
                        if (ch == '=')
                        {
                            ch = nextChar();
                            return new Token(TokenType.GreaterEqual_Type, ">=");
                        }
                        else
                            return new Token(TokenType.Greater_Type, ">");
                    case '<':
                        ch = nextChar();
                        if (ch == '=')
                        {
                            ch = nextChar();
                            return new Token(TokenType.LessEqual_Type, "<=");
                        }
                        else
                        {
                            return new Token(TokenType.Less_Type, "<");
                        }
                    case '|':
                        ch = nextChar();
                        if (ch == '|')
                        {
                            ch = nextChar();
                            return new Token(TokenType.Or_Type, "||");
                        }
                        else
                        {
                            error("Unknown character |");
                        }
                        break;
                    case '&':
                        ch = nextChar();
                        if (ch == '&')
                        {
                            ch = nextChar();
                            return new Token(TokenType.And_Type, "&&");
                        }
                        else
                        {
                            error("Unknown character &");
                        }
                        break;
                    case '!':
                        ch = nextChar();
                        if (ch == '=')
                        {
                            ch = nextChar();
                            return new Token(TokenType.NotEqual_Type, "!=");
                        }
                        else
                            return new Token(TokenType.Not_Type, "!");
                    case ';':
                        ch = nextChar();
                        return new Token(TokenType.Semicolon_Type, ";");
                    case ',':
                        ch = nextChar();
                        return new Token(TokenType.Comma_Type, ",");
                    case '(':
                        ch = nextChar();
                        return new Token(TokenType.LeftParen_Type, "(");
                    case ')':
                        ch = nextChar();
                        return new Token(TokenType.RightParen_Type, ")");
                    case '{':
                        ch = nextChar();
                        return new Token(TokenType.LeftBrace_Type, "{");
                    case '}':
                        ch = nextChar();
                        return new Token(TokenType.RightBrace_Type, "}");
                    case '[':
                        ch = nextChar();
                        return new Token(TokenType.LeftBracket_Type, "[");
                    case ']':
                        ch = nextChar();
                        return new Token(TokenType.RightBracket_Type, "]");
                    case '+':
                        ch = nextChar();
                        return new Token(TokenType.Plus_Type, "+");
                    case '-':
                        ch = nextChar();
                        return new Token(TokenType.Minus_Type, "-");
                    case '*':
                        ch = nextChar();
                        return new Token(TokenType.Multiply_Type, "*");
                    case '^':               
                        ch = nextChar();
                        return new Token(TokenType.Ref_type, "^");                   
                }
                if (isLetter(ch))
                {//identifier or keyword
                    string value = "";
                    while (isLetter(ch) || isDigit(ch))
                    {
                        value += ch;
                        ch = nextChar();
                    }
                    return idOrKeyword(value);
                }
                if (isDigit(ch))
                {//int literal or float literal
                    string number = "";
                    do
                    {
                        number += ch;
                        ch = nextChar();
                    } while (isDigit(ch));
                    if (ch != '.')
                    {//int literal
                        if (isLetter(ch))
                        {
                            string s = "Illeagal identifier name: ";
                            s += number; s += ch;
                            error(s);
                        }
                        return new Token(TokenType.IntLiteral_Type, number);
                    }
                }
                if (ch == '=')
                {//either assignment or equal
                    ch = nextChar();
                    if (ch == '=')
                    {
                        ch = nextChar();
                        return new Token(TokenType.Equals_Type, "==");
                    }
                    else
                        return new Token(TokenType.Assign_Type, "=");
                }
                string msg = "Unknown character:";
                msg += ch;
                error(msg);
            } while (i != txt.Length);
            //if (i == txt.Length)
            return new Token(TokenType.Eof_Type, "EOF");
        }
    }
}
