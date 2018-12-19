using EShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace EShop
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();
        }




        private void bетКуп_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxLogin.Text.Length > 0) 
            {
                if (passwordBoxPas.Password.Length > 0) 
                {
                    if (passwordBoxCopyPas.Password.Length > 0) 
                    {
                        if (passwordBoxPas.Password == passwordBoxCopyPas.Password) 
                        {                           
                            SqlConnection conn = new SqlConnection(@"Data Source=DIMA\MSSQLSERVER1; Initial Catalog=EShopDB; Integrated Security=True;");

                            try
                            {
                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();                           
                                //Тут код записи в БД
                                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.tblUser VALUES(@Login, @Password)", conn))
                                {
                                    command.Parameters.Add(new SqlParameter("Login", textBoxLogin.Text));
                                    command.Parameters.Add(new SqlParameter("Password", passwordBoxPas.Password));
                                    command.ExecuteNonQuery();
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                conn.Close();
                            }

                            MessageBox.Show("Пользователь зарегистрирован");
                            /*
                            this.Hide();
                            MainWindow w1 = new MainWindow();
                            w1.Show();
                            */
                        }
                        else MessageBox.Show("Пароли не совподают");
                    }
                    else MessageBox.Show("Повторите пароль");
                }
                else MessageBox.Show("Укажите пароль");
            }
            else MessageBox.Show("Укажите логин");
        }
    }
}
