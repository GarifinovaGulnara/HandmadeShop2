using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace HandmadeShop2
{
    /// <summary>
    /// Логика взаимодействия для NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        byte[] photo;
        bool choosephoto = false;
        public static HandmadeShopEntities1 dba = new HandmadeShopEntities1();
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
            if (NameProduct.Text == "" || CategProduct.Text == "" || Price.Text == "" || choosephoto == false)
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Photo ph = new Photo();
                {
                    ph.photo = photo;
                }
                dba.Photo.Add(ph);
                dba.SaveChanges();
                Product prod = new Product();
                {
                    prod.Name = NameProduct.Text;
                    prod.ID_categ = Convert.ToInt32(CategProduct.Text); 
                    prod.Price = Convert.ToInt32(Price.Text);
                    prod.Description = DescroptionProduct.Text;
                    prod.ID_photo = ph.ID_photo;
                }
                dba.Product.Add(prod);
                dba.SaveChanges();
                MessageBox.Show("Добавлено");
            }
        }

        private void Add_Img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 1;
            if (ofdPicture.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(ofdPicture.FileName);
                image.EndInit();
                Img.Source = image;
                photo = File.ReadAllBytes(ofdPicture.FileName);
                choosephoto = true;
            }
        }
    }
}
