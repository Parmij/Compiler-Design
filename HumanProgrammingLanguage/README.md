## Compiler Design Project: 
This project is a simple imperative programming language and it simulates C programming language in compilation code but human language in keywords by pass code in lexer then parser then sementic and finally to generate Three Address Code which consider as intermediate code between high level code and machine code.
#### Keywords:
    Heart, finger, spine, mouth, sex, man, woman, circulation, listen, talk, listenagain, kick, inhale, exhale and brain.
#### PUNCTUATION:
    , ; { } ( ) [ ] 

#### Operation: 
    = < > <= >= == != + - * / && || ^ !
#### Comments: 
    // one line   /*...*/ multiple lines
#### Primitive Data Types:
    This language supports three primitive data types: 
        Integers
        Characters
        Booleans
#### Aggregate Data Types 
    This language have constructs for defining two aggregate data types: 
        Arrays of any dimension.
        Records or Structures (classes).
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
    The language supports the following control of flow constructs 
        Conditional execution (an if-then-else statement)
        Iteration (while statement)
#### Input/output
    This language have some facility for outputting data to the standard output, and inputting data from the standard input.
#### Target Code
    The compiler should generate three address code which can converted to assembly easily for any real or virtual machine.
#### Grammar :
    Program       ---->  \{ Type FunOrMain \}
    FunOrMain     ---->  Identifier FunOrGlobal | Main
    FunOrGlobal   ---->  Function | Global
    Function      ---->  ( Parameters ) { Statements } 
    Parameters    --- >  \[ Parameter \{ , Parameter \} \] 
    Parameter     ---->  Type \[ ^ \] Identifier 
    Global        ---->  \{ [ finger ] \} \{ , identifier \{ [ finger ] \} \} ;
    Main          ---->  heart ( ) { Statements } 
    Declarations  ---->  \{ Declaration \}
    Declaration   ---->  type Identifier \{ [ finger ] \} \{ , identifier \{ [ finger ] \} \} ;
    Type          ---->  finger | sex | void | spine                                   
    Statements    ---->  \{ Statement \} 
    Statement    ---->   ; | Block | Identifier AssOrCallfun | IfStatement | WhileStatement | ReturnStatement | Inputstmnt | Outputstmnt
    Block         ---->  { Statements } 
    AssOrCallfun  ---->  Callfunction | Assigmnent
    Assigmnent   ---->   \[ [ Expression ] \] = Expression ; 
    Callfunction  ---->  ( Arguments ) ;
    IfStatement   ---->  listen Expession talk Statement \{ listenagain Statement \} \[ kick Statement \] 
    WhileStatement  -->  circulation ( Expression ) Statement
    ReturnStatement -->  brain Expression ; 
    Inputstmnt    ---->  inhale ( Identifier \{ , Identifier \} ) ;  
    Outputstmnt   ---->  exhale ( Expression \{ , Expression \} ) ;  
    Arguments     ---->  \[ Expression \{ , Expression \} \] 
    Expression    ---->  Conjunction \{ || Conjunction \} 
    Conjunction   ---->  Equality \{ && Equality \} 
    Equality      ---->  Relation \[ EquOp Relation \] 
    EquOp         ---->  == | != 
    Relation      ---->  Addition \[ RelOp Addition \] 
    RelOp         ---->  < | <= | > | >= 
    Addition      ---->  Term \{ AddOp Term \} 
    AddOp         ---->  + | - 
    Term          ---->  Factor \{ MulOp Factor \} 
    MulOp         ---->  * | / | % 
    Factor        ---->  \[ UnaryOp \] Primary 
    UnaryOp       ---->  - | ! 
    Primary       ---->  Identifier \[ [ Expression ] \] | Literal | ( Expression ) | Identifier ( Arguments )
    Identifier    ---->  Letter \{ Letter | Digit \} 
    Letter        ---->  a | b | .... | z | A | B | .... | Z 
    Digit         ---->  0 | 1 | .... | 9 
    Literal       ---->  finger | sex | spine
    Finger ---->  Digit \{ Digit \} 
    Sex  ---->  man | woman
    Float         ---->  finger . finger
    Spine  ---->  ASCIIChar
