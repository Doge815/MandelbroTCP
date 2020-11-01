using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

namespace MandelbroTCP.Base
{

    public class Color
    {
        //Todo: custom color depth
        public uint Red, Green, Blue;


        public override bool Equals(object obj)
        {
            return obj is Color color &&
                   Red == color.Red &&
                   Green == color.Green &&
                   Blue == color.Blue;
        }

        public string Serialize()
        {
            return (Red.ToString() + '|' + Green.ToString() + '|' + Blue.ToString());
        }

        private void Deserialize(string serializedColor)
        {
            uint[] vals = serializedColor.Split('|').Select(x => UInt32.Parse(x)).ToArray();
            Red = vals[0];
            Green = vals[1];
            Blue = vals[2];
        }


        public Color(string serializedColor)
        {
            Deserialize(serializedColor);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Red, Green, Blue);
        }
    }

    public class PixelCollection
    {
        private Color[,] Pixels;


        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Pixels.GetLength(0).ToString()).Append('|').Append(Pixels.GetLength(1).ToString()).Append('\n');
            foreach(Color c in Pixels)
            {
                sb.Append(c.Serialize() + "#");
            }
            return sb.ToString();
        }

        private void Deserialize(string serializedPixelCollection)
        {
            throw new NotImplementedException();
        }

        public PixelCollection(string serializedPixelCollection)
        {
            Deserialize(serializedPixelCollection);
        }

        public PixelCollection(int x, int y)
        {
            Pixels = new Color[x, y];
        }

        public Color this[int x, int y]
        {
            get => Pixels[x, y];
            set => Pixels[x, y] = value;
        }

        public Color[,] GetColors() => Pixels;

        public override bool Equals(object obj)
        {
            return obj is PixelCollection collection &&
                   EqualityComparer<Color[,]>.Default.Equals(Pixels, collection.Pixels);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Pixels);
        }
    }
}
