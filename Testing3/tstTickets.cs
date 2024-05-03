using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing3
{
    [TestClass]
    public class tstTickets
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsTickets AnTickets = new clsTickets();
            //test to see that it exists
            Assert.IsNotNull( AnTickets );
        }
    }
}
