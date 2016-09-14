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
        public UserControl1()
        {
            InitializeComponent();
        }
        public delegate void UserControlDelegate(object sender, EventArgs e);
        public event UserControlDelegate NumClick;
        public event UserControlDelegate BackClick;
        public event UserControlDelegate OkayClick;
        private void number_Click(object sender, RoutedEventArgs e)
        {
            if (NumClick != null)
                NumClick(sender, e);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (BackClick != null)
                BackClick(sender, e);
        }

        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            if (OkayClick != null)
                OkayClick(sender, e);
        }
    }
}
