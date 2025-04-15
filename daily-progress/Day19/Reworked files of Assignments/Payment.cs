using System;
using System.Collections.Generic;

namespace StudentInformationSystem
{
    // Creating Payment class [TASK-1]
    public class Payment
    {
        public int PaymentID { get; set; }
        public Student Student { get; set; }  // Linking to Student object, Already implemented in Task one [TASK-5]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Constructor implementation [TASK-2]
        public Payment(int paymentId, Student student, decimal amount, DateTime paymentDate)
        {
            //updating constructor(excep)
            if (amount <= 0)
                throw new PaymentValidationException("Payment amount must be greater than zero");

            if (paymentDate > DateTime.Now)
                throw new PaymentValidationException("Payment date cannot be in the future");

            this.PaymentID = paymentId;
            this.Student = student;
            this.Amount = amount;
            this.PaymentDate = paymentDate;
        }

        // 1)Retrieves student associated with the payment [TASK-3]
        public Student GetStudent()
        {
            return Student;
        }

        // 2)Retrieves payment amount [TASK-3]
        public decimal GetPaymentAmount()
        {
            return Amount;
        }

        // 3)Retrieves payment date [TASK-3]
        public DateTime GetPaymentDate()
        {
            return PaymentDate;
        }
    }
}
