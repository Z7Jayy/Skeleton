using System;

namespace ClassLibrary
{
    public class clsTicket
    {
        //private data member for the ticket id property
        private Int32 mTicketId;

        //ticketid public property
        public Int32 TicketId
        {
            get
            {
                //this line of code sends data out of the property
                return mTicketId;
            }
            set
            {
                //this line of code allows data into the property
                mTicketId = value;
            }
        }

        // Private data member for the Date property
        private DateTime mDate;
        // Date public property
        public DateTime Date
        {
            get
            {
                // This line of code sends data out of the property
                return mDate;
            }
            set
            {
                // This line of code allows data into the property
                mDate = value;
            }
        }

        //private data member for the ticket id property
        private Int32 mPrice;

        //ticketid public property
        public Int32 Price
        {
            get
            {
                //this line of code sends data out of the property
                return mPrice;
            }
            set
            {
                //this line of code allows data into the property
                mPrice = value;
            }
        }

        //private data member for the venue property
        private string mVenue;

        //venue public property
        public string Venue
        {
            get
            {
                //this line of code sends data out of the property
                return mVenue;
            }
            set
            {
                //this line of code allows data into the property
                mVenue = value;
            }
        }

        // Private data member for the Artist property
        private string mArtist;
        // Artist public property
        public string Artist
        {
            get
            {
                // This line of code sends data out of the property
                return mArtist;
            }
            set
            {
                // This line of code allows data into the property
                mArtist = value;
            }
        }

        // Private data member for the IsSold property
        private Boolean mIsSold;

        // IsSold public property
        public bool IsSold
        {
            get
            {
                // This line of code sends data out of the property
                return mIsSold;
            }
            set
            {
                // This line of code allows data into the property
                mIsSold = value;
            }
        }

        // Private data member for the TicketType property
        private string mTicketType;

        // TicketType public property
        public string TicketType
        {
            get
            {
                // This line of code sends data out of the property
                return mTicketType;
            }
            set
            {
                // This line of code allows data into the property
                mTicketType = value;
            }
        }

        /***find method***/

        public bool Find(int TicketId)
        {
            //Create an instance of the data connection
            clsDataConnection DB = new clsDataConnection();

            //add the parameter for the ticket id to search for 
            DB.AddParameter("@TicketId", TicketId);

            //execute the stored procedure 
            DB.Execute("sproc_tblTicket_FilterByTicketId");

            // if one record is found (there should be either one or zero)
            if (DB.Count == 1)
            {
                //copy the data from the database to the private data members 
                mTicketId = Convert.ToInt32(DB.DataTable.Rows[0]["TicketId"]);
                mDate = Convert.ToDateTime(DB.DataTable.Rows[0]["Date"]);
                mPrice = Convert.ToInt32(DB.DataTable.Rows[0]["Price"]);
                mVenue = Convert.ToString(DB.DataTable.Rows[0]["Venue"]);
                mArtist = Convert.ToString(DB.DataTable.Rows[0]["Artist"]);
                mIsSold = Convert.ToBoolean(DB.DataTable.Rows[0]["IsSold"]);
                mTicketType = Convert.ToString(DB.DataTable.Rows[0]["TicketType"]);
                //return that everything worked OK
                return true;
            }
            //if no record was found
            else
            {
                //return false including there is a problem 
                return false;
            }

            }

        public string Valid(string venue, string artist, string ticketType, string date)
        {
            //create a string variable to store the error 
            String Error = "";

            //create a temporary variable to store the date values 
            DateTime DateTemp;

            //if the Artist is blank
            if (artist.Length == 0)
            {
                //record the error 
                Error = Error + "The artist may not be blank : ";

            }

            //if the Venue is blank
            if (venue.Length == 0)
            {
                //record the error 
                Error = Error + "The venue may not be blank : ";

            }

            //if the TicketType is blank
            if (ticketType.Length == 0)
            {
                //record the error 
                Error = Error + "The ticketType may not be blank : ";

            }

            //if the artist is greater than 60 characters 
            if (artist.Length > 60)
            {
                //record the error 
                Error = Error + "The artist must be less than 60 characters : ";
            }

            //if the venue is greater than 100 characters 
            if (venue.Length > 100)
            {
                //record the error 
                Error = Error + "The venue must be less than 100 characters : ";
            }

            //if the TicketType is greater than 7 characters 
            if (ticketType.Length > 7)
            {
                //record the error 
                Error = Error + "The ticketType must be less than 7 characters : ";
            }

            //create an instance of date time to cmpare with date temp 
            //in the statements
            DateTime DateComp = DateTime.Now.Date;

            try
            {
                //copy the dateAdded value to the DateTemp variable
                DateTemp = Convert.ToDateTime(date);
                if (DateTemp < DateTime.Now.Date)
                {
                    //record the error
                    Error = Error + "The date cannot be in the past : ";
                }
                //check to see if the date is greater than today's date
                if (DateTemp > DateTime.Now.Date)
                {
                    //record the error
                    Error = Error + "The date cannot be in the future : ";

                }

            }
            catch
            {
                //record the error 
                Error = Error + "The date was not a valid date : ";
            }

            //return any error messages
            return Error;
        }

    }
}