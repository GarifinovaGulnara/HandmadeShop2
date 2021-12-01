using System;
using System.Collections.Generic;
using System.Drawing;
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
using Microsoft.Data.SqlClient;

namespace HandmadeShop2
{
    /// <summary>
    /// Логика взаимодействия для MainContent.xaml
    /// </summary>
    /// 
    public partial class MainContent : Window
    {
        public int x = 1;
        public MainContent()
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
                var ph1 = (from cust in MainWindow.dba.Product
                           join ph in MainWindow.dba.Photo on cust.ID_photo equals ph.ID_photo
                           where cust.ID_product == x
                           select ph.photo).First();

                var ph2 = (from cust in MainWindow.dba.Product
                           join ph in MainWindow.dba.Photo on cust.ID_photo equals ph.ID_photo
                           where cust.ID_product == x + 1
                           select ph.photo).First();

                var ph3 = (from cust in MainWindow.dba.Product
                           join ph in MainWindow.dba.Photo on cust.ID_photo equals ph.ID_photo
                           where cust.ID_product == x + 2
                           select ph.photo).First();

                var ph4 = (from cust in MainWindow.dba.Product
                           join ph in MainWindow.dba.Photo on cust.ID_photo equals ph.ID_photo
                           where cust.ID_product == x + 3
                           select ph.photo).First();
                img1.Source = ByteArrayToImage(ph1);
                img2.Source = ByteArrayToImage(ph2);
                img3.Source = ByteArrayToImage(ph3);
                img4.Source = ByteArrayToImage(ph4);
            }
            catch { }
        }

        public BitmapSource ByteArrayToImage(byte[] buffer)
        {
            using (var stream = new MemoryStream(buffer))
            {
                return BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (x+4 <= MainWindow.dba.Product.Count<db.Product>())
            {
                x +=4;
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
                x -=4;
            }
            else
            {
                x = MainWindow.dba.Product.Count<db.Product>();
            }
            GetInfo();
        }
    }
}
