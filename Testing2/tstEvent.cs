using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace Testing2
{
    [TestClass]
    public class tstEvent
    {
        private static string connectionString;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            // Load the connection string from configuration
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not loaded.");
            }

            // Setting up the connection string for the data connection class
            clsDataConnection.SetConnectionString(connectionString);
        }

        // Good test data
        string eventName = "Music Concert";
        string eventDescription = "An amazing music concert";
        string eventDate = DateTime.Now.ToShortDateString(); // Assuming this is in the format of "MM/dd/yyyy"
        string venueId = "101"; // Assuming VenueId is an integer
        string category = "Music";

        [TestMethod]
        public void InstanceOK()
        {
            clsEvent AnEvent = new clsEvent();
            Assert.IsNotNull(AnEvent);
        }

        [TestMethod]
        public void ActiveEvent()
        {
            clsEvent AnEvent = new clsEvent();
            Boolean TestData = true;
            AnEvent.Active = TestData;
            Assert.AreEqual(TestData, AnEvent.Active);
        }

        [TestMethod]
        public void DateAddedEventOK()
        {
            clsEvent AnEvent = new clsEvent();
            DateTime TestData = DateTime.Now.Date;
            AnEvent.DateAdded = TestData;
            Assert.AreEqual(TestData, AnEvent.DateAdded);
        }

        [TestMethod]
        public void TestEventIDProperty()
        {
            clsEvent AnEvent = new clsEvent();
            int TestData = 1;
            AnEvent.EventId = TestData;
            Assert.AreEqual(TestData, AnEvent.EventId);
        }

        [TestMethod]
        public void TestEventNameProperty()
        {
            clsEvent AnEvent = new clsEvent();
            string TestData = "Music Concert";
            AnEvent.EventName = TestData;
            Assert.AreEqual(TestData, AnEvent.EventName);
        }

        [TestMethod]
        public void TestEventDescriptionProperty()
        {
            clsEvent AnEvent = new clsEvent();
            string TestData = "A live music concert featuring various artists.";
            AnEvent.EventDescription = TestData;
            Assert.AreEqual(TestData, AnEvent.EventDescription);
        }

        [TestMethod]
        public void TestEventDateProperty()
        {
            clsEvent AnEvent = new clsEvent();
            DateTime TestData = DateTime.Now;
            AnEvent.EventDate = TestData;
            Assert.AreEqual(TestData, AnEvent.EventDate);
        }

        [TestMethod]
        public void TestIsOnlineProperty()
        {
            clsEvent AnEvent = new clsEvent();
            bool TestData = true;
            AnEvent.IsOnline = TestData;
            Assert.AreEqual(TestData, AnEvent.IsOnline);
        }

        [TestMethod]
        public void TestVenueIDProperty()
        {
            clsEvent AnEvent = new clsEvent();
            int TestData = 123;
            AnEvent.VenueId = TestData;
            Assert.AreEqual(TestData, AnEvent.VenueId);
        }

        [TestMethod]
        public void TestCategoryProperty()
        {
            clsEvent AnEvent = new clsEvent();
            string TestData = "Concert";
            AnEvent.Category = TestData;
            Assert.AreEqual(TestData, AnEvent.Category);
        }

        [TestMethod]
        public void FindMethodOK()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = false;
            int EventID = 1;
            Found = AnEvent.Find(EventID);
            Assert.IsTrue(Found);
        }

        [TestMethod]
        public void TestEventIDFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = false;
            bool OK = true;
            int EventID = 1;
            Found = AnEvent.Find(EventID);
            if (AnEvent.EventId != 1)
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestEventNameFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            bool OK = AnEvent.EventName == "Music Concert";
            Assert.IsTrue(Found);
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestEventDescriptionFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            bool OK = AnEvent.EventDescription == "A live music concert featuring various artists.";
            Assert.IsTrue(Found);
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestEventDateFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            bool OK = AnEvent.EventDate == Convert.ToDateTime("2024-01-01");
            Assert.IsTrue(Found);
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestVenueIDFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            bool OK = AnEvent.VenueId == 123;
            Assert.IsTrue(Found);
            Assert.IsTrue(OK);
        }

        [TestMethod]
        public void TestCategoryFound()
        {
            clsEvent AnEvent = new clsEvent();
            bool Found = AnEvent.Find(1);
            bool OK = AnEvent.Category == "Concert";
            Assert.IsTrue(Found);
            Assert.IsTrue(OK);
        }


        // Validation Method Tests 
        [TestMethod]
        public void ValidMethodOK()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        // Parameter Tests
        [TestMethod]
        public void EventNameMinLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "";  // This should trigger an error 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMin()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "a"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMinPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "aa"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMaxLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "".PadRight(49, 'a');
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "".PadRight(50, 'a');
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMid()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "Event Name"; // Mid length
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventNameMaxPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "".PadRight(51, 'a');
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventNameExtremeMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "".PadRight(500, 'a'); // This should fail
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventNameInvalidData()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventName = "12345";  // Invalid data type
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMinLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "";  // This should trigger an error 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMin()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "a"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMinPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "aa"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMid()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "".PadRight(100, 'a'); // Mid length
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMaxLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "".PadRight(199, 'a'); // One less than the maximum allowed length (200)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "".PadRight(200, 'a'); // Maximum allowed length (200)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionMaxPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "".PadRight(201, 'a'); // One more than the maximum allowed length (200)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionExtremeMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "".PadRight(500, 'a'); // This should fail
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDescriptionInvalidData()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDescription = "12345";  // Invalid data type
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMinLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddDays(-1).ToShortDateString(); // This should trigger an error (yesterday)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMin()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.ToShortDateString(); // This should be OK (today)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMinPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddDays(1).ToShortDateString(); // This should be OK (tomorrow)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMaxLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddYears(1).AddDays(-1).ToShortDateString(); // This should be OK (one day less than a year from now)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddYears(1).ToShortDateString(); // This should be OK (one year from now)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EventDateMaxPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = DateTime.Now.AddYears(1).AddDays(1).ToShortDateString(); // This should trigger an error (one day more than a year from now)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateExtremeMin()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            DateTime TestDate = DateTime.Now.AddYears(-100); // 100 years in the past
            string eventDate = TestDate.ToShortDateString();
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateExtremeMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            DateTime TestDate = DateTime.Now.AddYears(100); // 100 years in the future
            string eventDate = TestDate.ToShortDateString();
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void EventDateInvalidData()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string eventDate = "not a date"; // Invalid date string
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMinLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = ""; // This should trigger an error (invalid venue ID)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMin()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "1"; // This should be OK (minimum valid venue ID)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMinPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "12"; // This should be OK (one more than the minimum valid venue ID)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMaxLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "9999999"; // One less than the maximum valid venue ID for an integer
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "99999999"; // Maximum valid venue ID for an integer
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdMaxPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "100000000"; // One more than the maximum valid venue ID for an integer
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdExtremeMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "1000000000"; // This should fail
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void VenueIdInvalidData()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string venueId = "one hundred";  // Invalid data type
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMinLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "";  // This should trigger an error 
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMin()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "a"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMinPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "aa"; // This should be OK
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMid()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "aaaa"; // Mid length
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMaxLessOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = new string('a', 29); // One less than the maximum allowed length (30)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = new string('a', 30); // Maximum allowed length (30)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CategoryMaxPlusOne()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = new string('a', 31); // One more than the maximum allowed length (30)
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryExtremeMax()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = new string('a', 500); // This should fail
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void CategoryInvalidData()
        {
            clsEvent AnEvent = new clsEvent();
            string Error = "";
            string category = "12345";  // Invalid data type
            Error = AnEvent.Valid(eventName, eventDescription, eventDate, venueId, category);
            Assert.AreNotEqual(Error, "");
        }
    }
}
