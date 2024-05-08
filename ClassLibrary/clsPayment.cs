using System;

namespace ClassLibrary
{
    public class clsPayment
    {

        public int paymentID { get; set; }
        public string transactionID { get; set; }
        public double amount { get; set; }
        public DateTime paymentDate { get; set; }
        public bool isPaymentSuccessful { get; set; }
        public string paymentMethod { get; set; }
        public int ticketId { get; set; }
    }
}