using System;
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

namespace WpfControlLibrary1
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public UserControl1()
        {
            InitializeComponent();
        }

        #region Делегаты
        /// <summary>
        /// Делегат для создания пользовательских событий
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        public delegate void UserControlDelegate(object sender, EventArgs e);
        #endregion

        #region События
        /// <summary>
        /// Событие нажатия на цифровую клавишу
        /// </summary>
        public event UserControlDelegate NumClick;
        /// <summary>
        /// Событие нажатия на клавишу "Back"
        /// </summary>
        public event UserControlDelegate BackClick;
        /// <summary>
        /// Событие нажатия на клавишу "ОК"
        /// </summary>
        public event UserControlDelegate OkayClick;
        #endregion

        #region Метобы вызова событий
        /// <summary>
        /// Метод вызова события "NumClick"
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void number_Click(object sender, RoutedEventArgs e)
        {
            if (NumClick != null)
                NumClick(sender, e);
        }

        /// <summary>
        /// Метод вызова события "BackClick"
        /// </summary>
        /// <param name="sender">Объект, вызвавшйи событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (BackClick != null)
                BackClick(sender, e);
        }

        /// <summary>
        /// Метод вызова события "OkayClick"
        /// </summary>
        /// <param name="sender">Объект, вызвавшйи событие</param>
        /// <param name="e">Дополнительные параметры</param>
        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            if (OkayClick != null)
                OkayClick(sender, e);
        }
        #endregion
    }
}
