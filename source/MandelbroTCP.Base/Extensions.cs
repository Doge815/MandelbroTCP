using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace MandelbroTCP.Base.Extensions
{
    public static class Extensions
    {
        public static UInt32 NextUint(this Random rand)
        {
            if (rand is null)
                throw new ArgumentNullException(nameof(rand));
            byte[] buffer = new byte[4];
            rand.NextBytes(buffer);
            return BitConverter.ToUInt32(buffer, 0);
        }

        public static BigInteger NextBigInteger(this Random rand, int length)
        {
            byte[] data = new byte[length];
            rand.NextBytes(data);
            return new BigInteger(data);
        }

        public static Fraction NextFraction(this Random rand, int length)
        {
            BigInteger num = rand.NextBigInteger(length);
            BigInteger denum = rand.NextBigInteger(length);
            return new Fraction(num, denum);
        }

        public static bool IsEqual<T> (this T[,] obj, T[,] sec)
        {
            if (obj.GetLength(0) != sec.GetLength(0) || obj.GetLength(1) != sec.GetLength(1)) return false;
            int x = 0, y = 0;
            for(int i = 0; i < obj.Length; i++)
            {
                if (!obj[x, y].Equals(sec[x, y])) return false;
                y++;
                if(y == obj.GetLength(1))
                {   
                    y = 0;
                    x++;
                }
            }
            return true;
        }
    }
}
