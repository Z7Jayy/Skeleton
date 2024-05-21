using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Testing3
{
    [TestClass]
    public class tstTicket
    {
        public bool OK { get; private set; }

        //good test data 
        //create some test data to pass the method
        string Venue = "Some Venue ";
        string Artist = "Some Artist ";
        string TicketType = "VIP ";
        string Date = DateTime.Now.ToShortDateString();

        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //test to see that it exists
            Assert.IsNotNull(AnTicket);
        }

        [TestMethod]
        public void TicketIdPropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            int TestData = 1;
            // Assign the data to the property
            AnTicket.TicketId = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.TicketId, TestData);
        }

        [TestMethod]
        public void DatePropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            DateTime TestData = DateTime.Now.Date;
            // Assign the data to the property
            AnTicket.Date = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.Date, TestData);
        }

        [TestMethod]
        public void PricePropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            int TestData = 1;
            // Assign the data to the property
            AnTicket.Price = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.Price, TestData);
        }

        [TestMethod]
        public void VenuePropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            string TestData = "Some Venue";
            // Assign the data to the property
            AnTicket.Venue = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.Venue, TestData);
        }

        [TestMethod]
        public void ArtistPropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            string TestData = "Some Artist";
            // Assign the data to the property
            AnTicket.Artist = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.Artist, TestData);
        }

        [TestMethod]
        public void IsSoldPropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            Boolean TestData = true;
            // Assign the data to the property
            AnTicket.IsSold = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.IsSold, TestData);
        }

        [TestMethod]
        public void TicketTypePropertyOK()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // Create some test data to assign to the property
            string TestData = "VIP";
            // Assign the data to the property
            AnTicket.TicketType = TestData;
            // Test to see that the two values are the same
            Assert.AreEqual(AnTicket.TicketType, TestData);
        }

        [TestMethod]
        public void FindMethodOK()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the results of the validation
            Boolean Found = false;
            //create some test data to use with the method
            Int32 TicketId = 2;
            //invoke the method
            Found = AnTicket.Find(TicketId);
            //test to see if the result is true
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestTicketIdFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketId = 6;
            //invoke the method
            Found = AnTicket.Find(TicketId);
            //check the TicketId
            if (AnTicket.TicketId != 6)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestDateFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketId = 6;
            //invoke the method
            Found = AnTicket.Find(TicketId);
            //check the Date
            if (AnTicket.Date != Convert.ToDateTime("01/04/2024"))
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestPriceFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketId = 6;
            //invoke the method
            Found = AnTicket.Find(TicketId);
            //check the price property
            if (AnTicket.Price != 20)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);


        }

        [TestMethod]
        public void TestVenueFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketId = 6;
            //invoke the method
            Found = AnTicket.Find(TicketId);
            //check the venue property
            if (AnTicket.Venue != "The 02")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestArtistFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketId = 6;
            //invoke the method
            Found = AnTicket.Find(TicketId);
            //check the Artist
            if (AnTicket.Artist != "travis scott")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestIsSoldFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketId = 6;
            //invoke the method
            Found = AnTicket.Find(TicketId);
            //check the IsSold property
            if (AnTicket.IsSold != true)
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);

        }
        [TestMethod]
        public void TestTicketTypeFound()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //create a Boolean variable to store the result of the search
            Boolean Found = false;
            //create a Boolean variable to record if the data is OK (assume it is)
            Boolean OK = true;
            //create some test data to use with the method
            Int32 TicketId = 6;
            //invoke the method
            Found = AnTicket.Find(TicketId);
            //check the Artist
            if (AnTicket.TicketType != "VIP")
            {
                OK = false;
            }
            //test to see that the result is correct
            Assert.IsTrue(OK);


        }

        /*** Valid Method ***/

        [TestMethod]
        public void ValidMethodOK()
        {
            //create an instance of the class we want to create 
            clsTicket AnTicket = new clsTicket();
            //string variable to store any error message 
            String Error = "";
            //invoke the method 
            Error = AnTicket.Valid(Venue,Artist,TicketType,Date);
            //test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        /**************** Parameter Tests ****************/

        /**************** Parameter Tests for artist ****************/

        [TestMethod]
        public void ArtistMinLessOne()
        {
            //create an instance of the class we want to create 
            clsTicket AnTicket = new clsTicket();
            //string c=variable to store any error message 
            String Error = "";
            //create some test data to pass to the method 
            string Artist = "";  //this should trigger an error 
            //invoke the method 
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void ArtistMin()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create some test data to pass to the method
            string Artist = "a"; // This should be OK
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ArtistMinPlusOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create some test data to pass to the method
            string Artist = "aa"; // This should be OK
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ArtistMaxLessOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create some test data to pass to the method
            string Artist = "";
            Artist = Artist.PadRight(59, 'a');
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ArtistMax()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create some test data to pass to the method
            string Artist = "";
            Artist = Artist.PadRight(60, 'a');
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ArtistMid()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create some test data to pass to the method
            string Artist = "";
            Artist = Artist.PadRight(30, 'a');
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void ArtistMaxPlusOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create some test data to pass to the method
            string Artist = "";
            Artist = Artist.PadRight(61, 'a');
            // This should trigger an error
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void ArtistExtremeMax() 
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create some test data to pass to the method
            string Artist = "";
            Artist = Artist.PadRight(500, 'a'); //this should fail 
            //invoke the method 
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        /**************** Parameter Tests for date ****************/

        [TestMethod]
        public void DateExtremeMin()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create a variable to store the test date data
            DateTime TestDate;
            // Set the date to today's date
            TestDate = DateTime.Now.Date;
            // Change the date to whatever the date is less 100 years
            TestDate = TestDate.AddYears(-100);
            // Convert the date variable to a string variable
            string Date = TestDate.ToString();
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateMinLessOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create a variable to store the test date data
            DateTime TestDate;
            // Set the date to today's date
            TestDate = DateTime.Now.Date;
            // Change the date to whatever the date is less 1 day
            TestDate = TestDate.AddDays(-1);
            // Convert the date variable to a string variable
            string Date = TestDate.ToString();
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateMin()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create a variable to store the test date data
            DateTime TestDate;
            // Set the date to today's date
            TestDate = DateTime.Now.Date;
            // Convert the date variable to a string variable
            string Date = TestDate.ToString();
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void DateMinPlusOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create a variable to store the test date data
            DateTime TestDate;
            // Set the date to today's date
            TestDate = DateTime.Now.Date;
            // Change the date to whatever the date is plus 1 day
            TestDate = TestDate.AddDays(1);
            // Convert the date variable to a string variable
            string Date = TestDate.ToString();
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateExtremeMax()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // Create a variable to store the test date data
            DateTime TestDate;
            // Set the date to today's date
            TestDate = DateTime.Now.Date;
            // Change the date to whatever the date is plus 100 years
            TestDate = TestDate.AddYears(100);
            // Convert the date variable to a string variable
            string Date = TestDate.ToString();
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void DateInvalidData()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            //set the date to a non date value 
            string Date = "this is not a date !";
            //invoke the method 
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");

        }

        /*************** Tests for Venue ***************/

        [TestMethod]
        public void VenueMinLessOne()
        {
            //create an instance of the class we want to create
            clsTicket AnTicket = new clsTicket();
            //string variable to store any error message
            String Error = "";
            //this should fail
            string Venue = "";
            //invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            //test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueMin()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            //this should pass
            string Venue = "a"; 
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueMinPlusOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            //this should pass
            string Venue = "aa"; 
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueMaxLessOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            //this should pass
            string Venue = "";
            Venue = Venue.PadRight(99, 'a'); 
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueMax()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            //this should pass
            string Venue = "";
            Venue = Venue.PadRight(100, 'a');
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueMaxPlusOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            //this should pass
            string Venue = "";
            Venue = Venue.PadRight(101, 'a');            
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }



        [TestMethod]
        public void VenueMid()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            //this should pass
            string Venue = "aaaa"; 
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }


        /*************** Tests for Ticket Type ***************/

        [TestMethod]
        public void TicketTypeMinLessOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // This should fail
            string TicketType = "";
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TicketTypeMin()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // This should pass
            string TicketType = "a";
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TicketTypeMinPlusOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // This should pass
            string TicketType = "aa";
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TicketTypeMaxLessOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // This should pass
            string TicketType = "aaaaaa";
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TicketTypeMax()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // This should pass
            string TicketType = "aaaaaaa";
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void TicketTypeMaxPlusOne()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // This should fail
            string TicketType = "aaaaaaaa";
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void TicketTypeMid()
        {
            // Create an instance of the class we want to test
            clsTicket AnTicket = new clsTicket();
            // String variable to store any error message
            String Error = "";
            // This should pass
            string TicketType = "aaa";
            // Invoke the method
            Error = AnTicket.Valid(Venue, Artist, TicketType, Date);
            // Test to see that the result is correct
            Assert.AreEqual(Error, "");
        }
    }
}












      