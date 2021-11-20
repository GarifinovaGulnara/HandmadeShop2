﻿using System;
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
    /// Логика взаимодействия для MainContent.xaml
    /// </summary>
    public partial class MainContent : Window
    {
        public MainContent()
        {
            InitializeComponent();
            GetInfo();
        }

        private void GetInfo()
        {
            var lst = MainWindow.dba.Product;
            foreach (var item in lst)
            {
                tblock_1.Text = item.Name + "\n" + item.Price.ToString();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Statement_Click(object sender, RoutedEventArgs e)
        {
            MainStatement stat = new MainStatement();
            stat.Show();
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
