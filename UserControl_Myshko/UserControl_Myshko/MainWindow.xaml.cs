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
            textBox.Text = textBox.Mask;
        }

        #region Обработчики событий

        /// <summary>
        /// Обрботчик события нажатия на цифровую клавишу в пользовательском элементе "TableButon"
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void TableButton_NumClick(object sender, EventArgs e)
        {
            textBox.Mask = SummBlock.IncomingSymbol(textBox.Mask, ((Button)sender).Tag.ToString(), textBox.CharReplace);
            textBox.Text = textBox.Mask;
        }

        /// <summary>
        /// Обрботчик события нажатия на клавишу "Back" в пользовательском элементе "TableButon"
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void TableButton_BackClick(object sender, EventArgs e)
        {
            textBox.Mask = SummBlock.DeleteCharacter(textBox.Mask, textBox.CharReplace, '-');
            textBox.Text = textBox.Mask;
        }

        /// <summary>
        /// Обрботчик события нажатия на клавишу "OK" в пользовательском элементе "TableButon"
        /// </summary>
        /// <param name="sender">Объект вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void TableButton_OkayClick(object sender, EventArgs e)
        {
            if (SummBlock.CompareBlocks(textBox.Mask, '-', 3)) MessageBox.Show("Сумма блоков равна!");
            else MessageBox.Show("Сумма блоков не равна!");
            //textBox.Text=textBox.Tag.ToString();
        }
    }
    #endregion
}
