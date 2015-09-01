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
    public partial class Settings : PhoneApplicationPage
    {
        public delegate void DelegadoMusica(Boolean mensaje);

        public event DelegadoMusica music;
        public Settings()
        {
            InitializeComponent();
        }

        private void CheckBox_Click_1(object sender, RoutedEventArgs e)
        {
            if (Volumen.IsChecked.Value == false)
            {
                OnMusic(false);
            }
            else
            {
                OnMusic(true);
            }

        }

        private void OnMusic(Boolean mensaje)
        {
            if (music != null)
            {
                music(mensaje);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
    }
}