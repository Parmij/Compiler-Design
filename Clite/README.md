## Compiler Design Project: 
This project is a simple imperative programming language and it simulates C programming language in compilation code by pass code in lexer then parser then sementic and finally to generate Three Address Code which consider as intermediate code between high level code and machine code.
#### Keywords:
main, int, char, void, bool, true, false, while, if, then, elseif, else, cin, cout and return.
#### PUNCTUATION:
, ; { } ( ) [ ] 

#### Operation: 
= < > <= >= == != + - * / && || ^ !
#### Comments: 
// one line   /*...*/ multiple lines
#### Primitive Data Types:
###### This language supports three primitive data types: 
1.Integers

2.Characters

3.Booleans
#### Aggregate Data Types 
##### This language have constructs for defining two aggregate data types: 
 1. Arrays of any dimension
 2. Records or Structures (classes)
#### Variables 
This language allows the declaration of names for variables of any type. Variables should be declared before they are used. It have unlimited levels of scope.
#### Constants
This language have a statement for defining constants of any primitive type. - Constants differ from variables in that their value cannot be changed after they have been defined.
#### Expressions
This language have the ability to evaluate expressions.  Operators used in expressions include addition, subtraction, multiplication, and integer division, as well as the unary – (negative) operator, and parenthesized factors. Expressions accepts the following relational operators: Equal, greater than, less than, greater than or equal, less than or equal, not equal Expressions, also, accept the Boolean AND, OR, and NOT operators.
#### Assignment 
This language have some form of an assignment statement which assigns the value of any expression to a variable. If a variable is used in the RHS of an assignment before initialization the compiler will show a warning message.  
#### Functions and procedures 
This language have a facility to define functions which take any number and type of arguments (parameters), and return a single value of any primitive type. It can support both functions and procedures (procedures do not return any value). It be possible to pass an expression as an actual argument to a function. It be possible to call functions within functions, and to call a function from within itself (recursion). 
#### Control of flow 
##### The language supports the following control of flow constructs 
1. Conditional execution (an if-then-else statement)
2. Iteration (while statement)
#### Input/output
This language have some facility for outputting data to the standard output, and inputting data from the standard input.
#### Target Code
The compiler should generate three address code which can converted to assembly easily for any real or virtual machine.
#### Grammar:
Program         ⇒  int  main ( ) { Declarations Statements }

 Declarations    ⇒  { Declaration }
 
  Declaration     ⇒  Type  Identifier  ;
  
 Type            ⇒  int | bool | float | char
 
 Statements      ⇒  { Statement }
 
 Statement       ⇒  ; | Block | Assignment | IfStatement | WhileStatement
 
 Block           ⇒  { Statements }
 
 Assignment      ⇒  Identifier = Expression ;
 
 IfStatement     ⇒  if ( Expression ) Statement [ else Statement ]
 

 WhileStatement  ⇒  while ( Expression ) Statement  
 
 Expression      ⇒  Conjunction { || Conjunction }
 
 Conjunction     ⇒  Equality { && Equality }
 

 Equality        ⇒  Relation [ EquOp Relation ]
 
 EquOp           ⇒  == | != 
 
 Relation        ⇒  Addition [ RelOp Addition ]

 RelOp           ⇒  < | <= | > | >= 

 Addition        ⇒  Term { AddOp Term }
 
 AddOp           ⇒  + | -
 
 Term            ⇒  Factor { MulOp Factor }
 
 MulOp           ⇒  * | / | %
 
 Factor          ⇒  [ UnaryOp ] Primary
 
 UnaryOp         ⇒  - | !
 
 Primary         ⇒  Identifier | IntLit | FloatLit |  ( Expression )
