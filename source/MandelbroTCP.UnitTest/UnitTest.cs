using Microsoft.VisualStudio.TestTools.UnitTesting;
using MandelbroTCP.Base;
using MandelbroTCP.Base.Extensions;
using System;
using System.Runtime.CompilerServices;

namespace MandelbroTCP.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        Random random = new Random();


        [TestMethod]
        public void TestPixelCollectionSerialization()
        {
            PixelCollection collection = new PixelCollection(random.Next(1, 3841), random.Next(1, 2161));
            for (int i = 0; i < collection.GetColors().GetLength(0); i++)
                for (int j = 0; j < collection.GetColors().GetLength(1); j++)
                {
                    collection[i, j] = new Color();
                    collection[i, j].Red = random.NextUint();
                    collection[i, j].Green = random.NextUint();
                    collection[i, j].Blue = random.NextUint();
                }
                    

            string serializedCollection = collection.Serialize();
            PixelCollection deserializedSerializedCollection = new PixelCollection(serializedCollection);

            Assert.AreEqual(collection, deserializedSerializedCollection);
        }

        [TestMethod]
        public void TestBrotInfoSerilization()
        {
            BrotInfo info = new BrotInfo();

            const int size = 5;

            info.PosX = random.NextBigInteger(size);
            info.PosY = random.NextBigInteger(size);
            info.SizeX = random.NextBigInteger(size);
            info.SizeY = random.NextBigInteger(size);
            info.Zoom = random.NextBigInteger(size);

            string serializedInfo = info.Serialize();
            BrotInfo deserializedSerializedInfo = new BrotInfo(serializedInfo);

            Assert.AreEqual(info, deserializedSerializedInfo);
        }
    }
}
