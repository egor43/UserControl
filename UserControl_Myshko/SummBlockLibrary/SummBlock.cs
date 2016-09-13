using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SummBlockLibrary
{
    public class SummBlock
    {
        public string IncomingSymbol (string TextOfTextBlock, char Input, string FillCharacter)
        {
            Match match = Regex.Match(TextOfTextBlock, FillCharacter);
            char[] DismemberedLine = TextOfTextBlock.ToCharArray();
            if (match.Success)
            {
                DismemberedLine[match.Groups[2].Index] = Input;
            }
            return DismemberedLine.ToString();
        }
    }
}
