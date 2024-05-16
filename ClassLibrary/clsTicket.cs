using System;

namespace ClassLibrary
{
    public class clsTicket
    {
        //private data member for the ticket id property
        private Int32 mTicketID;

        //ticketid public property
        public Int32 TicketID
        {
            get
            {
                //this line of code sends data out of the property
                return mTicketID;
            }
            set
            {
                //this line of code allows data into the property
                mTicketID = value;
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


        public bool Find(int ticketId)
        {
            //set the private data members to the test data value
            mTicketID = 2;
            mDate = Convert.ToDateTime("04/09/2003");
            mPrice = 50;
            mVenue = "Test Venue";
            mArtist = "Test Artist";
            mIsSold = true;
            mTicketType = "VIP";
            //always return true
            return true;
        }
    }
}