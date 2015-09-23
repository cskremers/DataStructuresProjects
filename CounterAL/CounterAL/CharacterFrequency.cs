using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace CodyKremers_AssignmentOne
{
    public class CharacterFrequency
    {
        private char CFCharacter;
        private int CFfrequency;

        public CharacterFrequency(char ch)
        {
            CFCharacter = ch;
        }

        public char getCharacter(char currentCharacter)
        {
            return CFCharacter;
        }

        public char setCharacter(char currentCharacter)
        {
            this.CFCharacter = currentCharacter;
            return currentCharacter;
        }

        public int getFrequency(int currentFrequency)
        {
            return CFfrequency;
        }

        public int setFrequency(int currentFrequency)
        {
            return currentFrequency;
        }

        public void increment()
        {
            CFfrequency++;
        }

        public bool Equals()
        {
            return true;
        }

        public string ToString()
        {
            return CFCharacter.ToString();
        }
    }
}