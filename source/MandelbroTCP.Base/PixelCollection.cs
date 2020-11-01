using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
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
