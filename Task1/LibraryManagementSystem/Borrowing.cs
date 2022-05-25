using System;
namespace LibraryManagementSystem
{
    public class Borrowing
    {
        public string Name;
        public DateTime borrowDate;
        public DateTime returnDate;
        public DateTime renewalDate;
        public int renewals;
        public bool returned;

        public Borrowing()
        {
        }

        public Borrowing(string name, DateTime date)
        {
            Name = name;
            borrowDate = date.AddDays(-32);
            returnDate = borrowDate.AddMonths(1);
            renewals = 0;
            returned = false;
        }

        public override string ToString()
        {
            return ("Name: " + Name + "\t Borrow Date: " + borrowDate + "\t Return Date:" + returnDate + "\t Renewals: " + renewals + "\t Returned: " + returned);
        }
    }
}
