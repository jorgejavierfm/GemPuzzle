using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GemPuzzle.Resources;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System.IO;

namespace GemPuzzle
{    
    public partial class GameLocal : PhoneApplicationPage
    {
        public delegate void DelegadoMovimiento(System.Windows.Point mensaje);

        public event DelegadoMovimiento move;
        System.Windows.Point puntero;
        public delegate void DelegadoMovimiento(System.Windows.Point mensaje);

        public event DelegadoMovimiento move;
        Game juego;

        Settings aj = new Settings();
        Boolean musica = true;


        double ancho, alto, posicionx, posiciony;

        // Constructor
        public GameLocal()
        {
            InitializeComponent();
            Graphics gemGraphics = new Graphics(bGridMain);
            gemGraphics.Draw();
            ancho = ActualHeight / 4;
            alto = ActualWidth / 4;

            aj.music += new Settings.DelegadoMusica(AjusteMusica);
            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void ReproducirSonido()
        {
            Stream stream = new MemoryStream();
            byte[] bytes = new byte[stream.Length];
            int numBytesToRead = (int)stream.Length;
            stream.Read(bytes, numBytesToRead, 10);
            //stream.Read();
            SoundEffect efecto = SoundEffect.FromStream(stream);
           efecto.Play();
        }

        private void bCanvas_MouseLeftButtonDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            puntero = e.GetPosition(bGridMain);
            posicionx = (int)puntero.X / 100;
            posiciony = (int)puntero.Y / 100;

            muestra.Text = posicionx.ToString();

        }

        void IniciarTabla()
        {

        }

        private void bCanvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {


        }
        private void OnMove(System.Windows.Point mensaje)
        {
            if (move != null)
            {
                move(mensaje);
            }

        }

        void AjusteMusica(Boolean mensaje)
        {
            musica = mensaje;
        }

        void Sonido()
        {
            if (musica == true)
            {
                //SoundEffect sound = new SoundEffect();
                //soundInstance = sound.CreateInstance();
                //soundInstance.Play();
            }
        }

        // Código de ejemplo para compilar una ApplicationBar traducida
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}