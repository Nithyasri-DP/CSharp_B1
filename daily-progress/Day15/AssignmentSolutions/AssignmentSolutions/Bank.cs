using System;
namespace AssignmentSolutions
{
    //userdefined exception
    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
    class BankAccount
    {
        public string OwnerName { get; set; }
        public decimal Balance { get; private set; }
        //constructor
        public BankAccount(string ownerName, decimal initialBalance)
        {
            OwnerName = ownerName;
            Balance = initialBalance;
        }
        //transferring process
        public void TransferFunds(decimal amount)
        {
            Console.WriteLine($"\nAccount Holder: {OwnerName}");
            Console.WriteLine($"Current Balance: {Balance}");
            if (amount > Balance)
                throw new InsufficientFundsException("Transfer failed: Insufficient funds.");
            Balance -= amount;
            Console.WriteLine($"Transfer successful! Transferred Amount: {amount}");
            Console.WriteLine($"Remaining Balance: {Balance}");
        }
    }
    //main class
    class Bank
    {
        internal static void Fundtransfer()
        {
            String? ownerName = "Anu";
            BankAccount account = new BankAccount(ownerName, 5000);
            Console.Write("Enter amount to transfer: ");
            decimal transferAmount = Convert.ToDecimal(Console.ReadLine());
            //exception handling
            try
            {
                account.TransferFunds(transferAmount);
            }
            catch (InsufficientFundsException ex)
            {
              Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
