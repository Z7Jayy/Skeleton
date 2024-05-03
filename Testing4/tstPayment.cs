using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing4
{
    [TestClass]
    public class tstPayment
    {
        [TestMethod]
        public void TestMethod1()
        {
            //create an instance of the class we want to create
            clsPayment AnPayment = new clsPayment();
            //test to see that it exixts
            Assert.IsNotNull(AnPayment);
        }
    }
}
