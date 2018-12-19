using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using EShop.Model;
using System.Windows;

namespace EShop.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private Model.Product selectedProduct;
        private List<Product> products = new List<Product>();

        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public ObservableCollection<Model.Product> Product { get; set; }
        public Model.Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        public ProductViewModel()
        {
            Product = new ObservableCollection<Model.Product>
            {
                new Model.Product {Title="Iron Man #125", Company="Marvel", Price=5600, Image="image/img8.jpg" },
                new Model.Product {Title="Thor #256", Company="Marvel", Price =6000, Image="image/img3.jpg" },
                new Model.Product {Title="X Men #56", Company="Marvel", Price=5600, Image="image/img1.png" },
                new Model.Product {Title="Batman and Robin #1", Company="DC", Price=3500 ,Image="image/img13.jpg"},
                new Model.Product {Title="Cat Woman #12", Company="DC", Price=3500 ,Image="image/img14.jpg"},
                new Model.Product {Title="Hulk #68", Company="Marvel", Price=3500,Image="image/img2.jpg" },
                new Model.Product {Title="Spider Man #51", Company="Marvel", Price=3500,Image="image/img12.jpg" },
                new Model.Product {Title="Nightwing #3", Company="DC", Price=3500 ,Image="image/img15.jpg"},
                new Model.Product {Title="Superman #45", Company="DC", Price=3500 ,Image="image/img16.jpg"}
            };
        }
        
        private RelayCommand showProducts;
        public RelayCommand ShowProducts
        {
            get
            {
                return showProducts ??
                  (showProducts = new RelayCommand(obj =>
                  {
                      ProduktWindow produktWindow = new ProduktWindow(this);
                      produktWindow.Show();
                  }));
            }
        }

        private RelayCommand showCart;
        public RelayCommand ShowCart
        {
            get
            {
                return showCart ??
                  (showCart = new RelayCommand(obj =>
                  {
                      CartWindow cartWindow = new CartWindow(this);
                      cartWindow.Show();
                  }));
            }
        }

        private RelayCommand showAccount;
        public RelayCommand ShowAccount
        {
            get
            {
                return showAccount ??
                  (showAccount = new RelayCommand(obj =>
                  {
                      AccountWindow accountWindow = new AccountWindow();
                      accountWindow.Show();
                  }));
            }
        }


        private RelayCommand signIn;
        public RelayCommand SignIn
        {
            get
            {
                return signIn ??
                  (signIn = new RelayCommand(obj =>
                  {
                      MainWindow mainWindow = new MainWindow(this);
                      mainWindow.Show();
                  }));
            }
        }

        private RelayCommand showHome;
        public RelayCommand ShowHome
        {
            get
            {
                return showHome ??
                  (showHome = new RelayCommand(obj =>
                  {
                      MainWindow mainWindow = new MainWindow(this);
                      mainWindow.Show();
                  }));
            }
        }
        
        private RelayCommand addProductToCart;
        public RelayCommand AddProductToCart
        {
            get
            {
                return addProductToCart ??
                  (addProductToCart = new RelayCommand(obj =>
                  {
                      Products.Add(SelectedProduct);
                  }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        

    }
}
