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
    }
    #endregion
}
