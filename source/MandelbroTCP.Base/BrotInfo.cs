using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Linq;

namespace MandelbroTCP.Base
{
    public class BrotInfo
    {
        public Fraction PosX, PosY, Zoom, SizeX, SizeY;

        public BrotInfo()
        {
            PosX = new Fraction();
            PosY = new Fraction();
            Zoom = new Fraction();
            SizeX = new Fraction();
            SizeY = new Fraction();
        }
        public BrotInfo(string serializedBroInfo)
        {
            Deserialize(serializedBroInfo);
        }

        public override bool Equals(object obj)
        {
            return obj is BrotInfo info &&
                PosX.Equals(info.PosX) &&
                PosY.Equals(info.PosY) &&
                Zoom.Equals(info.Zoom) &&
                SizeX.Equals(info.SizeX) &&
                SizeY.Equals(info.SizeY);
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PosX.ToString()).Append("|").Append(PosY.ToString()).Append("|").Append(Zoom.ToString()).Append("|").Append(SizeX.ToString()).Append("|").Append(SizeY.ToString());
            return sb.ToString();
        }

        private void Deserialize(string serializedBroInfo)
        {
            Fraction[] vals = serializedBroInfo.Split('|').Select(x => Fraction.Parse(x)).ToArray();
            PosX = vals[0];
            PosY = vals[1];
            Zoom = vals[2];
            SizeX = vals[3];
            SizeY = vals[4];
        }
    }
}
