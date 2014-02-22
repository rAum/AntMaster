using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AntMaster
{
    class PreviewImage
    {
        Bitmap  mBmp;     // obrazek
        int     mSize;    // rozmiar bitmapy
        Color[] mPalette; // LUT dla kolorow

        public PreviewImage(string paletteFile = "palette2.bmp")
        {
            mPalette = new Color[256];
            Bitmap palette = (Bitmap)Bitmap.FromFile(paletteFile);
            for (int i = 0; i < 255; ++i)
            {
                mPalette[i] = palette.GetPixel(i, 0);
            } 
        }

        public void Create(int size)
        {
            mBmp  = new Bitmap(size, size);
            mSize = size;
        }

        public Bitmap Get { get { return mBmp; } }

        public void Visualise(double[,] pher)
        {
            int col;
            double max = FindMax(pher);

            for (int x = 0; x < mSize; ++x)
            {
                for (int y = 0; y < mSize; ++y)
                {
                    col = Clamp(pher[x,y] / max * 255.0);
                    mBmp.SetPixel(x, y, mPalette[col]);
                }
            }
        }

        static private int Clamp(double v)
        {
            if (v < 0.0) return 0;
            if (v > 255.0) return 255;
            else return (int)v;
        }

        private double FindMax(double[,] pher)
        {
            double max = double.MinValue;
            double tmp;

            for (int x = 0; x < mSize; ++x)
            {
                for (int y = 0; y < mSize; ++y)
                {
                    tmp = pher[x,y];
                    if (tmp > max)
                        max = tmp;
                }
            }
            return max;
        }
    }
}
