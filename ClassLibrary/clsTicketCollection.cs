using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsTicketCollection
    {
        //private data member for the list
        List<clsTicket> mTicketList = new List<clsTicket>();

        public List<clsTicket> TicketList
        {
            get
            {
                //return the private data
                return mTicketList;
            }
            set
            {
                //set the private data 
                mTicketList = value;
            }
        }

        //public property for count
        public int Count
        {
            get
            {
                //return the count of the list
                return mTicketList.Count;
            }
            set
            {
                //we shall worry about this later
            }
        }
        public clsTicket ThisTicket { get; set; }

       

        //public constructor for the class
        public clsTicketCollection()
        {
            //variable for the index
            Int32 Index = 0;
            //variable to store the record count
            Int32 RecordCount = 0;
            //object for the data connect
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblTicket_SelectAll");
            //get the count of records
            RecordCount = DB.Count;
            //while there are records to process
            while (Index < RecordCount)
            {
                //create a blank address
                clsTicket AnTicket = new clsTicket();
                //read in the fields for the current record
                AnTicket.TicketId = Convert.ToInt32(DB.DataTable.Rows[Index]["TicketId"]);
                AnTicket.Date = Convert.ToDateTime(DB.DataTable.Rows[Index]["Date"]);
                AnTicket.Price = Convert.ToInt32(DB.DataTable.Rows[Index]["Price"]);
                AnTicket.Venue = Convert.ToString(DB.DataTable.Rows[Index]["Venue"]);
                AnTicket.Artist = Convert.ToString(DB.DataTable.Rows[Index]["Artist"]);
                AnTicket.IsSold = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsSold"]);
                AnTicket.TicketType = Convert.ToString(DB.DataTable.Rows[Index]["TicketType"]);
                //add the record to the private data member
                mTicketList.Add(AnTicket);
                //point at the next record
                Index++;

            }
        }









    }
}