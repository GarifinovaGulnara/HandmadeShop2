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
    /// Логика взаимодействия для AMainContent.xaml
    /// </summary>
    public partial class AMainContent : Window
    {
        public int x = 1;
        public AMainContent()
        {
            InitializeComponent();
            GetInfo();
        }

        private void GetInfo()
        {
            tblock_1.Text = "";
            tblock2.Text = "";
            tblock3.Text = "";
            tblock4.Text = "";
            db.Product product = new db.Product();
            try
            {
                var lst1 = from cust in MainWindow.dba.Product
                           where cust.ID_product == x
                           select cust;

                var lst2 = from cust in MainWindow.dba.Product
                           where cust.ID_product == x + 1
                           select cust;

                var lst3 = from cust in MainWindow.dba.Product
                           where cust.ID_product == x + 2
                           select cust;

                var lst4 = from cust in MainWindow.dba.Product
                           where cust.ID_product == x + 3
                           select cust;

                tblock_1.Text = lst1.First().Name + "\n" + lst1.First().Price;
                tblock2.Text = lst2.First().Name + "\n" + lst2.First().Price;
                tblock3.Text = lst3.First().Name + "\n" + lst3.First().Price;
                tblock4.Text = lst4.First().Name + "\n" + lst4.First().Price;
            }
            catch { }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainContent main = new MainContent();
            main.Show();
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (x + 4 <= MainWindow.dba.Product.Count<db.Product>())
            {
                x += 4;
            }
            else
            {
                x = 1;
            }
            GetInfo();
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (x - 4 > 0)
            {
                x -= 4;
            }
            else
            {
                x = MainWindow.dba.Product.Count<db.Product>();
            }
            GetInfo();
        }

        private void Add_product_Click(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.Show();
            this.Close();
        }
    }
}
