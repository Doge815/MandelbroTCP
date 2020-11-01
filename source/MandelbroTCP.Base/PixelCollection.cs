using System;

namespace MandelbroTCP.Base
{

    public struct Color
    {
        //Todo: custom color depth
        uint Red, Green, Blue;
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
    }
}
