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
            foreach(Color c in collection.GetColors())
            {
                c.Red = random.NextUint();
                c.Green = random.NextUint();
                c.Blue = random.NextUint();
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
