using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp1;



namespace Unit_Imaginery_Number
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodImSummIm()
        {
            Imaginary_Number z = new Imaginary_Number();
            Imaginary_Number w = new Imaginary_Number();
            z.a = 5;
            z.b = 8;
            w.a = 3;
            w.b = 10;
            Imaginary_Number res = z.Summ(z, w);
            Assert.AreEqual(res.a, 8);
            Assert.AreEqual(res.b, 18);
        }
        [TestMethod]
        public void TestMethodImSubIm()
        {
            Imaginary_Number z = new Imaginary_Number();
            Imaginary_Number w = new Imaginary_Number();
            z.a = 2;
            z.b = 0;
            w.a = 6;
            w.b = 18;
            Imaginary_Number res = z.Sub(z, w);
            Assert.AreEqual(res.a, -4);
            Assert.AreEqual(res.b, -18);
        }
        [TestMethod]
        public void TestMethodImMulIm()
        {
            Imaginary_Number z = new Imaginary_Number();
            Imaginary_Number w = new Imaginary_Number();
            z.a = 15;
            z.b = 9;
            w.a = 3;
            w.b = 5;
            Imaginary_Number res = z.Mul(z, w);
            Assert.AreEqual(res.a, 0);
            Assert.AreEqual(res.b, 102);
        }
        [TestMethod]
        public void TestMethodImDivIm()
        {
            Imaginary_Number z = new Imaginary_Number();
            Imaginary_Number w = new Imaginary_Number();
            z.a = 1;
            z.b = 3;
            w.a = 2;
            w.b = 5;
            Imaginary_Number res = z.Div(z, w);
            Assert.AreEqual(Math.Round(res.a, 2), Math.Round(0.382352941176471, 2));
            Assert.AreEqual(Math.Round(res.b,2), Math.Round(0.0294117647058, 2));
        }
        [TestMethod]
        public void TestMethodImSummCel()
        {
            Imaginary_Number z = new Imaginary_Number();
            z.a = 5;
            z.b = 8;
            Imaginary_Number res = z.SummCel(z, 3);
            Assert.AreEqual(res.a, 8);
            Assert.AreEqual(res.b, 18);
        }
        [TestMethod]
        public void TestMethodImSubCel()
        {
            Imaginary_Number z = new Imaginary_Number();
            Imaginary_Number w = new Imaginary_Number();
            z.a = 2;
            z.b = 0;
            w.a = 6;
            w.b = 18;
            Imaginary_Number res = z.Sub(z, w);
            Assert.AreEqual(res.a, -4);
            Assert.AreEqual(res.b, -18);
        }
        [TestMethod]
        public void TestMethodImMulCel()
        {
            Imaginary_Number z = new Imaginary_Number();
            Imaginary_Number w = new Imaginary_Number();
            z.a = 15;
            z.b = 9;
            w.a = 3;
            w.b = 5;
            Imaginary_Number res = z.Mul(z, w);
            Assert.AreEqual(res.a, 0);
            Assert.AreEqual(res.b, 102);
        }
        [TestMethod]
        public void TestMethodImDivCel()
        {
            Imaginary_Number z = new Imaginary_Number();
            Imaginary_Number w = new Imaginary_Number();
            z.a = 1;
            z.b = 3;
            w.a = 2;
            Imaginary_Number res = z.Div(z, w);
            Assert.AreEqual(Math.Round(res.a, 2), Math.Round(, 2));
            Assert.AreEqual(Math.Round(res.b, 2), Math.Round(, 2));
        }
    }
}
