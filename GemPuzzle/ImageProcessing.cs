using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GemPuzzle
{
    class ImageProcessing
    {
        int size;
        public ImageProcessing(int _size)
        {
            size = _size;
            imageGrid = new Image[size,size];
            CreateGrid();
        }
        public void Reset()
        {
            CreateGrid();
        }

        public BitmapImage LoadAuxImg()
        {
            BitmapImage sourceBitmap = LoadBitmap("/GemPuzzle;component/ImagesGame/monalisa.jpg");

            return sourceBitmap;
        }

        private void CreateGrid()
        {
            BitmapImage sourceBitmap = LoadBitmap("/GemPuzzle;component/ImagesGame/monalisa.jpg");

            int widthImage = sourceBitmap.PixelWidth / size;
            int heightImage = sourceBitmap.PixelHeight / size;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Image cropImage = new Image();
                    cropImage.Source = Crop(sourceBitmap, j * widthImage, i * heightImage, sourceBitmap.PixelWidth / size, sourceBitmap.PixelHeight / size);

                    imageGrid[i,j] = cropImage;
                }
            }
        }
        BitmapImage LoadBitmap(string path)
        {
            BitmapImage img = new BitmapImage();
            img.CreateOptions = BitmapCreateOptions.None;
            Stream s = Application.GetResourceStream(new Uri(path, UriKind.Relative)).Stream;
            img.SetSource(s);
            return img;
        }
        private BitmapImage Crop(BitmapImage imagen, int xOffset, int yOffset, int width, int height)
        {
            BitmapImage bmp;
            WriteableBitmap imagenOrigen = null;

            imagenOrigen = new WriteableBitmap(imagen);

            // Get the width of the source image
            var sourceWidth = imagenOrigen.PixelWidth;

            // Get the resultant image as WriteableBitmap with specified size
            var wImage = new WriteableBitmap(width, height);

            // Create the array of bytes
            for (var x = 0; x <= height - 1; x++)
            {
                var sourceIndex = xOffset + (yOffset + x) * sourceWidth;
                var destinationIndex = x * width;

                Array.Copy(imagenOrigen.Pixels, sourceIndex, wImage.Pixels, destinationIndex, width);
            }

            BitmapImage bmImage = new BitmapImage();
            using (MemoryStream ms = new MemoryStream())
            {
                wImage.SaveJpeg(ms, (int)wImage.PixelWidth, (int)wImage.PixelHeight, 0, 100);
                bmp = new BitmapImage();
                bmp.SetSource(ms);
            }

            return bmp;
        }

        public Image[,] imageGrid { get; set; }


    }
}
