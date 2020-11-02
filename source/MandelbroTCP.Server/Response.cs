using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using MandelbroTCP.Base;
using System.Net.Http.Headers;

namespace MandelbroTCP.Server.Calc
{
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

            return brot;
        }
    }
}
