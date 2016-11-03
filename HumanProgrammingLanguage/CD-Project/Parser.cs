using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CD_Project
{
    class Parser
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter("d:\\cd1.txt");

        public Lexer lexer;
        public Token currentToken;
        SymbolTable symboltable = new SymbolTable();    //Symantic
        string stringST;                                //Symantic
        int ty;                                         //Symantic
        int ex;                                         //Symantic
        int stype;                                      //Symantic
        public Parser(Lexer lxr)
        {
            lexer = lxr;
        }
        //~Parser()
        //{
        //    file.Close();
        //}
        /*void error(Token tok)
        {
            Console.WriteLine("Syntax error : expecting {0} ; saw : {1} ", tok.value, currentToken.value);
            Console.ReadKey();
            return;
        }

        void error(string msg, Token t)
        {
            Console.WriteLine("Syntax error : ", msg);
            Console.WriteLine("@ token : {0} ", t.value);
            Console.ReadKey();
            return;
        }

        void match(Token tok)
        {
            if (currentToken.type == tok.type)
                currentToken = lexer.nextToken();
            else
                error(tok);
        } */                                    /*****************************/


        void error(string msg)
        {
            Console.WriteLine("Error : " + msg);
            Console.ReadKey();
            return;
        }

        void match(TokenType type)
        {
            if (currentToken.type == type)
                currentToken = lexer.nextToken();
            else
            {
                error("Expecting token : " + type);
            }
        }

        public void parse()
        {
            program();
            file.Close();
        }

        
        //Program       ---->  \{ Type FunOrMain \}
        void program()
        {
            symboltable.addScope();
            currentToken = lexer.nextToken();
            while (isType(out ty))
            {
                currentToken = lexer.nextToken();
                FunOrMain();
            }
            if (currentToken.type != TokenType.Eof_Type)
                error("errooooooor");
        }
        /*void program()
        {
            currentToken = lexer.nextToken();
            x();
            Main();
            if (currentToken.type != TokenType.Eof_Type)
                error("errrrrrrrrrrrrrrrr");
        }
        void x(){
            if (currentToken.type == TokenType.Identifier_Type)
                FunOrGlobal();
            else
                currentToken = lexer.nextToken();
        }*/
        
        string identifier;
        //FunOrMain     ----> Identifier FunOrGlobal | Main
        void FunOrMain()
        {
            if (currentToken.type == TokenType.Identifier_Type)
            {
                stringST = currentToken.value;
                identifier = currentToken.value;
                currentToken = lexer.nextToken();
                FunOrGlobal();
            }
            else
                Main();
        }

        //FunOrGlobal   ---->  Function | Global
        void FunOrGlobal()
        {
            if (currentToken.type == TokenType.LeftParen_Type)
            {
                Function();
            }
            else
                Global();
        }

        //Function      ---->  ( Parameters ) { Statements } 
        void Function()
        {
            string ff = stringST;
            symboltable.insert(stringST, category.function, ty);                    //Symantic
            symboltable.addScope();
            match(TokenType.LeftParen_Type);
            Parameters();
            match(TokenType.RightParen_Type);
            match(TokenType.LeftBrace_Type);
            Statements();
            symboltable.Search(ff, category.function, out stype);
            if (stype != 3)
                ReturnStatement();
            match(TokenType.RightBrace_Type);
            symboltable.removeScope();
           
        }

        //Global        ---->  \{ [ finger ] \} \{ , identifier \{ [ finger ] \} \} ;
        void Global()
        {
            symboltable.insert(stringST, category.variable, ty);                    //Symantic
            while (currentToken.type == TokenType.LeftBracket_Type)
            {
                currentToken = lexer.nextToken();
                match(TokenType.IntLiteral_Type);
                match(TokenType.RightBracket_Type);
            }
            while (currentToken.type == TokenType.Comma_Type)
            {
                currentToken = lexer.nextToken();
                if (currentToken.type == TokenType.Identifier_Type)
                {
                    stringST = currentToken.value;
                    symboltable.insert(stringST, category.variable, ty);            //Symantic
                    currentToken = lexer.nextToken();
                }
                while (currentToken.type == TokenType.LeftBracket_Type)
                {
                    currentToken = lexer.nextToken();
                    match(TokenType.IntLiteral_Type);
                    match(TokenType.RightBracket_Type);
                }
            }
            match(TokenType.Semicolon_Type);
        }

        //Parameters    --- >  \[ Parameter \{ , Parameter \} \] 
        void Parameters()
        {
            if (isType(out ty))
            {
                Parameter();
                while (currentToken.type == TokenType.Comma_Type)
                {
                    currentToken = lexer.nextToken();
                    Parameter();
                }
            }
        }

        //Parameter     ---->  Type \[ ^ \] Identifier 
        void Parameter()
        {
            if (isType(out ty))
            {
                currentToken = lexer.nextToken();
                if(currentToken.type==TokenType.Ref_type)
                    currentToken = lexer.nextToken();
                if (currentToken.type == TokenType.Identifier_Type)
                {
                    stringST = currentToken.value;
                    symboltable.insert(stringST, category.variable, ty);            //Symantic
                    currentToken = lexer.nextToken();
                }
                else
                    error("you should define Identifier !");
            }
        }

        //Main          ---->  heart ( ) { Statements } 
        void Main()
        {
            symboltable.insert("heart", category.function, ty);                    //Symantic
            symboltable.addScope();
            match(TokenType.Heart_Type);
            match(TokenType.LeftParen_Type);
            match(TokenType.RightParen_Type);
            match(TokenType.LeftBrace_Type);
            Statements();
            match(TokenType.RightBrace_Type);
            symboltable.removeScope();
        }

        //Declarations  ---->  \{ Declaration \}
        void Declarations()
        {
            while (isType(out ty))
            {
                Declaration();
            }
        }

        //Declaration   ---->  type Identifier \{ [ finger ] \} \{ , identifier \{ [ finger ] \} \} ;
        void Declaration()
        {
            //string ttt = newlbl();
            //Console.WriteLine(ttt);
             
            if (isType(out ty))
                Type();
            if (currentToken.type == TokenType.Identifier_Type)
            {
                stringST = currentToken.value;
                symboltable.insert(stringST, category.variable, ty);            //Symantic
                currentToken = lexer.nextToken();
            }
            else
                error("you should define Identifier !");
            while(currentToken.type == TokenType.LeftBracket_Type)
            {
                currentToken = lexer.nextToken();
                match(TokenType.IntLiteral_Type);
                match(TokenType.RightBracket_Type);
            }
            while (currentToken.type == TokenType.Comma_Type)
            {
                currentToken = lexer.nextToken();
                if (currentToken.type == TokenType.Identifier_Type)     
                {
                    stringST = currentToken.value;
                    symboltable.insert(stringST, category.variable, ty);        //Symantic
                    currentToken = lexer.nextToken();
                }
                else
                    error("you should define Identifier !");

                while (currentToken.type == TokenType.LeftBracket_Type)
                {
                    currentToken = lexer.nextToken();
                    match(TokenType.IntLiteral_Type);
                    match(TokenType.RightBracket_Type);
                }
            }
            match(TokenType.Semicolon_Type);
        }

        //Type          ---->  finger | sex | void | spine                                                          *****************
        void Type()
        {
            if (isType(out ty))
                currentToken = lexer.nextToken();
            else
                error("error type");
        }

        //Statements    ---->  \{ Statement \} 
        void Statements()
        {
            while (isStatement())
            {
                Statement();
            }
        }

        //Staternent    ----> Declarations | ; | Block | Identifier AssOrCallfun | IfStatement | WhileStatement | ReturnStatement | Inputstmnt | Outputstmnt
        void Statement()
        {
            if (isType(out ty))
                Declarations();
            else if (currentToken.type == TokenType.Semicolon_Type)
                currentToken = lexer.nextToken();
            else if (currentToken.type == TokenType.LeftBrace_Type)
                Block();
            else if (currentToken.type == TokenType.Identifier_Type)
            {
                if (currentToken.type == TokenType.Identifier_Type)
                {
                    stringST = currentToken.value;
                    identifier = currentToken.value;
                    currentToken = lexer.nextToken();
                }
                else
                    error("you should define Identifier !");
                AssOrCallfun();
            }
            else if (currentToken.type == TokenType.Listen_Type)
                Ifstatement();
            else if (currentToken.type == TokenType.Circulation_Type)
                Whilestatement();
            //else if (currentToken.type == TokenType.Brain_Type)
            //    ReturnStatement();
            else if (currentToken.type == TokenType.Inhale_Type)
                Inputstmnt();
            else if (currentToken.type == TokenType.Exhale_Type)
                Outputstmnt();
            else
                error("Some statment is expected.");
        }

        //Block         ---->  { Statements } 
        void Block()
        {
            symboltable.addScope();
            match(TokenType.LeftBrace_Type);
            Statements();
            match(TokenType.RightBrace_Type);
            symboltable.removeScope();
        }

        //AssOrCallfun  ---->  Callfunction | Assignment
        void AssOrCallfun()
        {
            if (currentToken.type == TokenType.LeftParen_Type)
            {
                if(!symboltable.Search(stringST, category.function, out stype))         //Symantic
                    error("This function is not defined !  "+stringST);
                Callfunction();
            }
            else
            {
                if (!symboltable.Search(stringST, category.variable, out stype))        //Symantic
                    error("This variable is not defined !  "+stringST);
                Assignment();
            }
        }

        //Callfunction  ---->  ( Arguments ) ;
        void Callfunction()
        {
            match(TokenType.LeftParen_Type);
            Arguments();
            match(TokenType.RightParen_Type);
            match(TokenType.Semicolon_Type);
        }

        //Assignment   ---->  \[ [ Expression ] \] = Expression ; 
        void Assignment()
        {
            while (currentToken.type == TokenType.LeftBracket_Type)
            {
                currentToken = lexer.nextToken();
                Expression(out ex);
                match(TokenType.RightBracket_Type);
            }
            match(TokenType.Assign_Type);
            string exp = Expression(out ex);
            match(TokenType.Semicolon_Type);
            if (stype != ex)
            {
                Console.WriteLine("The Identifier " + identifier + " is not same type of identifier in " + exp);
                Console.ReadKey();
                Environment.Exit(-1);
            }
            file.WriteLine(identifier + " = " + exp);
            
        }

        //IfStatement   ---->  listen Expession talk Statement \{ listenagain Expession talk Statement \} \[ kick Statement \] 
        void Ifstatement()
        {
            bool bo = false;
            match(TokenType.Listen_Type);
            string exp = Expression(out ex);
            match(TokenType.Talk_Type);
            string tmp = newTmp();
            string lbl = newlbl();
            string lbl1 = newlbl();
            file.WriteLine("if false " + exp + " goto " + lbl); 
            Statements();
            file.WriteLine(" goto " + lbl1); 

            while (currentToken.type == TokenType.ListenAgain_Type)
            {
                currentToken = lexer.nextToken();
                file.WriteLine("Label " + lbl);
                string exp1 = Expression(out ex);
                match(TokenType.Talk_Type);
                tmp = newTmp();
                lbl = newlbl();
                file.WriteLine("if false" + exp1 + " goto " + lbl);
                Statement();
                file.WriteLine(" goto " + lbl1); 
            }
            if (currentToken.type == TokenType.Kick_Type)
            {
                bo = true;
                currentToken = lexer.nextToken();
                file.WriteLine("Label " + lbl);
                Statement();
            }
            if (bo == false)
                file.WriteLine("Label " + lbl);
            file.WriteLine("Label " + lbl1);
        }

        //WhileStatement  -->  circulation (   Expression ) Statement
        void Whilestatement()
        {
            string lbl = newlbl();
            string lbl1 = newlbl();
            file.WriteLine("Lable " + lbl);

            if (currentToken.type == TokenType.Circulation_Type)
            {

                currentToken = lexer.nextToken();
                match(TokenType.LeftParen_Type);
                string exp = Expression(out ex);
                file.WriteLine("if false " + exp + " goto " + lbl1);
                match(TokenType.RightParen_Type);
                Statement();
                file.WriteLine("goto " + lbl);
                file.WriteLine("Lable " + lbl1);
            }
        }

        //ReturnStatement -->  brain Expression ;
        void ReturnStatement()
        {
            match(TokenType.Brain_Type);
            Expression(out ex);
            match(TokenType.Semicolon_Type);
        }

        string inp;
        //Inputstmnt    ---->  Inhale ( Identifier \{ , Identifier  \} ) ;                         
        void Inputstmnt()
        {
            if (currentToken.type == TokenType.Inhale_Type) 
            {
                currentToken = lexer.nextToken();
                match(TokenType.LeftParen_Type);
                if (currentToken.type == TokenType.Identifier_Type)
                {
                    if (!symboltable.Search(currentToken.value, category.variable, out ex))
                        error("This variable is not defined !");
                    inp = currentToken.value;
                    currentToken = lexer.nextToken();
                }
                else
                    error("error11");
                file.WriteLine("read " + inp);
                while (currentToken.type == TokenType.Comma_Type)
                {
                    currentToken = lexer.nextToken();
                    if (currentToken.type == TokenType.Identifier_Type)
                    {
                        if (!symboltable.Search(currentToken.value, category.variable, out ex))
                            error("This variable is not defined !");
                        inp = currentToken.value;
                        currentToken = lexer.nextToken();
                    }
                    else
                        error("error11");
                    file.WriteLine("read " + inp);
                }
                match(TokenType.RightParen_Type);
            }
            else
            error("error 1");
        }

        //Outputstmnt   ---->  Exhale ( Expression \{ , Expression \} ) ;                           
        void Outputstmnt()
        {
            if (currentToken.type == TokenType.Exhale_Type)
            {
                currentToken = lexer.nextToken();
                match(TokenType.LeftParen_Type);
                string exp = Expression(out ex);
                file.WriteLine("write " + exp);
                while (currentToken.type == TokenType.Comma_Type)
                {
                    currentToken = lexer.nextToken();
                    exp = Expression(out ex);
                    file.WriteLine("write " + exp);
                }
                match(TokenType.RightParen_Type);
            }
            else
                error("error 2");
        }

        //Arguments     ---->  \[ Expression \{ , Expression \} \]
        void Arguments()
        {
            if (isPrimary(out isp))
            {
                Expression(out ex);
                while (currentToken.type == TokenType.Comma_Type)
                {
                    currentToken = lexer.nextToken();
                    Expression(out ex);
                }
            }

        }

        //Expression    ---->  Conjunction \{ || Conjunction \} 
        string Expression(out int exp)
        {
            string leftside = Conjunction(out exp);
            while (currentToken.type == TokenType.Or_Type)
            {
                currentToken = lexer.nextToken();
                string rightside = Conjunction(out exp);
                string tmp = newTmp();
                file.WriteLine(tmp + "=" + leftside + "||" + rightside);
                leftside = tmp;
            }
            ex = exp;
            return leftside;
        }

        // Conjunction --->  Equality \{ && Equality \} .
        string Conjunction(out int con)
        {
            string leftside = Equality(out con);
            while (currentToken.type == TokenType.And_Type)
            {
                currentToken = lexer.nextToken();
                string rightside = Equality(out con);
                string tmp = newTmp();
                file.WriteLine(tmp + "=" + leftside + "&&" + rightside);
                leftside = tmp;
            }
            return leftside;
        }

        // Equality --->  Relation \[ Equop Relation \] .
        string Equality(out int eql)
        {
            string leftside = Relation(out eql);
            if (currentToken.type == TokenType.Equals_Type || currentToken.type == TokenType.NotEqual_Type)
            {
                string eq = Equop();
                string rightside = Relation(out eql);
                string tmp = newTmp();
                file.WriteLine(tmp + "=" + leftside + eq + rightside);
                leftside = tmp;
            }
            return leftside;
        }

        // Equop ---> == | != .
        string  Equop()
        {
            if (currentToken.type == TokenType.Equals_Type || currentToken.type == TokenType.NotEqual_Type)
            {
                string cur = currentToken.value;
                currentToken = lexer.nextToken();
                return cur;
            }
            else
                error("A type ( ==  or !=) was expecting");
            return "er";
        }

        // Relation  --->  Addition \[ Relop Addition \] 
        string Relation(out int rel)
        {
            string leftside = Addition(out rel);
            if (isRelop())
            {
                string re = Relop();
                string rightside = Addition(out rel);
                string tmp = newTmp();
                file.WriteLine(tmp + "=" + leftside + re + rightside);
                leftside = tmp;
            }
            return leftside;
        }

        // Relop ---> < | <= | > | >= .
        string Relop()
        {
            if ( isRelop())
            {
                string re = currentToken.value; 
                currentToken = lexer.nextToken();
                return re;
            }
            else
                error("A type ( <  or <= or > or >=) was expecting");
            return "er";
        }

        // Addition ---> Term \{ Addop Term \}  
        string Addition(out int add)
        {
            string leftside = Term(out add);
            while (currentToken.type == TokenType.Plus_Type || currentToken.type == TokenType.Minus_Type)
            {
                string ad = Addop();
                string rightside = Term(out add);
                string tmp = newTmp();
                file.WriteLine(tmp + "=" + leftside + ad + rightside);
                leftside = tmp;
            }
            return leftside;
        }
        
        // Addop ---> + | - 
        string Addop()
        {
            if (currentToken.type == TokenType.Plus_Type || currentToken.type == TokenType.Minus_Type)
            {
                string ad = currentToken.value;
                currentToken = lexer.nextToken();
                return ad;
            }
            else
                error("A type ( +  or - ) was expecting");
            return "er";
        }

        // Term ---> Factor \{ Mulop Factor \} 
        string Term(out int trm)
        {
            string leftside = Factor(out trm);
            while (currentToken.type == TokenType.Multiply_Type || currentToken.type == TokenType.Divide_Type)
            {
                //currentToken = lexer.nextToken();
                string mu = Mulop();
                string rightside = Factor(out trm);
                string tmp = newTmp();
                file.WriteLine(tmp + "=" + leftside + mu + rightside);
                leftside = tmp;
            }
            return leftside;
        }

        // Mulop ---> * | / 
        string Mulop()
        {
            if (currentToken.type == TokenType.Multiply_Type || currentToken.type == TokenType.Divide_Type)
            {
                string mu = currentToken.value;
                currentToken = lexer.nextToken();
                return mu;
            }
            else
                error("A type ( *  or / ) was expecting");
            return "er";
        }

        //Factor        ---->  \[ UnaryOp \] Primary 
        string Factor(out int fct)
        {
            string fa = "";
            if (currentToken.type == TokenType.Not_Type || currentToken.type == TokenType.Minus_Type)
            {
                fa = currentToken.value;
                currentToken = lexer.nextToken();
            }
            string pr = Primary(out fct);
            string tmp = newTmp();
            return fa + pr;
        }

        // UnaryOp ---> - | ! .
        string UnaryOp()
        {
            if (currentToken.type == TokenType.Not_Type || currentToken.type == TokenType.Minus_Type)
            {
                string un = currentToken.value;
                currentToken = lexer.nextToken();
                return un;
            }
            else
                error("error 3");
            return "er";
        }

        //Primary       ---->  Identifier \[ [ Expression ] \] | Identifier ( Arguments ) | Literal | ( Expression ) 
        string Primary(out int pri)
        {
            pri = -1;
            if (currentToken.type == TokenType.Identifier_Type)
            {
                stringST = currentToken.value;
                currentToken = lexer.nextToken();
                if (currentToken.type == TokenType.LeftBracket_Type)
                {
                    if (!symboltable.Search(stringST, category.variable, out pri))
                        error("ThisIdentifier is not defined " + stringST);
                    currentToken = lexer.nextToken();
                    Expression(out ex);
                    match(TokenType.RightBracket_Type);
                    return "";
                }
                else if (currentToken.type == TokenType.LeftParen_Type)
                {
                    if (!symboltable.Search(stringST, category.function, out pri))
                          error("This Identifier is not defined " + stringST);
                    currentToken = lexer.nextToken();
                    Arguments();
                    match(TokenType.RightParen_Type);
                    return "";
                }
                else
                {
                    if (!symboltable.Search(stringST, category.variable, out pri))              //Symantic
                        error("ThisIdentifier is not defined " + stringST);
                    return stringST;
                }
            }
            else if (isLeteral(out pri))
            {
                string let = currentToken.value;
                currentToken = lexer.nextToken();
                return let;
            }

            else if (currentToken.type == TokenType.LeftParen_Type)
            {
                currentToken = lexer.nextToken();
                Expression(out ex);
                match(TokenType.RightParen_Type);
                return "";
            }
            else
            {
                error("currentToken 10");
                return "";
            }
        }

         bool isStatement()
        {
            if (currentToken.type == TokenType.Listen_Type || currentToken.type == TokenType.Circulation_Type || currentToken.type == TokenType.Semicolon_Type || currentToken.type==TokenType.Exhale_Type
                || currentToken.type == TokenType.Identifier_Type || currentToken.type == TokenType.LeftBrace_Type || isType(out ty) || currentToken.type == TokenType.Inhale_Type /*|| currentToken.type == TokenType.Brain_Type*/)
                return true;
            return false;
        }

        bool isType(out int ty)
        {
            if (currentToken.type == TokenType.Finger_Type)
            {
                ty = 0;
                return true;
            }
            else if (currentToken.type == TokenType.Sex_Type)
            {
                ty = 1;
                return true;
            }
            else if (currentToken.type == TokenType.Spine_Type)
            {
                ty = 2;
                return true;
            }
            else if (currentToken.type == TokenType.Mouth_Type)
            {
                ty = 3;
                return true;
            }
            ty = -1;
            return false;
        }

        bool isRelop()
        {
            if (currentToken.type == TokenType.LessEqual_Type || currentToken.type == TokenType.Less_Type
                || currentToken.type == TokenType.GreaterEqual_Type || currentToken.type == TokenType.Greater_Type)
            {
                return true;
            }
            else
                return false;
        }

        bool isLeteral(out int islt)
        {
            if (currentToken.type == TokenType.IntLiteral_Type)
            {
                islt = 0;
                return true;
            }
            else if (currentToken.type == TokenType.CharLiteral_Type)
            {
                islt = 2;
                return true;
            }
            else if (currentToken.type == TokenType.BoolLiteral_Type)
            {
                islt = 1;
                return true;
            }
            else
                islt = -1;
                return false;
        }
        int isp;
        //Primary       ---->  Identifier \[ [ Expression ] \] | Literal | ( Expression ) | Identifier ( Arguments )
        bool isPrimary(out int ispr)
        {
            
            if (currentToken.type == TokenType.Identifier_Type || isLeteral(out isp) || currentToken.type == TokenType.LeftParen_Type)
            {
                ispr = isp;
                return true;
            }
            else
                ispr = -1;
                return false;
        }
        int counter = 0;
        string newTmp()
        {
            string tmp = "T" + counter.ToString();
            counter++;
            return tmp;
        }

        int counterlbl = 0;
        string newlbl()
        {
            string tmp = "L" + counterlbl.ToString();
            counterlbl++;
            return tmp;
        }

    }
}
