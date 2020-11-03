using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using MandelbroTCP.Base;
using System.Net.Http.Headers;

namespace MandelbroTCP.Server.Calc
{
    public struct ComplexNumber
    {
        public Fraction Real, Imaginary;

        public ComplexNumber(Fraction real, Fraction imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
    }
    public static class Brot
    {
        public static PixelCollection GetBrot(BrotInfo Info)
        {
            Fraction zoomLenghth = 2 / Info.Zoom;

            Fraction startX = Info.PosX - (zoomLenghth / 2);
            Fraction endX = Info.PosX + (zoomLenghth / 2);
            
            Fraction startY = Info.PosY - (zoomLenghth / 2);
            Fraction endY = Info.PosY + (zoomLenghth / 2);

            if (Info.SizeX > Info.SizeY)
            {
                startX -= ((Info.SizeX / Info.SizeY) - 1) * (zoomLenghth / 2);
                endX += ((Info.SizeX / Info.SizeY) - 1) * (zoomLenghth / 2);
            }
            else if(Info.SizeY > Info.SizeX)
            {
                startY -= ((Info.SizeY / Info.SizeX) - 1) * (zoomLenghth / 2);
                endY -= ((Info.SizeY / Info.SizeX) - 1) * (zoomLenghth / 2);
            }

            Fraction stepX = (endX - startX) / Info.SizeX;
            Fraction stepY = (endY - startY) / Info.SizeX;

            PixelCollection brot = new PixelCollection(Info.SizeX, Info.SizeY);


            for(int i = 0; i < Info.SizeX; i++)
            {
                for (int j = 0; j < Info.SizeY; j++)
                {
                    Fraction x = startX + stepX * i;
                    Fraction y = startY + stepY * j;

                    ComplexNumber c = new ComplexNumber(x, y);
                    ComplexNumber z = c;
                    uint iterations = 0;

                    for (; iterations < Info.Precision; iterations++)
                    {
                        ComplexNumber z2 = new ComplexNumber(z.Real * z.Real - z.Imaginary * z.Imaginary, 2 * z.Real * z.Imaginary);

                        //Todo: overload + operator
                        z2.Real += c.Real;
                        z2.Imaginary += c.Imaginary;
                        z = z2;

                        if (z.Real * z.Real + z.Imaginary * z.Imaginary > 4)
                            break;
                    }

                    if (iterations == Info.Precision - 1)
                    {
                        brot.GetColors()[i, j] = new Color()
                        {
                            Red = 0,
                            Green = 0,
                            Blue = 0
                        };
                    }
                    else
                    {
                        brot.GetColors()[i, j] = new Color()
                        {
                            Red = 255,
                            Green = 255,
                            Blue = 255
                        };
                    }
                }
            }

            return brot;
        }
    }
}
