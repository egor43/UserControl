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
            textBox.Text = SummBlock.IncomingSymbol(textBox.Text, ((Button)sender).Tag.ToString(), '#');
        }

        private void TableButton_BackClick(object sender, EventArgs e)
        {
            textBox.Text = SummBlock.DeleteCharacter(textBox.Text, '#', '-');
        }

        private void TableButton_OkayClick(object sender, EventArgs e)
        {
            if (SummBlock.CompareBlocks(textBox.Text, '-', 3)) MessageBox.Show("Сумма блоков равна!");
            else MessageBox.Show("Сумма блоков не равна!");
            textBox.Text=textBox.Tag.ToString();
        }
    }
}
