using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace GemPuzzle
{
    public partial class Dimensiones : PhoneApplicationPage
    {
        public Dimensiones()
        {
            InitializeComponent();
        }

        private void cuatro_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GameLocal.xaml?dimensiones=4", UriKind.Relative));
        }

        private void cinco_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GameLocal.xaml?dimensiones=5", UriKind.Relative));
        }

        private void seis_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/GameLocal.xaml?dimensiones=6", UriKind.Relative));
        }
    }
}