﻿using EShop.ViewModel;
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

namespace EShop
{
    /// <summary>
    /// Логика взаимодействия для ProduktWindow.xaml
    /// </summary>
    public partial class ProduktWindow : Window
    {
        public ProduktWindow(ProductViewModel productViewModel)
        {
            InitializeComponent();

            DataContext = productViewModel;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
 
    }
}
