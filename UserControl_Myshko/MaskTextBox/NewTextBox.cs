﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace MaskTextBox
{

    public class NewTextBox : TextBox
    {
        #region Поля
        /// <summary>
        /// Хранит значение Value;
        /// </summary>
        private string val;
        #endregion

        #region Свойства

        /// <summary>
        /// Устанавливает/возвращает значение данного элемента.
        /// get: возвращает значение поля "val"
        /// set: устанавливает значение в поле "val". Устанавливает и форматирует значение свойства "Text", базового класса, в соответствии со свойством "Mask"
        /// </summary>
        [Description("Значение элемента")]
        [Category("Мои свойсва")]
        public string Value
        {
            get
            {
                return val;
            }
            set
            {
                val = "";
                if ((Mask == "") || (CharReplace == '\0'))
                {
                    val = value;
                    this.Text = value;
                }
                else
                {
                    char[] DismemberedLine = Mask.ToCharArray();
                    string result = null;
                    int j = 0;
                    for (int i = 0; i < DismemberedLine.Length; i++)
                    {
                        if (j >= value.Length) break;
                        if (DismemberedLine[i] == CharReplace)
                        {
                            val = val + value[j];
                            DismemberedLine[i] = value[j];
                            j++;
                        }
                    }
                    foreach (var ch in DismemberedLine)
                    {
                        result += ch;
                    }
                    this.Text = result;
                }
            }
        }

        /// <summary>
        /// Устанавливает/возвращает значение маски данного элемента
        /// </summary>
        [Description("Маска элемента")]
        [Category("Мои свойсва")]
        public string Mask { get; set; }

        /// <summary>
        /// Устанавливает/возвращает символ заполнения пустого места в маске данного элемента
        /// </summary>
        [Description("Символ заполняющий место для вставки символа")]
        [Category("Мои свойсва")]
        public char CharReplace { get; set; }

        /// <summary>
        /// Возвращает статус валидации значения данного элемента, расположенного в соответствии с маской.
        /// true: если суммы блоков равны.
        /// false: если элемент содержит только один блок или суммы блоков различны. 
        /// </summary>
        [Description("Статус валидации элемента")]
        [Category("Мои свойсва")]
        public bool Validation
        {
            get
            {
                if ((Mask == "") || (CharReplace == '\0'))
                {
                    return false;
                }
                else
                {
                    string str = Mask;
                    char ch = '\0';
                    int count1 = 0, count2 = 0;
                    str = str.Replace(CharReplace, '\0');
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] != '\0') ch = str[i];
                        else
                        {
                            count1++;
                        }
                    }
                    if (str.Length == count1) return false;
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == ch) count2++;
                    }
                    if ((count1 + count2) == str.Length)
                    {
                        int[] Blocks = new int[count2+1];
                        if (Value.Length == 0) return false;
                        else
                        {
                            int j = 0, count = 0 ;
                            for(int i=0;i<Mask.Length;i++)
                            {
                                if (Mask[i] == ch) count++;
                                else
                                {
                                    if(j<Value.Length)
                                    {
                                        Blocks[count] = Blocks[count] + Convert.ToInt32(Value[j]);
                                        j++;
                                    }
                                    else Blocks[count] = Blocks[count] + 0;
                                }
                            }
                        }
                        int result = 0;
                        for(int i=0;i<count2;i++)
                        {
                            if (Blocks[i] == Blocks[i + 1]) result++;
                        }
                        if (result == count2) return true;
                        else return false;
                    }
                    else return false;
                }
            }
        }
        #endregion

        #region Методы

        /// <summary>
        /// Удаляет последний символ из значения элемента и вызывает свойство Value
        /// </summary>
        public void DeleteCharacter()
        {
            string str = "";
            for (int i = 0; i < Value.Length - 1; i++)
            {
                str = str + Value[i];
            }
            Value = str;
        }
        #endregion
    }
}
