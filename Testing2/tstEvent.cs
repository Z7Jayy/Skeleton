using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing2
{
    [TestClass]
    public class tstEvent
    {
        [TestMethod]
        public void InstanceOK()
        {
            //creates an instance of the class we want to create
            clsEvent AnEvent = new clsEvent();
            //Test to see that it exists
            Assert.IsNotNull(AnEvent);
        }
    }
}
