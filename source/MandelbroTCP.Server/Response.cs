using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using MandelbroTCP.Base;

namespace MandelbroTCP.Server.Calc
{
    public struct BrotInfo
    {
        BigInteger PosX, PosY, Zoom, SizeX, SizeY;

        public static BrotInfo Parse(string args)
        {
            throw new NotImplementedException();
        }
    }
    public static class Brot
    {
        public static PixelCollection GetBrot(BrotInfo Info)
        {
            throw new NotImplementedException();
        }
    }
}
