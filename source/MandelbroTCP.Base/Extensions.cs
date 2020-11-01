using System;
using System.Collections.Generic;
using System.Numerics;
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
    }
}
