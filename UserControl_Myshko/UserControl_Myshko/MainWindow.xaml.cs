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
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void TableButton_NumClick(object sender, EventArgs e)
        {
           textBox.Text = SummBlock.IncomingSymbol(textBox.Text,((Button)sender).Tag.ToString(),'#');
        }
    }
}
