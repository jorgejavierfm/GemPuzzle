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

namespace GemPuzzle
{    
    public partial class Juego : PhoneApplicationPage
    {
        Game juego;
        int movements = 0;

        public Juego()
        {
            InitializeComponent();
        }

        private void bGridMain_DetectTouchPosition(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Point position;
            double positionTemp;

            position = e.GetPosition(bGridMain);
            positionTemp = position.X;

            position.X = (int)position.Y / (int)(bGridMain.Height /juego.numbers.GetLength(0));
            position.Y = (int)positionTemp / (int)(bGridMain.Width / juego.numbers.GetLength(0));

            if (juego.Move(position))
            {
                movements++;
                movimientosCounter.Text = "Movimientos:  " + movements.ToString();
            }
        }
        private void bGridMain_Reset(object sender, RoutedEventArgs e)
        {
            movements=0;
            movimientosCounter.Text = "Movimientos:  " + movements.ToString();
            juego.Reset();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            String navigationMessage;

            int dimensiones = 3;

            if (NavigationContext.QueryString.TryGetValue("dimensiones", out navigationMessage))
            {
                dimensiones = int.Parse(navigationMessage);
            }

            juego = new Game(bGridMain, dimensiones);
            bImageReference.Source = juego.imagHelper.LoadAuxImg();
            movimientosCounter.Text = "Movimientos:  " + movements.ToString();
        }
    }
}