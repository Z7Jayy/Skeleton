using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsTicketCollection
    {
        //private data member for the list
        List<clsTicket> mTicketList = new List<clsTicket>();
        //private data member for ThisTicket
        clsTicket mThisTicket = new clsTicket();

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

       //public property for ThisTicket
       public clsTicket ThisTicket
        {
            get
            {
                //return the private data
                return mThisTicket;
            }
            set
            {
                //set the private data
                mThisTicket = value;
            }
        }

        //public constructor for the class
        public clsTicketCollection()
        {
            //object for the data connect
            clsDataConnection DB = new clsDataConnection();
            //execute the stored procedure
            DB.Execute("sproc_tblTicket_SelectAll");
            //populate the array list with the data table 
            PopulateArray(DB);
            
        }

        public int Add()
        {
            //adds a record to the database based on the values of mThisTicket
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@Price", mThisTicket.Price);
            DB.AddParameter("@Date", mThisTicket.Date);
            DB.AddParameter("@Venue", mThisTicket.Venue);
            DB.AddParameter("@Artist", mThisTicket.Artist);
            DB.AddParameter("@IsSold", mThisTicket.IsSold);
            DB.AddParameter("@TicketType", mThisTicket.TicketType);

            //execute the query returning the primary key value
            return DB.Execute("sproc_tblTicket_Insert");
        }

        public void Update()
        {
            //update an existing record based on the values of ThisTicket
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@TicketId", mThisTicket.TicketId);
            DB.AddParameter("@Price", mThisTicket.Price);
            DB.AddParameter("@Date", mThisTicket.Date);
            DB.AddParameter("@Venue", mThisTicket.Venue);
            DB.AddParameter("@Artist", mThisTicket.Artist);
            DB.AddParameter("@IsSold", mThisTicket.IsSold);
            DB.AddParameter("@TicketType", mThisTicket.TicketType);

            //execute the stored procedure
            DB.Execute("sproc_tblTicket_Update");
        }

        public void Delete()
        {
           //delete the record pointed by thisticket
           //connect to the dtabase 
           clsDataConnection DB = new clsDataConnection();
            //set the parameters for the stored procedure
            DB.AddParameter("@TicketId", mThisTicket.TicketId);
            //execute the stored procedure 
            DB.Execute("sproc_tblTicket_Delete");
        }

        public void ReportByArtist(string Artist)
        {
            //filters the records based on a full or partial artist
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //send the artist parameter to the database 
            DB.AddParameter("@Artist", Artist);
            //execute the stored procedure
            DB.Execute("sproc_tblTicket_FilterByArtist");
            //populate the array list with the data table 
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            //populates the array list based on the data table in the parameter DB
            //variable for the index
            Int32 Index = 0;
            //variable to store the record count
            Int32 RecordCount = 0;
            //get the count of records 
            RecordCount = DB.Count;
            //clear the private array list 
            mTicketList = new List<clsTicket>();
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