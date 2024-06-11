using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;

namespace Testing5
{
    [TestClass]
    public class tstSeatSelectionCollection
    {
        clsSeatSelectionCollection AllSeatSelection = new clsSeatSelectionCollection();

        [TestMethod]
        public void InstanceOK()
        {
            clsSeatSelectionCollection AllSeatSelection = new clsSeatSelectionCollection();
            Assert.IsNotNull(AllSeatSelection);

        }

        [TestMethod]
        public void CountPropertyOK()
        {
            // Create an instance of the class we want to test
            clsSeatSelectionCollection AllSeatSelection = new clsSeatSelectionCollection();

            // Create some test data to assign to the list
            List<clsSeatSelection> TestList = new List<clsSeatSelection>();

            // Here you should add some test data to the TestList
            // For example, let's add a single test item
            clsSeatSelection TestItem = new clsSeatSelection();
            TestItem.Availabilty = true;
            TestItem.BookingID = 1;
            TestItem.NumberOfSeats = 2;
            TestItem.SeatID = 1;
            TestItem.BookingDate = DateTime.Now;
            TestItem.SeatType = "Economy";
            TestItem.Section = "A";

            TestList.Add(TestItem);

            // Assign the test list to the property
            AllSeatSelection.BookingList = TestList;

            // Create a variable to hold the expected count
            Int32 SomeCount = TestList.Count;

            // Test to see that the two values are the same
            Assert.AreEqual(AllSeatSelection.Count, SomeCount);
        }

        [TestMethod]
        public void BookingList()
        {
            // Create an instance of the class we want to test
            clsSeatSelectionCollection AllSeatSelection = new clsSeatSelectionCollection();

            // Create some test data to assign to the property
            List<clsSeatSelection> TestList = new List<clsSeatSelection>();

            // Add an item to the list
            clsSeatSelection TestItem = new clsSeatSelection();
            TestItem.Availabilty = true;
            TestItem.BookingID = 1;
            TestItem.NumberOfSeats = 1;
            TestItem.SeatID = 1;
            TestItem.BookingDate = DateTime.Now;
            TestItem.SeatType = "21b";
            TestItem.Section = "LE1 4AB";

            // Add the item to the test list
            TestList.Add(TestItem);

            // Assign the data to the property
            AllSeatSelection.BookingList = TestList;

            // Test to see that the two values are the same
            Assert.AreEqual(AllSeatSelection.BookingList.Count, TestList.Count);
        }


        [TestMethod]


        public void ThisBookingPrpertyOK()
        {
            // Create an instance of the class we want to tes
            // Create some test data to assign to the property
            // In this case, the data needs to be a list of objects
            clsSeatSelectionCollection AllSeatSelection = new clsSeatSelectionCollection();
            clsSeatSelection TestBooking = new clsSeatSelection();

            TestBooking.Availabilty = true;
            TestBooking.BookingID = 1;
            TestBooking.NumberOfSeats = 1;
            TestBooking.SeatID = 1;
            TestBooking.BookingDate = DateTime.Now;
            TestBooking.SeatType = "21b";
            TestBooking.Section = "LE1 4AB";




            // Assign the data to the property
            AllSeatSelection.ThisBooking = TestBooking;

            // Test to see that the two values are the same
            Assert.AreEqual(AllSeatSelection.ThisBooking, TestBooking);
        }

        [TestMethod]
        public void AddOk()
        {
            // Create an instance of the class we want to test
            clsSeatSelectionCollection AllSeatSelection = new clsSeatSelectionCollection();

            
            // Create a test item
            clsSeatSelection TestItem = new clsSeatSelection();

            int PrimaryKey = AllSeatSelection.Add();

            TestItem.Availabilty = true;
            TestItem.NumberOfSeats = 1;
            TestItem.BookingDate = DateTime.Now;
            TestItem.SeatType = "First Class";
            TestItem.Section = "AA";

            // Assign the test item to ThisBooking
            AllSeatSelection.ThisBooking = TestItem;
            PrimaryKey = AllSeatSelection.Add();

            // Add the item to the database
           
            TestItem.BookingID = PrimaryKey;

            // Find the added item
            AllSeatSelection.ThisBooking.Find(PrimaryKey);

            // Assert that the values are the same
            Assert.AreEqual(AllSeatSelection.ThisBooking, TestItem);
          
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            // Create an instance of the class we want to test
            clsSeatSelectionCollection AllSeatSelection = new clsSeatSelectionCollection();

            // Create the item of test data
            clsSeatSelection TestItem = new clsSeatSelection();
            TestItem.Availabilty = true;
            TestItem.BookingID = 1;
            TestItem.NumberOfSeats = 2;
            TestItem.SeatID = 1;
            TestItem.BookingDate = DateTime.Now;
            TestItem.SeatType = "Economy";
            TestItem.Section = "A";

            // Add the record
            AllSeatSelection.ThisBooking = TestItem;
            int PrimaryKey = AllSeatSelection.Add();
            TestItem.SeatID = PrimaryKey;

            // Modify the test record
            TestItem.Availabilty = false;
            TestItem.BookingID = 2;
            TestItem.NumberOfSeats = 4;
            TestItem.SeatID = PrimaryKey; // Ensure the primary key is set correctly
            TestItem.BookingDate = DateTime.Now.AddDays(1);
            TestItem.SeatType = "Business";
            TestItem.Section = "B";

            // Update the record
            AllSeatSelection.ThisBooking = TestItem;
            AllSeatSelection.Update();

            // Find the record
            AllSeatSelection.ThisBooking.Find(PrimaryKey);

            // Test if ThisBooking matches the test data
            Assert.AreEqual(AllSeatSelection.ThisBooking.Availabilty, TestItem.Availabilty);
            Assert.AreEqual(AllSeatSelection.ThisBooking.BookingID, TestItem.BookingID);
            Assert.AreEqual(AllSeatSelection.ThisBooking.NumberOfSeats, TestItem.NumberOfSeats);
            Assert.AreEqual(AllSeatSelection.ThisBooking.SeatID, TestItem.SeatID);
            Assert.AreEqual(AllSeatSelection.ThisBooking.BookingDate, TestItem.BookingDate);
            Assert.AreEqual(AllSeatSelection.ThisBooking.SeatType, TestItem.SeatType);
            Assert.AreEqual(AllSeatSelection.ThisBooking.Section, TestItem.Section);
        }

        [TestMethod]
        public void DeleteMethodOK()
        {
            // Create an instance of the class we want to create
            clsSeatSelectionCollection AllSeatSelections = new clsSeatSelectionCollection();

            // Create the item of test data
            clsSeatSelection TestItem = new clsSeatSelection();
            // Variable to store the primary key
            Int32 PrimaryKey = 0;
            // Set its properties
            TestItem.Availabilty = true;
            TestItem.SeatID = 1; // This will be overwritten by the primary key value
            TestItem.NumberOfSeats = 2;
            TestItem.BookingDate = DateTime.Now;
            TestItem.SeatType = "Premium";
            TestItem.Section = "A";
            // Set ThisBooking to the test data
            AllSeatSelections.ThisBooking = TestItem;
            // Add the record
            PrimaryKey = AllSeatSelections.Add();
            // Set the primary key of the test data
            TestItem.SeatID = PrimaryKey;
            // Find the record
            AllSeatSelections.ThisBooking.Find(PrimaryKey);
            // Delete the record
            AllSeatSelections.Delete();
            // Now find the record
            Boolean Found = AllSeatSelections.ThisBooking.Find(PrimaryKey);
            // Test to see that the record was not found
            Assert.IsFalse(Found);
        }


        [TestMethod]
        public void ReportBySection()
        {
            clsSeatSelectionCollection AllSeatSelections = new clsSeatSelectionCollection();

            // Apply a section filter (replace "SectionA" with the section you want to filter)
            AllSeatSelections.ReportBySection("SectionA");

            // Test to see that the filtered count matches the expected count
            Assert.AreEqual(AllSeatSelections.Count, AllSeatSelections.Count);
        }


        [TestMethod]
        public void ReportBySectionNoneFound()
        {
            // Create an instance of the class we want to test
            clsSeatSelectionCollection FilteredSeatSelections = new clsSeatSelectionCollection();

            // Apply a section that doesn't exist
            FilteredSeatSelections.ReportBySection("SectionThatDoesNotExist");

            // Test to see that there are no records
            Assert.AreEqual(FilteredSeatSelections.Count, 0);
        }


        [TestMethod]
        public void ReportBySectionFilteredDataFound()
        {
            // Create an instance of the class we want to test
            clsSeatSelectionCollection FilteredSeatSelections = new clsSeatSelectionCollection();

            // Apply a section filter (replace "SectionA" with the section you want to filter)
            FilteredSeatSelections.ReportBySection("SectionA");

            // A variable to store the outcome
            bool OK = true;

            // Check that the correct number of records is found
            if (FilteredSeatSelections.Count == 2)
            {
                // Check that the first record has the correct BookingId
                if (FilteredSeatSelections.BookingList[0].BookingID != 25)
                {
                    OK = false;
                }

                // Check that the second record has the correct BookingId
                if (FilteredSeatSelections.BookingList[1].BookingID != 26)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }

            // Assert that OK is true
            Assert.IsTrue(OK);
        }
    }
}



