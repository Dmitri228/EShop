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
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegisterWindow w1 = new RegisterWindow();
            w1.Show();
        }
    }
}

/*
  SqlConnection conn = new SqlConnection(@"Data Source=DIMA\MSSQLSERVER1; Initial Catalog=EShopDB; Integrated Security=True;");

  try
  {
      if (conn.State == ConnectionState.Closed)
          conn.Open();

      string query = "SELECT COUNT(1) FROM dbo.tblUser WHERE Login=@Login AND Password=@Password";
      SqlCommand sqlCmd = new SqlCommand(query, conn);
      sqlCmd.CommandType = CommandType.Text;
      sqlCmd.Parameters.AddWithValue("@Login", txbLogin.Text);
      sqlCmd.Parameters.AddWithValue("@Password", passwordBox.Password);
      int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
      if (count == 1)
      {
          this.Hide();
          MainWindow w1 = new MainWindow();
          w1.Show();
      }
      else
      {
          MessageBox.Show("Неверный логин или пароль");
      }
  }
  catch(Exception ex)
  {
      MessageBox.Show(ex.Message);
  }
  finally
  {
      conn.Close();
  }
*/
