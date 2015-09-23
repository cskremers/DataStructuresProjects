using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedListCounter
{
    class charFrequency
    {
        private char m_character;
        private long m_count;

        public charFrequency(char ch)
        {
            Character = ch;
            Count = 0;
        }

        public charFrequency(char ch, long charCount)
        {
            Character = ch;
            Count = charCount;
        }

        public char Character
        {
            set
            {
                m_character = value;
            }

            get
            {
                return m_character;
            }
        }

        public long Count
        {
            get
            {
                return m_count;
            }
            set
            {
                if (value < 0)
                    value = 0;

                m_count = value;
            }
        }

        public void Increment()
        {
            m_count++;

        }

        public override bool Equals(object obj)
        {
            bool equal = false;
            charFrequency cf = new charFrequency('\0', 0);

            cf = (charFrequency)obj;

            if (this.Character == cf.Character)
                equal = true;

            return equal;
        }

        public override string ToString()
        {
            String s = String.Format("{0}({1})     {2}", m_character, (byte)m_character, m_count);

            return s;
        }

    }
}
