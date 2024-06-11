using System;
using System.Data;
using System.Linq.Expressions;
using static System.Collections.Specialized.BitVector32;


namespace ClassLibrary
{
    public class clsSeatSelection
    {

        private bool mAvailabilty;
        public bool Availabilty;

        private bool mAvailability;
        public bool Availability
        {
            get { return mAvailability; }
            set { mAvailability = value; }
        }

        private DateTime mBookingDate;
        public DateTime BookingDate
        {
            get { return mBookingDate; }
            set { mBookingDate = value; }
        }

        private int mBookingID;
        public int BookingID
        {
            get { return mBookingID; }
            set { mBookingID = value; }
        }

        private int mSeatID;
        public int SeatID
        {
            get { return mSeatID; }
            set { mSeatID = value; }
        }

        private string mSeatType;
        public string SeatType
        {
            get { return mSeatType; }
            set { mSeatType = value; }
        }

        private int mNumberOfSeats;
        public int NumberOfSeats
        {
            get { return mNumberOfSeats; }
            set { mNumberOfSeats = value; }
        }

        private string mSection;
        public string Section
        {
            get { return mSection; }
            set { mSection = value; }
        }

        public bool Find(int bookingID)
        {
            // create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();
            // add the parameter for the booking id to search for
            DB.AddParameter("@BookingID", bookingID);
            // execute the stored procedure
            DB.Execute("spro_tblSeat_Selection_FilterByBookingID");
            // if one record is found (there should be either one or zero)
            if (DB.Count == 1)
            {
                // copy the data from the database to the private data members
                DataRow row = DB.DataTable.Rows[0];
                mBookingID = Convert.ToInt32(row["BookingID"]);
                mNumberOfSeats = Convert.ToInt32(row["NumberOfSeats"]);
                mSeatID = Convert.ToInt32(row["SeatID"]);
                mBookingDate = Convert.ToDateTime(row["BookingDate"]);
                mSection = Convert.ToString(row["Section"]);
                mSeatType = Convert.ToString(row["SeatType"]);
                mAvailability = Convert.ToBoolean(row["Availabilty"]);
                // return true indicating everything worked OK
                return true;
            }
            else
            {
                // return false indicating there is a problem
                return false;
            }
        }

        public string Valid(string seatID, string seatType, string numberOfSeats, string bookingDate, string section)
        {
            int SeatID;
            int NumberOfSeats;

            string Error = "";
            DateTime DateTemp;

            DateTime DateComp = DateTime.Now.Date;


            if (string.IsNullOrWhiteSpace(seatType))
            {
                Error += "The Seat Type may not be blank. Please type 'First Class' or 'Second Class'. ";
            }
            else if (seatType.Length > 13)
            {
                Error += "The Seat Type must be 13 characters or less. ";
            }

            if (string.IsNullOrWhiteSpace(section))
            {
                Error += "The Section may not be blank. Please type 'Window Seat' or 'Non Window Seat'. ";
            }
            else if (section.Length > 15)
            {
                Error += "The Section must be 15 characters or less. ";
            }

            // Create a temporary variable to store the date values
            
            // Create an instance of DateTime to compare with DateTemp
            

           

            return Error;
        }

    }
}


