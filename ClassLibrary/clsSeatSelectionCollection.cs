using System;
using System.Collections.Generic;
using System.Data;
using static System.Collections.Specialized.BitVector32;

namespace ClassLibrary
{
    public class clsSeatSelectionCollection
    {
        // List to hold booking items
        private List<clsSeatSelection> mBookingList = new List<clsSeatSelection>();
        clsSeatSelection mThisBooking = new clsSeatSelection();




        public clsSeatSelectionCollection()

        {
            // Initialize the data connection
            clsDataConnection DB = new clsDataConnection();
            // Execute the stored procedure to select all seat selections
            DB.Execute("sproc_tblSeat_SelectALL");

            // Initialize the list to hold seat selections
            mBookingList = new List<clsSeatSelection>();

            // Loop through each row in the DataTable and populate mBookingList
            foreach (DataRow row in DB.DataTable.Rows)
            {
                clsSeatSelection AnSeatSelection = new clsSeatSelection();
                AnSeatSelection.Availabilty = true;
                AnSeatSelection.BookingID = Convert.ToInt32(row["BookingID"]);
                AnSeatSelection.NumberOfSeats = Convert.ToInt32(row["NumberOfSeats"]);
                AnSeatSelection.SeatID = Convert.ToInt32(row["SeatID"]);
                AnSeatSelection.BookingDate = Convert.ToDateTime(row["BookingDate"]);
                AnSeatSelection.SeatType = Convert.ToString(row["SeatType"]);
                AnSeatSelection.Section = Convert.ToString(row["Section"]);

                // Add the record to the private data member
                mBookingList.Add(AnSeatSelection);
            }
        }


        void PopulateArray(clsDataConnection DB)
        {
            // Variable for the index
            Int32 Index = 0;
            // Variable to store the record count
            Int32 RecordCount;

            // Get the count of records
            RecordCount = DB.Count;

            // Clear the private list
            mBookingList = new List<clsSeatSelection>();

            // While there are records to process
            while (Index < RecordCount)
            {


                // Read in the fields from the current record

                clsSeatSelection AnSeatSelection = new clsSeatSelection();
                AnSeatSelection.Availabilty = Convert.ToBoolean(DB.DataTable.Rows[Index]["Availabilty"]);
                AnSeatSelection.BookingID = Convert.ToInt32(DB.DataTable.Rows[Index]["BookingID"]);
                AnSeatSelection.NumberOfSeats = Convert.ToInt32(DB.DataTable.Rows[Index]["NumberOfSeats"]);
                AnSeatSelection.SeatID = Convert.ToInt32(DB.DataTable.Rows[Index]["SeatID"]);
                AnSeatSelection.BookingDate = Convert.ToDateTime(DB.DataTable.Rows[Index]["BookingDate"]);
                AnSeatSelection.SeatType = Convert.ToString(DB.DataTable.Rows[Index]["SeatType"]);
                AnSeatSelection.Section = Convert.ToString(DB.DataTable.Rows[Index]["Section"]);

                // Add the record to the private data member
                mBookingList.Add(AnSeatSelection);

                // Point at the next record
                Index++;
            }




        }

        public List<clsSeatSelection> BookingList
        {
            get
            {
                return mBookingList;
            }
            set
            {
                mBookingList = value;
            }
        }

        public int Count
        {
            get
            {
                return mBookingList.Count;
            }
        }

        public clsSeatSelection ThisBooking
        {
            get
            {
                // Return the private data
                return mThisBooking;
            }
            set
            {
                // Set the private data
                mThisBooking = value;
            }
        }

        public int Add()
        {
            // adds a record to the database based on the values of mThisSeatSelection
            // connect to the database
            clsDataConnection DB = new clsDataConnection();
            // set the parameters for the stored procedure
            DB.AddParameter("@Availabilty", mThisBooking.Availabilty);
            //DB.AddParameter("@BookingID", mThisBooking.BookingID);
            DB.AddParameter("@NumberOfSeats", mThisBooking.NumberOfSeats);
            DB.AddParameter("@SeatID", mThisBooking.SeatID);
            DB.AddParameter("@BookingDate", mThisBooking.BookingDate);
            DB.AddParameter("@SeatType", mThisBooking.SeatType);
            DB.AddParameter("@Section", mThisBooking.Section);
            // execute the query returning the primary key value
            return DB.Execute("sproc_tblSeatSelection_Insert");
        }

        public void Delete()
        {
            // Deletes the record pointed to by mThisBooking
            // Connect to the database
            clsDataConnection DB = new clsDataConnection();
            // Set the parameters for the stored procedure
            DB.AddParameter("@BookingID", mThisBooking.BookingID);
            // Execute the stored procedure
            DB.Execute("sproc_tblSeatSelection_Delete");
        }

        public void ReportBySection(string Section)
        {
            // Connect to the database
            clsDataConnection DB = new clsDataConnection();

            // Send the PostCode parameter to the database
            DB.AddParameter("@Section", Section); // Append '%' for partial matching

            // Execute the stored procedure to filter addresses by post code
            DB.Execute("sproc_tblSeat_Selection_FilterBySection");


        }

        public void Update()
        {
            // update an existing record based on the values of mThisSeatSelection
            // connect to the database
            clsDataConnection DB = new clsDataConnection();
            // set the parameters for the new stored procedure
            DB.AddParameter("@SeatID", mThisBooking.SeatID);
            DB.AddParameter("@Availabilty", mThisBooking.Availabilty);
            DB.AddParameter("@BookingID", mThisBooking.BookingID);
            DB.AddParameter("@NumberOfSeats", mThisBooking.NumberOfSeats);
            DB.AddParameter("@BookingDate", mThisBooking.BookingDate);
            DB.AddParameter("@SeatType", mThisBooking.SeatType);
            DB.AddParameter("@Section", mThisBooking.Section);
            // execute the stored procedure
            DB.Execute("sproc_tblSeatSelection_Update");
        }
    }
}