using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CodyKremers_AssignmentOne
{
    public class Program
    {
        static void Main(string[] args)
        {
            const byte INPUT_FILENAME = 0;
            const byte OUTPUT_FILENAME = 1;

            CharacterFrequency[] characterArray = new CharacterFrequency[256];

            for (int i = 0; i < 256; i++)
            {
                characterArray[i] = new CharacterFrequency((char)i);
                characterArray[i].setCharacter((char)i);
            }

            if (args.Length != 2)
            {
                Console.WriteLine("Usage:  CommandLine [input filename] [output file name]");
                Environment.Exit(0);
            }

            Console.WriteLine("The input filename is: {0}", args[INPUT_FILENAME]);
            Console.WriteLine("The output filename is: {0}", args[OUTPUT_FILENAME]);

            using (StreamReader SR = new StreamReader(args[INPUT_FILENAME]))
            {
                int read;
                FileInfo file = new FileInfo(args[INPUT_FILENAME]);
                long fileLength = file.Length;
                int f = Convert.ToInt32(fileLength);

                string path = File.ReadAllText(args[INPUT_FILENAME]);

                // Step 1
                char[] block = new char[1024];
                for (int k = 0; k < (f/1024); k++)
                {
                    // Step 2
                    read = SR.ReadBlock(block, 0, block.Length);

                    // Step 3
                    for (int i = 0; i < read; i++)
                    {
                        characterArray[(block[i])].increment();
                    }
                }
                
                // Step 4
                string text;
                int Cfrequency=0;

                for (int i = 0; i < characterArray.Length; i++)
                {
                    text = ((("") + (char)i + ("(") + i.ToString()) + (")") + "     " + characterArray[i].getFrequency(Cfrequency).ToString() + Environment.NewLine);
                    File.AppendAllText(args[OUTPUT_FILENAME], text, Encoding.UTF8);
                }
            }



        }
    }
}
