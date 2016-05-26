
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                  =  0, // (EOF)
        SYMBOL_ERROR                =  1, // (Error)
        SYMBOL_WHITESPACE           =  2, // Whitespace
        SYMBOL_MINUS                =  3, // '-'
        SYMBOL_QUOTE                =  4, // '"'
        SYMBOL_AMPAMP               =  5, // '&&'
        SYMBOL_LPAREN               =  6, // '('
        SYMBOL_RPAREN               =  7, // ')'
        SYMBOL_TIMES                =  8, // '*'
        SYMBOL_COMMA                =  9, // ','
        SYMBOL_DIV                  = 10, // '/'
        SYMBOL_SEMI                 = 11, // ';'
        SYMBOL_LBRACE               = 12, // '{'
        SYMBOL_PIPEPIPE             = 13, // '||'
        SYMBOL_RBRACE               = 14, // '}'
        SYMBOL_PLUS                 = 15, // '+'
        SYMBOL_LT                   = 16, // '<'
        SYMBOL_LTEQ                 = 17, // '<='
        SYMBOL_EQ                   = 18, // '='
        SYMBOL_EQEQ                 = 19, // '=='
        SYMBOL_GT                   = 20, // '>'
        SYMBOL_GTEQ                 = 21, // '>='
        SYMBOL_BOOLEAN              = 22, // boolean
        SYMBOL_CHAR                 = 23, // char
        SYMBOL_DO                   = 24, // do
        SYMBOL_DOUBLE               = 25, // double
        SYMBOL_ELSE                 = 26, // else
        SYMBOL_ENTERONEGATIVO       = 27, // enteroNegativo
        SYMBOL_ENTEROPOSITIVO       = 28, // enteroPositivo
        SYMBOL_FALSE                = 29, // false
        SYMBOL_FOR                  = 30, // for
        SYMBOL_ID                   = 31, // id
        SYMBOL_IF                   = 32, // if
        SYMBOL_INT                  = 33, // int
        SYMBOL_PRINCIPAL            = 34, // principal
        SYMBOL_REALNEGATIVO         = 35, // realNegativo
        SYMBOL_REALPOSITIVO         = 36, // realPositivo
        SYMBOL_RETURN               = 37, // return
        SYMBOL_STRING               = 38, // String
        SYMBOL_TRUE                 = 39, // true
        SYMBOL_VOID                 = 40, // void
        SYMBOL_WHILE                = 41, // while
        SYMBOL_CADENAS              = 42, // <cadenas>
        SYMBOL_CONDICION            = 43, // <Condicion>
        SYMBOL_CONDICIONP           = 44, // <Condicionp>
        SYMBOL_CONDICIONSIMPLE      = 45, // <CondicionSimple>
        SYMBOL_DECLARACION          = 46, // <Declaracion>
        SYMBOL_EXPRESION            = 47, // <Expresion>
        SYMBOL_EXPRESIONP           = 48, // <Expresionp>
        SYMBOL_FACTOR               = 49, // <Factor>
        SYMBOL_FUNCION              = 50, // <Funcion>
        SYMBOL_ID2                  = 51, // <id>
        SYMBOL_LISTADECLARACIONES   = 52, // <ListaDeclaraciones>
        SYMBOL_LISTADECLARACIONESP  = 53, // <ListaDeclaracionesp>
        SYMBOL_LISTAEXPRESIONES     = 54, // <ListaExpresiones>
        SYMBOL_LISTAEXPRESIONESP    = 55, // <ListaExpresionesp>
        SYMBOL_LISTAFUNCIONES       = 56, // <ListaFunciones>
        SYMBOL_LISTAFUNCIONESP      = 57, // <ListaFuncionesp>
        SYMBOL_LISTAMETODOS         = 58, // <ListaMetodos>
        SYMBOL_LISTAMETODOSP        = 59, // <ListaMetodosp>
        SYMBOL_LISTAPARAMETROS      = 60, // <ListaParametros>
        SYMBOL_LISTAPARAMETROSP     = 61, // <ListaParametrosp>
        SYMBOL_LISTAPROCEDIMIENTOS  = 62, // <ListaProcedimientos>
        SYMBOL_LISTAPROCEDIMIENTOSP = 63, // <ListaProcedimientosp>
        SYMBOL_LISTASENTENCIAS      = 64, // <ListaSentencias>
        SYMBOL_LISTASENTENCIASP     = 65, // <ListaSentenciasp>
        SYMBOL_LLAMADAFUNCION       = 66, // <LlamadaFuncion>
        SYMBOL_LLAMADAPROCEDIMIENTO = 67, // <LlamadaProcedimiento>
        SYMBOL_NUMEROS              = 68, // <Numeros>
        SYMBOL_PARAMETRO            = 69, // <Parametro>
        SYMBOL_PROCEDIMIENTO        = 70, // <Procedimiento>
        SYMBOL_PROGRAMA             = 71, // <Programa>
        SYMBOL_SENTENCIA            = 72, // <Sentencia>
        SYMBOL_SENTENCIAASIGNACION  = 73, // <SentenciaAsignacion>
        SYMBOL_SENTENCIADOWHILE     = 74, // <SentenciaDoWhile>
        SYMBOL_SENTENCIAFOR         = 75, // <SentenciaFor>
        SYMBOL_SENTENCIAIF          = 76, // <SentenciaIf>
        SYMBOL_SENTENCIAWHILE       = 77, // <SentenciaWhile>
        SYMBOL_TERMINO              = 78, // <Termino>
        SYMBOL_TERMINOP             = 79, // <Terminop>
        SYMBOL_TIPO                 = 80  // <Tipo>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE                              =  0, // <Programa> ::= principal '{' <ListaSentencias> '}' <ListaMetodos>
        RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE2                             =  1, // <Programa> ::= <ListaDeclaraciones> principal '{' <ListaSentencias> '}' <ListaMetodos>
        RULE_LISTADECLARACIONES                                            =  2, // <ListaDeclaraciones> ::= <ListaDeclaracionesp>
        RULE_LISTADECLARACIONESP                                           =  3, // <ListaDeclaracionesp> ::= <Declaracion> <ListaDeclaracionesp>
        RULE_LISTADECLARACIONESP2                                          =  4, // <ListaDeclaracionesp> ::= 
        RULE_DECLARACION_SEMI                                              =  5, // <Declaracion> ::= <Tipo> <id> ';'
        RULE_DECLARACION_EQ_SEMI                                           =  6, // <Declaracion> ::= <Tipo> <id> '=' <Expresion> ';'
        RULE_LISTAMETODOS                                                  =  7, // <ListaMetodos> ::= <ListaMetodosp>
        RULE_LISTAMETODOSP                                                 =  8, // <ListaMetodosp> ::= <ListaFunciones> <ListaMetodosp>
        RULE_LISTAMETODOSP2                                                =  9, // <ListaMetodosp> ::= <ListaProcedimientos> <ListaMetodosp>
        RULE_LISTAMETODOSP3                                                = 10, // <ListaMetodosp> ::= 
        RULE_LISTASENTENCIAS                                               = 11, // <ListaSentencias> ::= <ListaSentenciasp>
        RULE_LISTASENTENCIASP                                              = 12, // <ListaSentenciasp> ::= <Sentencia> <ListaSentenciasp>
        RULE_LISTASENTENCIASP2                                             = 13, // <ListaSentenciasp> ::= 
        RULE_SENTENCIA_SEMI                                                = 14, // <Sentencia> ::= <SentenciaAsignacion> ';'
        RULE_SENTENCIA                                                     = 15, // <Sentencia> ::= <SentenciaFor>
        RULE_SENTENCIA2                                                    = 16, // <Sentencia> ::= <SentenciaWhile>
        RULE_SENTENCIA3                                                    = 17, // <Sentencia> ::= <SentenciaDoWhile>
        RULE_SENTENCIA4                                                    = 18, // <Sentencia> ::= <SentenciaIf>
        RULE_SENTENCIA5                                                    = 19, // <Sentencia> ::= <LlamadaProcedimiento>
        RULE_SENTENCIA6                                                    = 20, // <Sentencia> ::= <Declaracion>
        RULE_SENTENCIAASIGNACION_EQ                                        = 21, // <SentenciaAsignacion> ::= <id> '=' <Expresion>
        RULE_SENTENCIAFOR_FOR_LPAREN_SEMI_RPAREN_LBRACE_RBRACE             = 22, // <SentenciaFor> ::= for '(' <SentenciaAsignacion> <Condicion> ';' <SentenciaAsignacion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIAWHILE_WHILE_LPAREN_RPAREN_LBRACE_RBRACE              = 23, // <SentenciaWhile> ::= while '(' <Condicion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIADOWHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN         = 24, // <SentenciaDoWhile> ::= do '{' <ListaSentencias> '}' while '(' <Condicion> ')'
        RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE                    = 25, // <SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}'
        RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE = 26, // <SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}' else '{' <ListaSentencias> '}'
        RULE_FUNCION_LPAREN_RPAREN_LBRACE_RETURN_SEMI_RBRACE               = 27, // <Funcion> ::= <Tipo> <id> '(' <ListaParametros> ')' '{' <ListaSentencias> return <Expresion> ';' '}'
        RULE_LISTAFUNCIONES                                                = 28, // <ListaFunciones> ::= <Funcion> <ListaFuncionesp>
        RULE_LISTAFUNCIONESP                                               = 29, // <ListaFuncionesp> ::= <Funcion> <ListaFuncionesp>
        RULE_LISTAFUNCIONESP2                                              = 30, // <ListaFuncionesp> ::= 
        RULE_PARAMETRO                                                     = 31, // <Parametro> ::= <Tipo> <id>
        RULE_PARAMETRO2                                                    = 32, // <Parametro> ::= 
        RULE_LISTAPARAMETROS                                               = 33, // <ListaParametros> ::= <Parametro> <ListaParametrosp>
        RULE_LISTAPARAMETROSP_COMMA                                        = 34, // <ListaParametrosp> ::= ',' <Parametro> <ListaParametrosp>
        RULE_LISTAPARAMETROSP                                              = 35, // <ListaParametrosp> ::= 
        RULE_TIPO_INT                                                      = 36, // <Tipo> ::= int
        RULE_TIPO_CHAR                                                     = 37, // <Tipo> ::= char
        RULE_TIPO_BOOLEAN                                                  = 38, // <Tipo> ::= boolean
        RULE_TIPO_STRING                                                   = 39, // <Tipo> ::= String
        RULE_TIPO_DOUBLE                                                   = 40, // <Tipo> ::= double
        RULE_PROCEDIMIENTO_VOID_LPAREN_RPAREN_LBRACE_RBRACE                = 41, // <Procedimiento> ::= void <id> '(' <ListaParametros> ')' '{' <ListaSentencias> '}'
        RULE_LISTAPROCEDIMIENTOS                                           = 42, // <ListaProcedimientos> ::= <Procedimiento> <ListaProcedimientosp>
        RULE_LISTAPROCEDIMIENTOSP                                          = 43, // <ListaProcedimientosp> ::= <Procedimiento> <ListaProcedimientosp>
        RULE_LISTAPROCEDIMIENTOSP2                                         = 44, // <ListaProcedimientosp> ::= 
        RULE_LLAMADAFUNCION_LPAREN_RPAREN                                  = 45, // <LlamadaFuncion> ::= <id> '(' <ListaExpresiones> ')'
        RULE_LLAMADAFUNCION_LPAREN_RPAREN2                                 = 46, // <LlamadaFuncion> ::= <id> '(' ')'
        RULE_LLAMADAPROCEDIMIENTO_LPAREN_RPAREN_SEMI                       = 47, // <LlamadaProcedimiento> ::= <id> '(' <ListaExpresiones> ')' ';'
        RULE_LLAMADAPROCEDIMIENTO_LPAREN_RPAREN_SEMI2                      = 48, // <LlamadaProcedimiento> ::= <id> '(' ')' ';'
        RULE_LISTAEXPRESIONES                                              = 49, // <ListaExpresiones> ::= <Expresion> <ListaExpresionesp>
        RULE_LISTAEXPRESIONESP_COMMA                                       = 50, // <ListaExpresionesp> ::= ',' <Expresion> <ListaExpresionesp>
        RULE_LISTAEXPRESIONESP                                             = 51, // <ListaExpresionesp> ::= 
        RULE_EXPRESION                                                     = 52, // <Expresion> ::= <Termino> <Expresionp>
        RULE_EXPRESIONP_PLUS                                               = 53, // <Expresionp> ::= '+' <Termino> <Expresionp>
        RULE_EXPRESIONP_MINUS                                              = 54, // <Expresionp> ::= '-' <Termino> <Expresionp>
        RULE_EXPRESIONP                                                    = 55, // <Expresionp> ::= 
        RULE_TERMINO                                                       = 56, // <Termino> ::= <Factor> <Terminop>
        RULE_TERMINOP_TIMES                                                = 57, // <Terminop> ::= '*' <Factor> <Terminop>
        RULE_TERMINOP_DIV                                                  = 58, // <Terminop> ::= '/' <Factor> <Terminop>
        RULE_TERMINOP                                                      = 59, // <Terminop> ::= 
        RULE_FACTOR_LPAREN_RPAREN                                          = 60, // <Factor> ::= '(' <Expresion> ')'
        RULE_FACTOR                                                        = 61, // <Factor> ::= <id>
        RULE_FACTOR2                                                       = 62, // <Factor> ::= <Numeros>
        RULE_FACTOR3                                                       = 63, // <Factor> ::= <LlamadaFuncion>
        RULE_FACTOR_QUOTE_QUOTE                                            = 64, // <Factor> ::= '"' <cadenas> '"'
        RULE_CONDICION                                                     = 65, // <Condicion> ::= <CondicionSimple> <Condicionp>
        RULE_CONDICIONP_AMPAMP                                             = 66, // <Condicionp> ::= '&&' <CondicionSimple> <Condicionp>
        RULE_CONDICIONP_PIPEPIPE                                           = 67, // <Condicionp> ::= '||' <CondicionSimple> <Condicionp>
        RULE_CONDICIONP                                                    = 68, // <Condicionp> ::= 
        RULE_CONDICIONSIMPLE_LT                                            = 69, // <CondicionSimple> ::= <Expresion> '<' <Expresion>
        RULE_CONDICIONSIMPLE_GT                                            = 70, // <CondicionSimple> ::= <Expresion> '>' <Expresion>
        RULE_CONDICIONSIMPLE_LTEQ                                          = 71, // <CondicionSimple> ::= <Expresion> '<=' <Expresion>
        RULE_CONDICIONSIMPLE_GTEQ                                          = 72, // <CondicionSimple> ::= <Expresion> '>=' <Expresion>
        RULE_CONDICIONSIMPLE_EQEQ                                          = 73, // <CondicionSimple> ::= <Expresion> '==' <Expresion>
        RULE_CONDICIONSIMPLE_LPAREN_RPAREN                                 = 74, // <CondicionSimple> ::= '(' <Condicion> ')'
        RULE_ID_ID                                                         = 75, // <id> ::= id
        RULE_ID_ID_COMMA                                                   = 76, // <id> ::= id ',' <id>
        RULE_CADENAS_ID                                                    = 77, // <cadenas> ::= id
        RULE_CADENAS_ID2                                                   = 78, // <cadenas> ::= id <cadenas>
        RULE_NUMEROS_ENTEROPOSITIVO                                        = 79, // <Numeros> ::= enteroPositivo
        RULE_NUMEROS_ENTERONEGATIVO                                        = 80, // <Numeros> ::= enteroNegativo
        RULE_NUMEROS_REALPOSITIVO                                          = 81, // <Numeros> ::= realPositivo
        RULE_NUMEROS_REALNEGATIVO                                          = 82, // <Numeros> ::= realNegativo
        RULE_NUMEROS_TRUE                                                  = 83, // <Numeros> ::= true
        RULE_NUMEROS_FALSE                                                 = 84  // <Numeros> ::= false
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            parser.Parse(source);

        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        private Object CreateObject(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUOTE :
                //'"'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPAMP :
                //'&&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEAN :
                //boolean
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENTERONEGATIVO :
                //enteroNegativo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENTEROPOSITIVO :
                //enteroPositivo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINCIPAL :
                //principal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REALNEGATIVO :
                //realNegativo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REALPOSITIVO :
                //realPositivo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //String
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CADENAS :
                //<cadenas>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDICION :
                //<Condicion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDICIONP :
                //<Condicionp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDICIONSIMPLE :
                //<CondicionSimple>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARACION :
                //<Declaracion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESION :
                //<Expresion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESIONP :
                //<Expresionp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<Factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCION :
                //<Funcion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTADECLARACIONES :
                //<ListaDeclaraciones>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTADECLARACIONESP :
                //<ListaDeclaracionesp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAEXPRESIONES :
                //<ListaExpresiones>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAEXPRESIONESP :
                //<ListaExpresionesp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAFUNCIONES :
                //<ListaFunciones>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAFUNCIONESP :
                //<ListaFuncionesp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAMETODOS :
                //<ListaMetodos>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAMETODOSP :
                //<ListaMetodosp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAPARAMETROS :
                //<ListaParametros>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAPARAMETROSP :
                //<ListaParametrosp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAPROCEDIMIENTOS :
                //<ListaProcedimientos>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTAPROCEDIMIENTOSP :
                //<ListaProcedimientosp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTASENTENCIAS :
                //<ListaSentencias>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LISTASENTENCIASP :
                //<ListaSentenciasp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LLAMADAFUNCION :
                //<LlamadaFuncion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LLAMADAPROCEDIMIENTO :
                //<LlamadaProcedimiento>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMEROS :
                //<Numeros>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETRO :
                //<Parametro>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROCEDIMIENTO :
                //<Procedimiento>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAMA :
                //<Programa>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIA :
                //<Sentencia>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAASIGNACION :
                //<SentenciaAsignacion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIADOWHILE :
                //<SentenciaDoWhile>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAFOR :
                //<SentenciaFor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAIF :
                //<SentenciaIf>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SENTENCIAWHILE :
                //<SentenciaWhile>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERMINO :
                //<Termino>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERMINOP :
                //<Terminop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIPO :
                //<Tipo>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                //todo: Report message to UI?
            }
        }

        public static Object CreateObject(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE :
                //<Programa> ::= principal '{' <ListaSentencias> '}' <ListaMetodos>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAMA_PRINCIPAL_LBRACE_RBRACE2 :
                //<Programa> ::= <ListaDeclaraciones> principal '{' <ListaSentencias> '}' <ListaMetodos>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTADECLARACIONES :
                //<ListaDeclaraciones> ::= <ListaDeclaracionesp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTADECLARACIONESP :
                //<ListaDeclaracionesp> ::= <Declaracion> <ListaDeclaracionesp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTADECLARACIONESP2 :
                //<ListaDeclaracionesp> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACION_SEMI :
                //<Declaracion> ::= <Tipo> <id> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACION_EQ_SEMI :
                //<Declaracion> ::= <Tipo> <id> '=' <Expresion> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAMETODOS :
                //<ListaMetodos> ::= <ListaMetodosp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAMETODOSP :
                //<ListaMetodosp> ::= <ListaFunciones> <ListaMetodosp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAMETODOSP2 :
                //<ListaMetodosp> ::= <ListaProcedimientos> <ListaMetodosp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAMETODOSP3 :
                //<ListaMetodosp> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTASENTENCIAS :
                //<ListaSentencias> ::= <ListaSentenciasp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTASENTENCIASP :
                //<ListaSentenciasp> ::= <Sentencia> <ListaSentenciasp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTASENTENCIASP2 :
                //<ListaSentenciasp> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_SEMI :
                //<Sentencia> ::= <SentenciaAsignacion> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA :
                //<Sentencia> ::= <SentenciaFor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA2 :
                //<Sentencia> ::= <SentenciaWhile>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA3 :
                //<Sentencia> ::= <SentenciaDoWhile>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA4 :
                //<Sentencia> ::= <SentenciaIf>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA5 :
                //<Sentencia> ::= <LlamadaProcedimiento>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA6 :
                //<Sentencia> ::= <Declaracion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAASIGNACION_EQ :
                //<SentenciaAsignacion> ::= <id> '=' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAFOR_FOR_LPAREN_SEMI_RPAREN_LBRACE_RBRACE :
                //<SentenciaFor> ::= for '(' <SentenciaAsignacion> <Condicion> ';' <SentenciaAsignacion> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAWHILE_WHILE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<SentenciaWhile> ::= while '(' <Condicion> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIADOWHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN :
                //<SentenciaDoWhile> ::= do '{' <ListaSentencias> '}' while '(' <Condicion> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIF_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<SentenciaIf> ::= if '(' <Condicion> ')' '{' <ListaSentencias> '}' else '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FUNCION_LPAREN_RPAREN_LBRACE_RETURN_SEMI_RBRACE :
                //<Funcion> ::= <Tipo> <id> '(' <ListaParametros> ')' '{' <ListaSentencias> return <Expresion> ';' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAFUNCIONES :
                //<ListaFunciones> ::= <Funcion> <ListaFuncionesp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAFUNCIONESP :
                //<ListaFuncionesp> ::= <Funcion> <ListaFuncionesp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAFUNCIONESP2 :
                //<ListaFuncionesp> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETRO :
                //<Parametro> ::= <Tipo> <id>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMETRO2 :
                //<Parametro> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAPARAMETROS :
                //<ListaParametros> ::= <Parametro> <ListaParametrosp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAPARAMETROSP_COMMA :
                //<ListaParametrosp> ::= ',' <Parametro> <ListaParametrosp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAPARAMETROSP :
                //<ListaParametrosp> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_INT :
                //<Tipo> ::= int
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_CHAR :
                //<Tipo> ::= char
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_BOOLEAN :
                //<Tipo> ::= boolean
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_STRING :
                //<Tipo> ::= String
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPO_DOUBLE :
                //<Tipo> ::= double
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROCEDIMIENTO_VOID_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Procedimiento> ::= void <id> '(' <ListaParametros> ')' '{' <ListaSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAPROCEDIMIENTOS :
                //<ListaProcedimientos> ::= <Procedimiento> <ListaProcedimientosp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAPROCEDIMIENTOSP :
                //<ListaProcedimientosp> ::= <Procedimiento> <ListaProcedimientosp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAPROCEDIMIENTOSP2 :
                //<ListaProcedimientosp> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LLAMADAFUNCION_LPAREN_RPAREN :
                //<LlamadaFuncion> ::= <id> '(' <ListaExpresiones> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LLAMADAFUNCION_LPAREN_RPAREN2 :
                //<LlamadaFuncion> ::= <id> '(' ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LLAMADAPROCEDIMIENTO_LPAREN_RPAREN_SEMI :
                //<LlamadaProcedimiento> ::= <id> '(' <ListaExpresiones> ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LLAMADAPROCEDIMIENTO_LPAREN_RPAREN_SEMI2 :
                //<LlamadaProcedimiento> ::= <id> '(' ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAEXPRESIONES :
                //<ListaExpresiones> ::= <Expresion> <ListaExpresionesp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAEXPRESIONESP_COMMA :
                //<ListaExpresionesp> ::= ',' <Expresion> <ListaExpresionesp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAEXPRESIONESP :
                //<ListaExpresionesp> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESION :
                //<Expresion> ::= <Termino> <Expresionp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONP_PLUS :
                //<Expresionp> ::= '+' <Termino> <Expresionp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONP_MINUS :
                //<Expresionp> ::= '-' <Termino> <Expresionp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONP :
                //<Expresionp> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TERMINO :
                //<Termino> ::= <Factor> <Terminop>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TERMINOP_TIMES :
                //<Terminop> ::= '*' <Factor> <Terminop>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TERMINOP_DIV :
                //<Terminop> ::= '/' <Factor> <Terminop>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TERMINOP :
                //<Terminop> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<Factor> ::= '(' <Expresion> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<Factor> ::= <id>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR2 :
                //<Factor> ::= <Numeros>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR3 :
                //<Factor> ::= <LlamadaFuncion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FACTOR_QUOTE_QUOTE :
                //<Factor> ::= '"' <cadenas> '"'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICION :
                //<Condicion> ::= <CondicionSimple> <Condicionp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONP_AMPAMP :
                //<Condicionp> ::= '&&' <CondicionSimple> <Condicionp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONP_PIPEPIPE :
                //<Condicionp> ::= '||' <CondicionSimple> <Condicionp>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONP :
                //<Condicionp> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_LT :
                //<CondicionSimple> ::= <Expresion> '<' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_GT :
                //<CondicionSimple> ::= <Expresion> '>' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_LTEQ :
                //<CondicionSimple> ::= <Expresion> '<=' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_GTEQ :
                //<CondicionSimple> ::= <Expresion> '>=' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_EQEQ :
                //<CondicionSimple> ::= <Expresion> '==' <Expresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONDICIONSIMPLE_LPAREN_RPAREN :
                //<CondicionSimple> ::= '(' <Condicion> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= id
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ID_ID_COMMA :
                //<id> ::= id ',' <id>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CADENAS_ID :
                //<cadenas> ::= id
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CADENAS_ID2 :
                //<cadenas> ::= id <cadenas>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMEROS_ENTEROPOSITIVO :
                //<Numeros> ::= enteroPositivo
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMEROS_ENTERONEGATIVO :
                //<Numeros> ::= enteroNegativo
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMEROS_REALPOSITIVO :
                //<Numeros> ::= realPositivo
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMEROS_REALNEGATIVO :
                //<Numeros> ::= realNegativo
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMEROS_TRUE :
                //<Numeros> ::= true
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NUMEROS_FALSE :
                //<Numeros> ::= false
                //todo: Create a new object using the stored user objects.
                return null;

            }
            throw new RuleException("Regla desconocida");
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            string message = "El codigo es correcto";
            Console.Write(message);
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Error en el token: '"+args.Token.ToString()+"'";
            Console.Write(message);
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Error causado por el token: '"+args.UnexpectedToken.ToString()+"'";
            Console.Write(message);
        }


    }
}
