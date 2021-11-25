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
using HandmadeShop2.db;

namespace HandmadeShop2
{
    /// <summary>
    /// Логика взаимодействия для NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        public static HandmadeShopEntities dba = new HandmadeShopEntities();
        public NewProduct()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AMainContent amain = new AMainContent();
            amain.Show();
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (NameProduct.Text == "" || Price.Text == "")
            {
                MessageBox.Show("Введите название и цену");
            }
            else
            {
                Product prod = new Product();
                {
                    prod.Name = NameProduct.Text;
                    prod.ID_categ = Convert.ToInt32(CategProduct.Text); 
                    prod.Price = Convert.ToInt32(Price.Text);
                    prod.Description = DescroptionProduct.Text;
                }
                dba.Product.Add(prod);
                dba.SaveChanges();
            }
            MessageBox.Show("Добавлено");
        }
    }
}
