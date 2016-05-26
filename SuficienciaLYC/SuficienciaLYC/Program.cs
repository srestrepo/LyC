using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.calitha.goldparser;

namespace SuficienciaLYC
{
    class Program
    {
        static int Main(string[] args)
        {

            MyParser myParser;

            string grammarTable = "GramaticaFinal.cgt";
            string testFile, programText;

            if (args.Length == 0)
            {
                System.Console.WriteLine("Cantidad de argumentos incorrecta.");
                System.Console.WriteLine("Uso: SuficienciaLYC.exe codigo.txt");
                return 1;
            }

            myParser = new MyParser(grammarTable);

            testFile = args[0];

            programText = System.IO.File.ReadAllText(testFile);

            myParser.Parse(programText);

            return (0);
        }
    }
}
