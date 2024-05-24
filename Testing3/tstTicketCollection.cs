﻿using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace Testing3
{
    [TestClass]
    public class tstTicketCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            //create an instance of the class we want to create
            clsTicketCollection AllTickets = new clsTicketCollection();
            //test to see that it exists
            Assert.IsNotNull(AllTickets);
        }

        [TestMethod]
        public void TicketListOK() 
        {
            // Create an instance of the class we want to create
            clsTicketCollection AllTickets = new clsTicketCollection();

            // Create some test data to assign to the property
            // In this case, the data needs to be a list of objects
            List<clsTicket> TestList = new List<clsTicket>();

            // Add an item to the list
            // Create the item of test data
            clsTicket TestItem = new clsTicket();

            //set its properties
            TestItem.TicketId = 1;
            TestItem.Date = DateTime.Now;
            TestItem.Price = 1;
            TestItem.Venue = "Some Venue";
            TestItem.Artist = "Some Artist";
            TestItem.IsSold = true;
            TestItem.TicketType = "VIP";

            //add the item to the test list
            TestList.Add(TestItem);

            // Assign the data to the property
            AllTickets.TicketList = TestList;

            // Test to see that the two values are the same
            Assert.AreEqual(AllTickets.TicketList, TestList);

        }

        
        [TestMethod]
        public void ThisTicketPropertyOK()
        {
            // Create an instance of the class we want to create
            clsTicketCollection AllTickets = new clsTicketCollection();
            //create some test data to assign to the property
            clsTicket TestTicket = new clsTicket();
            //set the properties of the test object
            TestTicket.TicketId = 1;
            TestTicket.Date = DateTime.Now;
            TestTicket.Price = 1;
            TestTicket.Venue = "Some Venue";
            TestTicket.Artist = "Some Artist";
            TestTicket.IsSold = true;
            TestTicket.TicketType = "VIP";

            //assign the data to the property
            AllTickets.ThisTicket = TestTicket;

            //test to see that the two values are the same 
            Assert.AreEqual(AllTickets.ThisTicket, TestTicket);


        }

        [TestMethod]
        public void ListAndCountOK()
        {
            // Create an instance of the class we want to create
            clsTicketCollection AllTickets = new clsTicketCollection();
            //create some test data to assign to the property
            //in this case the data needs to be a list of objects
            List<clsTicket> TestList = new List<clsTicket>();
            //add an item to the list 
            //create the item of test data 
            clsTicket TestItem = new clsTicket();
            //set its properties
            TestItem.TicketId = 1;
            TestItem.Date = DateTime.Now;
            TestItem.Price = 1;
            TestItem.Venue = "Some Venue";
            TestItem.Artist = "Some Artist";
            TestItem.IsSold = true;
            TestItem.TicketType = "VIP";
            //add the item to the test list 
            TestList.Add(TestItem);
            //assign the data to the property 
            AllTickets.TicketList = TestList;
            //test to see that the two values are the same 
            Assert.AreEqual(AllTickets.Count, TestList.Count);  
        }

        [TestMethod]
        public void AddMethodOK()
        {
            // Create an instance of the class we want to create
            clsTicketCollection AllTickets = new clsTicketCollection();
            //create an item of the test data 
            clsTicket TestItem = new clsTicket();
            //variable to store the priamry key 
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.TicketId = 1;
            TestItem.Date = DateTime.Now;
            TestItem.Price = 1;
            TestItem.Venue = "Some Venue";
            TestItem.Artist = "Some Artist";
            TestItem.IsSold = true;
            TestItem.TicketType = "VIP";
            //set thisticket to the test data 
            AllTickets.ThisTicket = TestItem;
            //add the record
            PrimaryKey = AllTickets.Add();
            //set the primary key of the test data 
            TestItem.TicketId = PrimaryKey;
            //find the record
            AllTickets.ThisTicket.Find(PrimaryKey);
            //test to see that the two values are the same 
            Assert.AreEqual(AllTickets.ThisTicket, TestItem);
        }

        [TestMethod]
        public void UpdateMethodOK()
        {
            // Create an instance of the class we want to create
            clsTicketCollection AllTickets = new clsTicketCollection();
            //create an item of the test data 
            clsTicket TestItem = new clsTicket();
            //variable to store the priamry key 
            Int32 PrimaryKey = 0;
            //set its properties
            TestItem.Date = DateTime.Now;
            TestItem.Price = 1;
            TestItem.Venue = "Some Venue";
            TestItem.Artist = "Some Artist";
            TestItem.IsSold = true;
            TestItem.TicketType = "VIP";
            //set thisticket to the test data 
            AllTickets.ThisTicket = TestItem;
            //add the record
            PrimaryKey = AllTickets.Add();
            //set the primary key of the test data 
            TestItem.TicketId = PrimaryKey;
            //modify the test record
            TestItem.Price = 3;
            TestItem.Date = DateTime.Now;
            TestItem.Venue = "Another Venue";
            TestItem.Artist = "Another Artist";
            TestItem.IsSold = false;
            TestItem.TicketType = "Regular";
            //set the record based on the new data 
            AllTickets.ThisTicket = TestItem;
            //update the record
            AllTickets.Update();
            //find the record
            AllTickets.ThisTicket.Find(PrimaryKey);
            //test to see if thisticket matches the test data 
            Assert.AreEqual(AllTickets.ThisTicket, TestItem);
        }











    }
}
