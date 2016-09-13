using System.Text.RegularExpressions;

namespace SummBlockLibrary
{
    public class SummBlock
    {
        public static string IncomingSymbol (string TextOfTextBlock, string Input, char FillCharacter)
        {
            char[] DismemberedLine = TextOfTextBlock.ToCharArray();
            string result = null;
            for(int i=0;i<DismemberedLine.Length;i++)
            {
                if(DismemberedLine[i]==FillCharacter)
                {
                    DismemberedLine[i] = Input[0];
                    break;
                }
            }
            foreach(var ch in DismemberedLine)
            {
                result += ch;
            }
            return result ;
        }
    }
}
