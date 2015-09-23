using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LinkedListCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            const byte INPUT_FILENAME = 0;
            const byte OUTPUT_FILENAME = 1;

            if (args.Length != 2)
            {
                Console.WriteLine("Usage:  CommandLine [input filename] [output file name]");
                Environment.Exit(0);
            }

            Console.WriteLine("The input filename is: {0}", args[INPUT_FILENAME]);
            Console.WriteLine("The output filename is: {0}", args[OUTPUT_FILENAME]);

            StreamReader SR = new StreamReader(args[INPUT_FILENAME]);
            FileInfo file = new FileInfo(args[INPUT_FILENAME]);
            long fileLength = file.Length;
            int f = Convert.ToInt32(fileLength);
            int read;
            char currentChar = 'A';
            string text = "";

            /////////////////////////////////////////////////////////////////////////////////////////

            LinkedList<charFrequency> list = new LinkedList<charFrequency>();
            

            //read text file
            char[] block = new char[1];
            for (int k = 0; k < f; k++)
            {
                read = SR.ReadBlock(block, 0, block.Length);
                currentChar = block[0];

                charFrequency cf = new charFrequency(currentChar, 0);
                 
                if (!list.Contains(cf))
                {
                    list.AddLast(cf);
                    cf.Increment();
                }
                else if (list.Contains(cf))
                {
                    LinkedListNode<charFrequency> node = list.Find(cf);
                    node.Value.Increment();

                    cf = null;
                    cf = node.Value;
                }
                File.WriteAllText(args[OUTPUT_FILENAME], String.Empty);
                LinkedListNode<charFrequency> nodeList = list.First;

                for (int i = 0; i < list.Count; i++)
                {
                    text = ("" + nodeList.Value + Environment.NewLine);
                    
                    File.AppendAllText(args[OUTPUT_FILENAME], text, Encoding.UTF8);
                    nodeList = nodeList.Next;
                }
            }
            Console.WriteLine("The size of the list is {0}", list.Count);
        }
    }
}
