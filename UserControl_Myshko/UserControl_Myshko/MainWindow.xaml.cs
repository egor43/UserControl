using MaskTextBox;
using SummBlockLibrary;
using System;
using System.Windows;
using System.Windows.Controls;

namespace UserControl_Myshko
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Обработчики событий

        /// <summary>
        /// Обрботчик события нажатия на цифровую клавишу в пользовательском элементе "TableButon"
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void TableButton_NumClick(object sender, EventArgs e)
        {
            textBox.Value = textBox.Value + ((Button)sender).Tag.ToString();
        }

        /// <summary>
        /// Обрботчик события нажатия на клавишу "Back" в пользовательском элементе "TableButon"
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void TableButton_BackClick(object sender, EventArgs e)
        {
            textBox.DeleteCharacter();

        }

        /// <summary>
        /// Обрботчик события нажатия на клавишу "OK" в пользовательском элементе "TableButon"
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void TableButton_OkayClick(object sender, EventArgs e)
        {
            textBox.Text = textBox.Validation.ToString();
        }

        /// <summary>
        /// Обработка нажатия текстовых клавиш
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void textBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            int x;
            if (Int32.TryParse(e.Text, out x))
            {
                if (textBox.SelectionStart < textBox.Mask.Length)
                {
                    for (;;)
                    {
                        if (textBox.Mask[textBox.SelectionStart] != textBox.CharReplace)
                        {
                            textBox.SelectionStart++;
                            if (textBox.SelectionStart >= textBox.Mask.Length) break;
                        }
                        else break;
                    }
                    if (textBox.SelectionStart < textBox.Mask.Length)
                    {
                        int selectionstrt = textBox.SelectionStart, count = 0;
                        for (int i = 0; i <= textBox.SelectionStart; i++)
                        {
                            if (textBox.Mask[i] == textBox.CharReplace) count++;
                        }
                        if (count <= textBox.Value.Length)
                        {
                            textBox.Value = textBox.Value.Insert(count - 1, e.Text);
                            textBox.SelectionStart = selectionstrt + 1;
                            e.Handled = true;
                        }
                        else if (count == textBox.Value.Length + 1)
                        {
                            textBox.Value = textBox.Value + e.Text;
                            textBox.SelectionStart = selectionstrt + 1;
                            e.Handled = true;
                        }
                        else e.Handled = true;
                    }
                }
                else e.Handled = true;
            }
            else e.Handled = true;

        }

        /// <summary>
        /// Обработка нажатия служебных клавиш
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void textBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {
                textBox.Value = "";
                e.Handled = true;
            }
            if (e.Key == System.Windows.Input.Key.Space)
            {
                e.Handled = true;
            }
            if (e.Key == System.Windows.Input.Key.Back)
            {
                if (textBox.SelectionStart > 0)
                {
                    int selectionstrt = textBox.SelectionStart, count = -1;
                    for (int i = 0; i < textBox.SelectionStart; i++)
                    {
                        if (textBox.Mask[i] == textBox.CharReplace) count++;
                    }
                    if(count<textBox.Value.Length) textBox.Value = textBox.Value.Remove(count, 1);
                    selectionstrt--;
                    for (;;)
                    {

                        if ((selectionstrt > 0) && (textBox.Mask[selectionstrt] != textBox.CharReplace)) selectionstrt--;
                        else break;
                    }
                    textBox.SelectionStart = selectionstrt;
                    e.Handled = true;
                }
                else e.Handled = true;
            }
        }

    }
    #endregion
}
