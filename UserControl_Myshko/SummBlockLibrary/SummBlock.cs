using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SummBlockLibrary
{
    public class SummBlock
    {
        public static string IncomingSymbol(string TextOfTextBlock, string Input, char FillCharacter)
        {
            char[] DismemberedLine = TextOfTextBlock.ToCharArray();
            string result = null;
            for (int i = 0; i < DismemberedLine.Length; i++)
            {
                if (DismemberedLine[i] == FillCharacter)
                {
                    DismemberedLine[i] = Input[0];
                    break;
                }
            }
            foreach (var ch in DismemberedLine)
            {
                result += ch;
            }
            return result;
        }

        public static string DeleteCharacter(string TextOfTextBlock, char FillCharacter, char DelimiterCharacter)
        {
            StringBuilder str = new StringBuilder(TextOfTextBlock);
            for(int i=str.Length-1;i>=0;i--)
            {
                if((str[i]!=FillCharacter)&&(str[i]!=DelimiterCharacter))
                {
                    str[i] = FillCharacter;
                    break;
                }
            }
            return str.ToString();
        }

        public static bool CompareBlocks(string TextOfTextBlock, char DelimiterCharacter, int NumberOfBlocks)
        {
            int [] Blocks = new int[NumberOfBlocks];
            int result = 0;
            StringBuilder str = new StringBuilder(TextOfTextBlock);
            for (int i=0; i<str.Length; i++)
            {
                if(str[i]!=DelimiterCharacter)
                {
                    Blocks[result] +=Convert.ToInt32(str[i]);
                }
                else
                {
                    if (result < NumberOfBlocks) result++;
                    else throw new Exception("Неверное колличество блоков");
                }
            }
            result = 1;
            for(int i = 0; i < Blocks.Length-1; i++)
            {
                if (Blocks[i] == Blocks[i + 1]) result++;
            }
            if (result == NumberOfBlocks) return true;
            else return false;
        }

    }
}
