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

        public Color()
        {

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
                sb.Append(c.Serialize() + '#');
            }
            return sb.ToString();
        }

        private void Deserialize(string serializedPixelCollection)
        {
            string[] parts = serializedPixelCollection.Split('\n');
            uint[] size = parts[0].Split('|').Select(x => UInt32.Parse(x)).ToArray();
            Pixels = new Color[size[0], size[1]];

            string[] colors = parts[1].Split('#');

            int x = 0, y = 0;

            foreach(string s in colors)
            {
                Pixels[x, y] = new Color(s);
                y++;
                if(y == Pixels.GetLength(1))
                {
                    y = 0;
                    x++;
                }
            }
        }

        public PixelCollection(string serializedPixelCollection)
        {
            Deserialize(serializedPixelCollection);
        }

        public PixelCollection(int x, int y)
        {
            Pixels = new Color[x, y];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    Pixels[i, j] = new Color();
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
