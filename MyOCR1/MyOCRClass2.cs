﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyOCR1
{
    class MyOCRClass2
    {
        int[] characterOverlap = new int[35];

        Matrix[] etalonDB = new Matrix[35]; 

        public class Matrix      
        {

            public int[,] matrix = new int[30, 40];

            public double percent;
            
        }


        public Matrix createMatrix(Bitmap bmp)
        {

            Matrix temp = new Matrix();
          
            for (int x =0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {

                    Color etalonPixel = bmp.GetPixel(x, y);
                    if (etalonPixel.G==255)
                    {
                        temp.matrix[x, y] = 0;
                    }
                    if (etalonPixel.G == 0)
                    {
                        temp.matrix[x, y] = 1;
                    }


                }
            }
            return temp;
        }

        public void fillEtalonBase()
        {

            for (int i = 0; i < etalonDB.Length; i++)
            {
                String filepath = "C://Documents and Settings//ika//My Documents//Visual Studio 2010//Projects//myALPR1//myALPR1//bin//Release//Characters//" + i.ToString() + ".bmp";
                Bitmap bitmapfromBase = new Bitmap(filepath);

                etalonDB[i] = createMatrix(bitmapfromBase);

              
            }
        }


        public void compareMatrix(Matrix m)
        {

            for (int i = 0; i < etalonDB.Length; i++)
            {
                int overlap = 0;
                for (int x = 0; x < 30; x++)
                {
                    for (int y = 0; y < 40; y++)
                    {
                     int lol1 = etalonDB[i].matrix[x, y];
                     int lol2 = m.matrix[x, y];

                     int Xor = lol1 * lol2;
                     if (Xor == 1)
                     {
                         overlap++;
                     }

                    }
                }

                characterOverlap[i] = overlap;
            }

        }


        //private int compareBitmaps(Bitmap etalon, Bitmap character)
        //{
        //    int Overlap = 0;
        //    if (etalon.Width == character.Width && etalon.Height == character.Height)
        //    {

        //        unsafeBitmapClass fastPictureEtalon = new unsafeBitmapClass(etalon);
        //        unsafeBitmapClass fastPictureChar = new unsafeBitmapClass(character);

        //        fastPictureChar.LockBitmap();
        //        fastPictureEtalon.LockBitmap();


        //        for (int x = 0; x < etalon.Width; x++)
        //        {
        //            for (int y = 0; y < etalon.Height; y++)
        //            {
        //                PixelData etalonPixel = fastPictureEtalon.GetPixel(x, y);
        //                PixelData charPixel = fastPictureChar.GetPixel(x, y);

        //                if (etalonPixel.blue == 255 &&
        //                    charPixel.blue == 255 &&
        //                    etalonPixel.green == 255 &&
        //                    charPixel.green == 255 &&
        //                    etalonPixel.red == 255 &&
        //                    charPixel.red == 255)
        //                {
        //                    Overlap++;
        //                }
        //                else 
        //                {
        //                    //Overlap--;
        //                }
        //            }
        //        }

        //        fastPictureChar.UnlockBitmap();
        //        fastPictureEtalon.UnlockBitmap();


        //    }
        //    else
        //    {
        //        MessageBox.Show("Bitmap sizes are not equal!");
        //    }


        //    return Overlap;
        //}


        //public void compareWithBase(Bitmap character)
        //{
        //    for (int i = 0; i < characterOverlap.Length; i++)
        //    {
        //        String filepath = "C://Documents and Settings//ika//My Documents//Visual Studio 2010//Projects//myALPR1//myALPR1//bin//Release//Characters//" + i.ToString() + ".jpg";
        //        Bitmap bitmapfromBase = new Bitmap(filepath);

        //        characterOverlap[i] =  compareBitmaps(bitmapfromBase, character);
        //    }
        //}


        private int getIndexOfMax(int[] arr)
        {
            int indexOf = 0;
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max <= arr[i])
                {
                    max = arr[i];
                    indexOf = i;
                }
            }
            return indexOf;
        }

        public String getLetter()
        
        {
            int max = getIndexOfMax(characterOverlap);
            switch (max)
            {
                #region Numbers
                case 0:
                    return "0";
                    
                case 1:
                    return "1";
                    
                case 2:
                    return "2";
                    
                case 3:
                    return "3";
                    
                case 4:
                    return "4";
                    
                case 5:
                    return "5";
                    
                case 6:
                    return "6";
                    
                case 7:
                    return "7";
                    
                case 8:
                    return "8";
                    
                case 9:
                    return "9";
                #endregion

                #region chars
                case 10:
                    return "A";
                case 11:
                    return "B";
                case 12:
                    return "C";
                case 13:
                    return "D";
                case 14:
                    return "E";
                case 15:
                    return "F";
                case 16:
                    return "G";
                case 17:
                    return "H";
                case 18:
                    return "I";
                case 19:
                    return "J";
                case 20:     
                    return "K";
                case 21:
                    return "L";
                case 22:
                    return "M";
                case 23:
                    return "N";
                case 24:
                    return "O";
                case 25:
                    return "P";
                case 26:
                    return "Q";
                case 27:
                    return "R";
                case 28:
                    return "S";
                case 29:
                    return "T";
                case 30:
                    return "U";
                case 31:
                    return "V";
                case 32:
                    return "W";
                case 33:
                    return "X";
                case 34:
                    return "Y";
                case 35:
                    return "Z";
                #endregion

            }
            return "None";
        }

                                                
    }
}
