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
using System.Windows.Shapes;

namespace HandmadeShop2
{
    /// <summary>
    /// Логика взаимодействия для MainStatement.xaml
    /// </summary>
    public partial class MainStatement : Window
    {
        public MainStatement()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainContent main = new MainContent();
            main.Show();
            this.Close();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Отправлено");
        }
    }
}
