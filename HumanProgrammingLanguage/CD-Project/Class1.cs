/* 
 * key word :
 *              main   -->  heart
 *              int    -->  finger
 *              char   -->  spine
 *              void   -->  mouth
 *              bool   -->  sex
 *              true   -->  man
 *              false  -->  woman
 *              while  -->  circulation
 *              if     -->  listen
 *              then   -->  talk
 *              elseif -->  listenagain
 *              else   -->  kick
 *              cin    -->  inhale
 *              cout   -->  exhale
 *              return -->  brain
 *              
 * PUNCTUATION :
 *              ,  -->  
 *              ;  -->  
 *              {  -->  
 *              }  -->  
 *              (  -->  
 *              )  -->  
 *              [  -->  
 *              ]  -->  
 *              
 * operation :
 *              =  -->  
 *              <  -->  
 *              >  -->  
 *              <= -->  
 *              >= -->  
 *              == -->  
 *              != -->  
 *              +  -->  
 *              -  -->  
 *              *  -->  
 *              /  -->  
 *              && -->  
 *              || -->  
 *              ^  -->  
 *              !  -->  
 *              
 *  Grammar :
 *          Program       ---->  \{ Type FunOrMain \}
 *          FunOrMain     ---->  Identifier FunOrGlobal | Main
 *          FunOrGlobal   ---->  Function | Global
 *          Function      ---->  ( Parameters ) { Statements } 
 *          Parameters    --- >  \[ Parameter \{ , Parameter \} \] 
 *          Parameter     ---->  Type \[ ^ \] Identifier 
 *          Global        ---->  \{ [ finger ] \} \{ , identifier \{ [ finger ] \} \} ;
 *          Main          ---->  heart ( ) { Statements } 
 *          Declarations  ---->  \{ Declaration \}
 *          Declaration   ---->  type Identifier \{ [ finger ] \} \{ , identifier \{ [ finger ] \} \} ;
 *          Type          ---->  finger | sex | void | spine                                                          *****************
 *          Statements    ---->  \{ Statement \} 
 *          Statement    ---->   ; | Block | Identifier AssOrCallfun | IfStatement | WhileStatement | ReturnStatement | Inputstmnt | Outputstmnt   ******   
 *          Block         ---->  { Statements } 
 *          AssOrCallfun  ---->  Callfunction | Assigmnent
 *          Assigmnent   ---->   \[ [ Expression ] \] = Expression ; 
 *          Callfunction  ---->  ( Arguments ) ;
 *          IfStatement   ---->  listen Expession talk Statement \{ listenagain Statement \} \[ kick Statement \] 
 *          WhileStatement  -->  circulation ( Expression ) Statement
 *          ReturnStatement -->  return Expression ; 
 *          Inputstmnt    ---->  inhale ( Identifier \{ , Identifier \} ) ;                                  
 *          Outputstmnt   ---->  exhale ( Expression \{ , Expression \} ) ;                                    
 *          Arguments     ---->  \[ Expression \{ , Expression \} \] 
 *          Expression    ---->  Conjunction \{ || Conjunction \} 
 *          Conjunction   ---->  Equality \{ && Equality \} 
 *          Equality      ---->  Relation \[ EquOp Relation \] 
 *          EquOp         ---->  == | != 
 *          Relation      ---->  Addition \[ RelOp Addition \] 
 *          RelOp         ---->  < | <= | > | >= 
 *          Addition      ---->  Term \{ AddOp Term \} 
 *          AddOp         ---->  + | - 
 *          Term          ---->  Factor \{ MulOp Factor \} 
 *          MulOp         ---->  * | / | % 
 *          Factor        ---->  \[ UnaryOp \] Primary 
 *          UnaryOp       ---->  - | ! 
 *          Primary       ---->  Identifier \[ [ Expression ] \] | Literal | ( Expression ) | Identifier ( Arguments )
 *          Identifier    ---->  Letter \{ Letter | Digit \} 
 *          Letter        ---->  a | b | .... | z | A | B | .... | Z 
 *          Digit         ---->  0 | 1 | .... | 9 
 *          Literal       ---->  Integer | Boolean | Float | Char 
 *          Integer       ---->  Digit \{ Digit \} 
 *          Boolean       ---->  true | false 
 *          Float         ---->  Integer . Integer 
 *          Char          ---->  ASCIIChar
 */