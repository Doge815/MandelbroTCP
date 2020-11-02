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
                for(int j = 0; j < Info.SizeY; j++)
                {
                    Fraction x = startX + stepX * i;
                    Fraction y = startY + stepY * j;

                    ComplexNumber cn = new ComplexNumber(x, y);
                    ComplexNumber z = cn;
                    uint iterations = 0;

                    for(int k = 0; k < Info.Precision; k++)
                    {
                        ComplexNumber z2 = new ComplexNumber(z.Real * z.Real - z.Imaginary * z.Imaginary, 2 * z.Real * z.Imaginary);
                        z2.Real += cn.Real;

                        z2.Imaginary += cn.Imaginary;
                        z = z2;
                        iterations++;
                        if (z.Real * z.Real + z.Imaginary * z.Imaginary > 4)
                            break;
                    }
                }
            }

            return brot;
        }
    }
}
