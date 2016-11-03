using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CD_Project
{
     enum TokenType
    {
        /*If_Type, Else_Type, While_Type, Main_Type, Input_Type, Output_Type,
        Return_Type, Int_Type, Bool_Type, Char_Type, Float_Type,
        */
        Listen_Type, Kick_Type, Circulation_Type, Heart_Type, Inhale_Type, Exhale_Type, ListenAgain_Type,
        Brain_Type, Finger_Type, Sex_Type, Spine_Type, Mouth_Type, Man_Type, Woman_Type, Talk_Type,
        
        LeftBrace_Type, RightBrace_Type, LeftBracket_Type, RightBracket_Type,
        LeftParen_Type, RightParen_Type, Semicolon_Type, Comma_Type,

        Assign_Type,
        Equals_Type, Less_Type, LessEqual_Type, Greater_Type, GreaterEqual_Type, NotEqual_Type,
        Plus_Type, Minus_Type, Multiply_Type, Divide_Type,
        Ref_type, And_Type, Or_Type, Not_Type,
        
        IntLiteral_Type, CharLiteral_Type, BoolLiteral_Type,
        
        Identifier_Type,

        Eof_Type, Undefined_Type
    };

    class Token
    {  
      public TokenType type;
	  public string value;

 public	Token(){
		type =TokenType.Undefined_Type;
		value = "";
	       }

 public	Token(TokenType t, string v){
		type = t;
		value= v;
	}

	public string typeName(){
		if(type == TokenType.Identifier_Type)
			return "IDENTIFIER";
		else if(type>=TokenType.Listen_Type && type<=TokenType.Talk_Type)
			return "KEYWORD";
		else if(type>=TokenType.LeftBrace_Type && type<=TokenType.Comma_Type)
			return "PUNCTUATION";
		else if(type>=TokenType.Assign_Type && type<=TokenType.Not_Type)
			return "OPERATION";
		else if(type>=TokenType.IntLiteral_Type && type<=TokenType.BoolLiteral_Type)
			return "LITERAL";
		else if(type == TokenType.Eof_Type)
			return "EOF";
		else if(type ==TokenType.Undefined_Type)
			return "UNDEFINED";
		
		return "UNKNOWN_TYPE";
	}

    }
}
