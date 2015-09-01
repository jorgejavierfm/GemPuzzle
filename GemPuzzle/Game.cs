using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace GemPuzzle
{
    class Game
    {
        Graphics gemGraphics;
        ImageProcessing gemImages;
        Point blankPosition;
        int size;

        public Game(Grid bGridMain,int _size)
        {
            int counter=0;
            size = _size;
            numbers = new int[size,size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    numbers[i, j] = counter++;

            blankPosition.X = size - 1;
            blankPosition.Y = size - 1;

            gemImages = new ImageProcessing(size);

            Shuffle();
            
            gemGraphics = new Graphics(bGridMain,numbers,gemImages.imageGrid);
            gemGraphics.Draw();
        }

        public void Shuffle()
        {
            int randNumber;
            int nextMove;
            int lastMove=0;

            Random rnd = new Random(Environment.TickCount);

            randNumber = rnd.Next(5000, 20000);
            for (int i = 0; i<randNumber; i++)
            {
                bool valid = false;

                do
                {
                    nextMove = rnd.Next(1,5);
                    switch (nextMove)
                    {
                        case 1:
                            valid = MoveUp(lastMove);
                            break;
                        case 2:
                            valid = MoveLeft(lastMove);
                            break;
                        case 3:
                            valid = MoveDown(lastMove);
                            break;
                        case 4:
                            valid = MoveRight(lastMove);
                            break;
                    }
                } while (valid != true);

                lastMove = nextMove;
            }
        }
        public bool Move(Point touchPosition)
        {
            if (CheckBlank(numbers, touchPosition))
            {
                Swap(blankPosition, touchPosition);
                SwapImages(blankPosition, touchPosition);
                blankPosition.X = touchPosition.X;
                blankPosition.Y = touchPosition.Y;
                gemGraphics.Refresh();
                return true;
            }
            return false;
        }
        public void Reset()
        {
            int counter=0;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    numbers[i, j] = counter++;

            blankPosition.X = size - 1;
            blankPosition.Y = size - 1;

            gemImages.Reset();
            Shuffle();
            gemGraphics.Refresh();
        }

        private bool MoveUp(int last)
        {
            if (blankPosition.X != 0 && last!=3)
            {
                Swap(new Point(blankPosition.X - 1, blankPosition.Y), blankPosition);
                SwapImages(new Point(blankPosition.X - 1, blankPosition.Y), blankPosition);
                blankPosition.X = blankPosition.X - 1;
                return true;
            }

            return false;
        }
        private bool MoveLeft(int last)
        {
            if (blankPosition.Y != 0 && last!=4)
            {
                Swap(new Point(blankPosition.X, blankPosition.Y - 1),blankPosition);
                SwapImages(new Point(blankPosition.X, blankPosition.Y - 1), blankPosition);
                blankPosition.Y = blankPosition.Y - 1;
                return true;
            }

            return false;
        }
        private bool MoveDown(int last)
        {
            if (blankPosition.X != size-1 && last!=1)
            {
                Swap(new Point(blankPosition.X + 1, blankPosition.Y), blankPosition);
                SwapImages(new Point(blankPosition.X + 1, blankPosition.Y), blankPosition);
                blankPosition.X = blankPosition.X + 1;
                return true;
            }
            return false;
        }
        private bool MoveRight(int last)
        {
            if (blankPosition.Y != size-1 && last!=2)
            {
                Swap(new Point(blankPosition.X, blankPosition.Y + 1),blankPosition);
                SwapImages(new Point(blankPosition.X, blankPosition.Y + 1), blankPosition);
                blankPosition.Y = blankPosition.Y + 1;
                return true;
            }
            return false;
        }

        private bool CheckBlank(int[,] numbers,Point position)
        {
            Point positionTemp = position;

            //Subo

            positionTemp.X = positionTemp.X - 1;

            if(positionTemp.X>=0 && positionTemp.Equals(blankPosition))
                return true;
            else
                positionTemp=position;

            //Bajo
            positionTemp.X = positionTemp.X + 1;

            if (positionTemp.X<size && positionTemp.Equals(blankPosition))
                return true;
            else
                positionTemp = position;

            //Izquierda
            positionTemp.Y = positionTemp.Y - 1;

            if (positionTemp.Y>=0 && positionTemp.Equals(blankPosition))
                return true;
            else
                positionTemp = position;

            //Derexa
            positionTemp.Y = positionTemp.Y + 1;

            if (positionTemp.Y<size && positionTemp.Equals(blankPosition))
                return true;
            else
                positionTemp = position;

            return false;
            
        }
        private void Swap(Point origin,Point destiny)
        {
            int temp;

            temp = numbers[(int)origin.X, (int)origin.Y];
            numbers[(int)origin.X, (int)origin.Y] = numbers[(int)destiny.X, (int)destiny.Y];
            numbers[(int)destiny.X, (int)destiny.Y] = temp;
        }

        private void SwapImages(Point origin, Point destiny)
        {
            Image temp;

            temp = gemImages.imageGrid[(int)origin.X, (int)origin.Y];
            gemImages.imageGrid[(int)origin.X, (int)origin.Y] = gemImages.imageGrid[(int)destiny.X, (int)destiny.Y];
            gemImages.imageGrid[(int)destiny.X, (int)destiny.Y] = temp;
        }

        public int[,] numbers { get; set; }
        public ImageProcessing imagHelper 
        {
            get { return gemImages;}
        }
    }
}
