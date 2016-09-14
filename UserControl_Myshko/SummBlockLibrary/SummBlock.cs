using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SummBlockLibrary
{
    /// <summary>
    /// Класс для работы с текстовым полем программы. 
    /// </summary>
    public static class SummBlock
    {
        #region Методы класса
        /// <summary>
        /// Метод для последовательного добавления символа в строку
        /// </summary>
        /// <param name="TextOfTextBlock">Входная строка, которую необходимо заменить</param>
        /// <param name="Input">Символ который необходимо вставить</param>
        /// <param name="FillCharacter">Символ, заполняющий пустое место</param>
        /// <returns>Возвращает измененную входную строку в которой первый встретившийся "FillCharacter" заменен на "Input"</returns>
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

        /// <summary>
        /// Метод для последовательного удаления символа из строки по принципу: "последний добавлен - первый удален"
        /// </summary>
        /// <param name="TextOfTextBlock">Входная строка, которую необходимо заменить</param>
        /// <param name="FillCharacter">Символ, заполняющий пустое место</param>
        /// <param name="DelimiterCharacter">Символ, разделяющий блоки</param>
        /// <returns>Возвращает измененную входную строку в которой последний добавленный символ заменен на "FillCharacter"</returns>
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

        /// <summary>
        /// Проверяет, равны ли суммы всех блоков
        /// </summary>
        /// <param name="TextOfTextBlock">Входная строка, содержащая блоки и разделители блоков</param>
        /// <param name="DelimiterCharacter">Символ, разделяющий блоки</param>
        /// <param name="NumberOfBlocks">Колличество блоков</param>
        /// <returns>Истина - если сумма блоков равна. Ложь - если сумма блоков не равна</returns>
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
        #endregion
    }
}
