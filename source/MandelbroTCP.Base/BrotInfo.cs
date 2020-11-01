using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;

namespace MandelbroTCP.Base
{
    public struct BrotInfo
    {
        public BigInteger PosX, PosY, Zoom, SizeX, SizeY;

        public BrotInfo(string serializedBroInfo)
        {
            Deserialize(serializedBroInfo);
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PosX.ToString()).Append("|").Append(PosY.ToString()).Append("|").Append(Zoom.ToString()).Append("|").Append(SizeX.ToString()).Append("|").Append(SizeY.ToString());
            return sb.ToString();
        }

        private void Deserialize(string serializedBroInfo)
        {
            BigInteger[] vals = serializedBroInfo.Split('|').Select(x => BigInteger.Parse(x)).ToArray();
            PosX = vals[0];
            PosY = vals[1];
            Zoom = vals[2];
            SizeX = vals[3];
            SizeY = vals[4];
        }
    }
}
