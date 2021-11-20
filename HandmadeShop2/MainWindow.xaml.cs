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
using HandmadeShop2;
using HandmadeShop2.db;

namespace HandmadeShop2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static HandmadeShopEntities dba = new HandmadeShopEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
        //public static db.HandmadeShopEntities dba = new db.HandmadeShopEntities();

        public static db.Authotization authUser;

        private void Button_Click_SignIn(object sender, RoutedEventArgs e)
        {
            if (tbPassV.Password == "" || tbLoginV.Text == "")
            {
                MessageBox.Show("Введите логин с паролем");
            }
            foreach (var user in dba.Authotization)
            {
                if (user.Login == tbLoginV.Text.Trim())
                {
                    if (user.Password == tbPassV.Password.Trim() && user.ID_role == 2)
                    {
                        MessageBox.Show($"Привет Пользователь {user.Login}");
                        MainContent mainContent = new MainContent();
                        mainContent.Show();
                        this.Close();
                    }
                    if (user.Password == tbPassV.Password.Trim() && user.ID_role == 1)
                    {
                        MessageBox.Show($"Привет админ {user.Login}");
                        AMainContent aMainContent = new AMainContent();
                        aMainContent.Show();
                        this.Close();
                    }
                }
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Surname.Text == "" || tbLogin.Text == "" || tbPass.Password == "")
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                Users us = new Users();
                {
                    us.Name = Name.Text;
                    us.Surname = Surname.Text;
                }
                dba.Users.Add(us);
                dba.SaveChanges();
                Authotization aut = new Authotization();
                {
                    aut.Login = tbLogin.Text;
                    aut.Password = tbPass.Password;
                    aut.ID_role = 2;
                    aut.ID_user = us.ID_user;
                }
                dba.Authotization.Add(aut);
                dba.SaveChanges();
                MessageBox.Show("ok");

                MainContent mainContent = new MainContent();
                mainContent.Show();
                this.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
