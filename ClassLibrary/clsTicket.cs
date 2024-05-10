using System;

namespace ClassLibrary
{
    public class clsTicket
    {
        public int TicketID { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string Venue { get; set; }
        public string Artist { get; set; }
        public bool IsSold { get; set; }
        public string TicketType { get; set; }
    }
}