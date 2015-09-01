using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;


namespace GemPuzzle
{
    class Graphics
    {
        Grid bGridMain;
        int[,] numbers;
        Image [,] imageGrid;

        public Graphics(Grid _bGridMain,int [,] _numbers,Image [,] _imageGrid)
        {
            bGridMain = _bGridMain;
            numbers = _numbers;
            imageGrid = _imageGrid;
        }

        public void Draw()
        {
            double width;
            double height;
 
            width = bGridMain.Width;
            height = bGridMain.Height;

            for (int i = 0; i < numbers.GetLength(0); i++)
                DrawColumns(new ColumnDefinition(),width/numbers.GetLength(0));

            for (int i = 0; i < numbers.GetLength(0); i++)
                DrawRows(new RowDefinition(), height/numbers.GetLength(0));

            DrawImages();

            for (int i = 0; i < numbers.GetLength(0); i++)
                 for (int j = 0; j < numbers.GetLength(0); j++)
                     DrawNumber(new TextBlock(), new Border(), numbers[i, j], i, j);
            
        }
        public void Refresh()
        {
            bGridMain.Children.Clear();
            Draw();
        }
        private void DrawColumns(ColumnDefinition colum, double width)
        {
            colum.Width = new System.Windows.GridLength(width);
            bGridMain.ColumnDefinitions.Add(colum);
        }
        private void DrawRows(RowDefinition row, double height)
        {
            row.Height = new System.Windows.GridLength(height);
            bGridMain.RowDefinitions.Add(row);
        }
        private void DrawNumber(TextBlock numberContainer,Border border,int number,int x,int y)
        {
            int lastnumber = numbers.GetLength(0) * numbers.GetLength(0)-1;

            border.BorderThickness = new Thickness(0.5);
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.SetValue(Grid.RowProperty, x);
            border.SetValue(Grid.ColumnProperty, y);
            bGridMain.Children.Add(border);

            if (number!=lastnumber)
            {
                numberContainer.Foreground = new SolidColorBrush(Colors.White);
                numberContainer.FontSize = 50;
                numberContainer.FontWeight =FontWeights.Thin;

                numberContainer.Text = (number+1).ToString();
                numberContainer.SetValue(Grid.RowProperty, x);
                numberContainer.SetValue(Grid.ColumnProperty, y);
                numberContainer.HorizontalAlignment = HorizontalAlignment.Center;
                numberContainer.VerticalAlignment = VerticalAlignment.Center;
                bGridMain.Children.Add(numberContainer);
            }
        }
        private void DrawImages()
        {
            int lastnumber = numbers.GetLength(0) * numbers.GetLength(0) - 1;

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(0); j++)
                {
                    if (numbers[i,j]!=lastnumber)
                    {
                        imageGrid[i, j].SetValue(Grid.RowProperty, i);
                        imageGrid[i, j].SetValue(Grid.ColumnProperty, j);

                        bGridMain.Children.Add(imageGrid[i, j]);
                    }
                    
                }
            }
        }

        public bool checkNumbers { get; set; }
    }
}
