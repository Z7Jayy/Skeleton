using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Data;
using static System.Collections.Specialized.BitVector32;

namespace Testing5
{
    [TestClass]
    public class tstSeatSelection
    {
        public bool OK { get; private set; }

        string seatType = "aaa";
        string seatID = "2";


        string numberedSeats = "1";
        string section = "Window Seat";
        string bookingDate = "07-07-2024";




        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            //test to see that it exists
            Assert.IsNotNull(AnSeatSelection);
        }

        [TestMethod]
        public void AvailabilityPropertyTest()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            bool expected = true;

            // Act
            seatSelection.Availability = expected;
            bool actual = seatSelection.Availability;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BookingDatePropertyTest()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            DateTime expected = DateTime.Now;

            // Act
            seatSelection.BookingDate = expected;
            DateTime actual = seatSelection.BookingDate;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BookingIDPropertyTest()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            int expected = 1;

            // Act
            seatSelection.BookingID = expected;
            int actual = seatSelection.BookingID;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SeatIDPropertyTest()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            int expected = 1;

            // Act
            seatSelection.SeatID = expected;
            int actual = seatSelection.SeatID;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SeatTypePropertyTest()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            string expected = "First Class";

            // Act
            seatSelection.SeatType = expected;
            string actual = seatSelection.SeatType;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberOfSeatsPropertyTest()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            int expected = 4;

            // Act
            seatSelection.NumberOfSeats = expected;
            int actual = seatSelection.NumberOfSeats;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SectionPropertyTest()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            string expected = "Window Seat";

            // Act
            seatSelection.Section = expected;
            string actual = seatSelection.Section;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMethodTest()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            int bookingID = 1;

            // Act
            bool found = seatSelection.Find(bookingID);

            // Assert
            Assert.IsTrue(found);
            Assert.AreEqual(bookingID, seatSelection.BookingID);
        }

        [TestMethod]
        public void ValidMethodTest()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            string seatID = "1";
            string seatType = "First Class";
            string numberOfSeats = "4";
            string bookingDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            string section = "Window Seat";
            string expected = "";

            // Act
            string actual = seatSelection.Valid(seatID, seatType, numberOfSeats, bookingDate, section);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidMethodTest_InvalidDate()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            string seatID = "1";
            string seatType = "First Class";
            string numberOfSeats = "4";
            string bookingDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            string section = "Window Seat";
            string expected = "The date cannot be in the past. ";

            // Act
            string actual = seatSelection.Valid(seatID, seatType, numberOfSeats, bookingDate, section);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidMethodTest_InvalidSeatID()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            string seatID = "0";
            string seatType = "First Class";
            string numberOfSeats = "4";
            string bookingDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            string section = "Window Seat";
            string expected = "The Seat ID may not be blank. The Seat ID must be between 1 and 5. ";

            // Act
            string actual = seatSelection.Valid(seatID, seatType, numberOfSeats, bookingDate, section);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidMethodTest_InvalidNumberOfSeats()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            string seatID = "1";
            string seatType = "First Class";
            string numberOfSeats = "1";

            string section = "Window Seat";
            string expected = "The Number of Seats may not be blank. The Number of Seats must be between 1 and 8. ";

            // Act
            string actual = seatSelection.Valid(seatID, seatType, numberOfSeats, bookingDate, section);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidMethodTest_InvalidSeatType()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            string seatID = "1";
            string seatType = "";
            string numberOfSeats = "4";
            string bookingDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            string section = "Window Seat";
            string expected = "The Seat Type may not be blank. Please type 'First Class' or 'Second Class'. ";

            // Act
            string actual = seatSelection.Valid(seatID, seatType, numberOfSeats, bookingDate, section);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidMethodTest_InvalidSection()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            string seatID = "1";
            string seatType = "First Class";
            string numberOfSeats = "4";
            string bookingDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            string section = "";
            string expected = "The Section may not be blank. Please type 'Window Seat' or 'Non Window Seat'. ";

            // Act
            string actual = seatSelection.Valid(seatID, seatType, numberOfSeats, bookingDate, section);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AvailabilityPropertyOK()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            bool TestData = true;

            // Act
            seatSelection.Availability = TestData;
            bool actual = seatSelection.Availability;

            // Assert
            Assert.AreEqual(TestData, actual);
        }

        [TestMethod]
        public void BookingDatePropertyOK()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            DateTime TestData = DateTime.Now.Date;

            // Act
            seatSelection.BookingDate = TestData;
            DateTime actual = seatSelection.BookingDate;

            // Assert
            Assert.AreEqual(TestData, actual);
        }

        [TestMethod]
        public void BookingIDPropertyOK()
        {
            // Arrange
            clsSeatSelection seatSelection = new clsSeatSelection();
            int TestData = 1;

            // Act
            seatSelection.BookingID = TestData;
            int actual = seatSelection.BookingID;

            // Assert
            Assert.AreEqual(TestData, actual);
        }

        [TestMethod]
        public void SeatIDPropertyOK()
        {

            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            int TestData = 1;

            // Act
            seatSelection.SeatID = TestData;
            int actual = seatSelection.SeatID;

            // Assert
            Assert.AreEqual(TestData, actual);
        }

        [TestMethod]
        public void SeatTypePropertyOK()
        {

            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            string TestData = "First Class";

            // Act
            seatSelection.SeatType = TestData;
            string actual = seatSelection.SeatType;

            // Assert
            Assert.AreEqual(TestData, actual);
        }

        [TestMethod]
        public void NumberOfSeatsPropertyOK()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            int TestData = 4;

            // Act
            seatSelection.NumberOfSeats = TestData;
            int actual = seatSelection.NumberOfSeats;

            // Assert
            Assert.AreEqual(TestData, actual);
        }

        [TestMethod]
        public void SectionPropertyOK()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            string TestData = "Window Seat";

            // Act
            seatSelection.Section = TestData;
            string actual = seatSelection.Section;

            // Assert
            Assert.AreEqual(TestData, actual);
        }
        [TestMethod]
        public void ValidMehodOK()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            string Error = "";

            Error = seatSelection.Valid(seatID, seatType, numberedSeats, section, bookingDate);
            Assert.AreEqual(Error, "");

        }

        [TestMethod]
        public void SeatTypeMinLessOne()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            string seatType = "";

            string Error = "";

            // Act
            Error = seatSelection.Valid(seatID, seatType, numberedSeats, section, bookingDate);

            // Assert
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void SeatTypeMin()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            string seatType = "a";

            string Error = "";

            // Act
            Error = seatSelection.Valid(seatID, seatType, numberedSeats, section, bookingDate);

            // Assert
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void SeatTypeMinPlusOne()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            string seatType = "aa";

            string Error = "";

            // Act
            Error = seatSelection.Valid(seatID, seatType, numberedSeats, section, bookingDate);

            // Assert
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void SeatTypeMaxLessOne()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            string seatID = "1";
            string seatType = new string('a', 12); // 12 characters long, one less than the max length
            string numberOfSeats = "1"; // A valid number of seats within the allowed range
            string bookingDate = DateTime.Now.AddDays(1).ToString("MM-dd-yyyy"); // A valid future date
            string section = "Window Seat"; // A valid section

            string Error = "";
            // Act
            Error = seatSelection.Valid(seatID, seatType, numberOfSeats, bookingDate, section);

            // Assert
            Assert.AreEqual("", Error);
        }


        [TestMethod]
        public void SeatTypeMax()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange

            string seatType = new string('a', 13); // 12 characters long, one less than the max length


            string Error = "";
            // Act
            Error = seatSelection.Valid(seatID, seatType, numberedSeats, section, bookingDate);

            // Assert
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void SeatTypeMaxPlusOne()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            string seatType = new string('a', 51);

            string seatID = "2";



            string Error = "";

            // Act
            Error = seatSelection.Valid(seatID, seatType, numberedSeats, section, bookingDate);

            // Assert
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void SeatTypeMid()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            string seatType = "aaaa";

            string Error = "";

            // Act
            Error = seatSelection.Valid(seatID, seatType, numberedSeats, section, bookingDate);

            // Assert
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void SeatTypeExtremeMax()
        {
            clsSeatSelection seatSelection = new clsSeatSelection();
            // Arrange
            string seatType = new string('a', 100);
            string bookingDate = "12-03-2003";
            string Error = "";



            // Act
            Error = seatSelection.Valid(seatID, seatType, numberedSeats, section, bookingDate);

            // Assert
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void SectionExtremeMin()
        {
            // Create an instance of the class we want to test
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // String variable to store any error message
            string Error = "";
            // Set section to an empty string
            string section = "";
            // Invoke the method
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", section);
            // Test to see that an error message is returned
            Assert.AreNotEqual(Error, "");
        }
        [TestMethod]
        public void SectionExtremeMax()
        {
            // Create an instance of the class we want to test
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // String variable to store any error message
            string Error = "";
            // Create a long string exceeding the maximum allowed length for section
            string longSection = new string('X', 16); // Create a string of length 16 (exceeds max length)
                                                      // Invoke the method
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", longSection);
            // Test to see that an error message is returned
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void SectionMin()
        {
            // Create an instance of the class we want to test
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // String variable to store any error message
            string Error = "x";
            // Set section to a string of minimum allowed length for section
            string Section = "X"; // Create a string of length 1 (minimum length)
                                  // Invoke the method
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", Section);
            // Test to see that no error message is returned
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void SectionMinLessOne()
        {
            // Create an instance of the class we want to test
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // String variable to store any error message
            string Error = "";
            // Create a string with one character less than the minimum allowed length for section
            string Section = ""; // Create a string of length 1 (one character less than the min length)
                                 // Invoke the method
            Error = AnSeatSelection.Valid("1", "First Class", "", "2024-06-05", Section);
            // Test to see that an error message is returned
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void SectionMid()
        {
            // Create an instance of the class we want to test
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // String variable to store any error message
            string Error = "x";
            // Set section to a string of minimum allowed length for section
            string Section = "Xxx"; // Create a string of length 1 (minimum length)
                                    // Invoke the method
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", Section);
            // Test to see that no error message is returned
            Assert.AreEqual(Error, "");
        }
        [TestMethod]
        public void NumberedSeatsMin()
        {
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // Arrange
            string NumberedSeats = "0";

            string Error = "";

            // Act
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", NumberedSeats);

            // Assert
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NumberedSeatsMinPlusOne()
        {
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // Arrange
            string NumberedSeats = "1";
            string SeatID = "2";

            string Error = "";

            // Act
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", NumberedSeats);
            // Assert
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NumberedSeatsMaxLessOne()
        {
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // Arrange
            string NumberedSeats = "7";

            string Error = "";

            // Act
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", NumberedSeats);

            // Assert
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NumberedSeatsMax()
        {
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // Arrange
            string NumberedSeats = "8";

            string Error = "";

            // Act
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", NumberedSeats);

            // Assert
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NumberedSeatsMaxPlusOne()
        {
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            
            // Arrange
            string NumberedSeats = "9";

            string Error = "";

            // Act
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", NumberedSeats);

            // Assert
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void NumberedSeatsMid()
        {
            clsSeatSelection AnSeatSelection = new clsSeatSelection();
            // Arrange
            string NumberedSeats = "4";

            string Error = "";
            Error = AnSeatSelection.Valid("1", "First Class", "1", "2024-06-05", NumberedSeats);
            Assert.AreEqual(Error, "");


        }
    }
}

       
  

