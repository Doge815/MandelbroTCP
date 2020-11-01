using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

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
            throw new NotImplementedException();
        }

        private void Deserialize(string serializedBroInfo)
        {
            throw new NotImplementedException();
        }
    }
}
