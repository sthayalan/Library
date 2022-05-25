using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public abstract class User
    {
        public string Name;
        public List<Borrowing> ContentsBorrowed;

        public User()
        {
            ContentsBorrowed = new List<Borrowing>();
        }

        public User(string Name)
        {
            this.Name = Name;
            ContentsBorrowed = new List<Borrowing>();
        }

        public abstract void addBorrowing(string contentName);
        public abstract void returnBorrowing(int index);
        public abstract void renewBorrowing(int index);
        public abstract double getPenalty();
    }

    public class Student : User
    {
        double penalty = 0;
        public Student(string Name)
        {
            this.Name = Name;
        }

        public override void addBorrowing(string contentName)
        {
            if(ContentsBorrowed.Count < 5)
            {
                ContentsBorrowed.Add(new Borrowing(contentName, DateTime.Now));
            }
            else
            {
                Console.WriteLine("Not more than 5 borrowings allowed!");
            }
        }

        public override void returnBorrowing(int index)
        {
            ContentsBorrowed[index].returned = true;
        }

        public override void renewBorrowing(int index)
        {
            if (ContentsBorrowed[index].renewals == 0 && ContentsBorrowed[index].returned != true)
            {
                ContentsBorrowed[index].returnDate = ContentsBorrowed[index].returnDate.AddMonths(1);
                ContentsBorrowed[index].renewalDate = DateTime.Now;
                ContentsBorrowed[index].renewals++;
            }
            else
                Console.WriteLine("You cannot renew this borrowing - One Renewal Allowed!!");
                Console.WriteLine("Either you already returned the item or Renewal limit reached");
        }

        public override double getPenalty()
        {
            

            for(int i = 0; i < ContentsBorrowed.Count; i++)
            {
                if (ContentsBorrowed[i].returnDate < DateTime.Now && !ContentsBorrowed[i].returned && ContentsBorrowed[i].renewals == 0)
                {
                    int days = (DateTime.Now - ContentsBorrowed[i].returnDate).Days;
                    penalty += days * 5;
                }
                else if (ContentsBorrowed[i].returnDate < DateTime.Now && !ContentsBorrowed[i].returned && ContentsBorrowed[i].renewals != 0)
                {
                    int days = (DateTime.Now - ContentsBorrowed[i].renewalDate).Days;
                    penalty += days * 5;
                }
            }

            return penalty;
        }
    }

    public class Staff : User
    {
        double penalty = 0;
        public Staff(string Name)
        {
            this.Name = Name;
        }

        public override void addBorrowing(string contentName)
        {
            ContentsBorrowed.Add(new Borrowing(contentName, DateTime.Now));
        }

        public override void returnBorrowing(int index)
        {
            ContentsBorrowed[index].returned = true;
        }

        public override void renewBorrowing(int index)
        {
            for (int i = 0; i < ContentsBorrowed.Count; i++)
            {
                if (ContentsBorrowed[i].borrowDate.AddMonths(12) > ContentsBorrowed[i].returnDate)
                {
                    ContentsBorrowed[index].returnDate = ContentsBorrowed[i].returnDate.AddMonths(1);
                    ContentsBorrowed[index].renewals++;
                }
                else
                {
                    Console.WriteLine("Sorry no further renewal allowed");
                    Console.WriteLine("One year limit reached!! - Kindly return the content please");
                }
            }
                    
        }

        public override double getPenalty()
        {
            

            for (int i = 0; i < ContentsBorrowed.Count; i++)
            {
                if (ContentsBorrowed[i].returnDate < DateTime.Now && !ContentsBorrowed[i].returned && ContentsBorrowed[i].borrowDate.AddMonths(12) > ContentsBorrowed[i].returnDate)
                {
                    int days = (DateTime.Now - ContentsBorrowed[i].returnDate).Days;
                    penalty += days * 5;
                }
                //if (ContentsBorrowed[i].renewalDate > ContentsBorrowed[i].returnDate)
                //{
                //    double days = (ContentsBorrowed[i].renewalDate - ContentsBorrowed[i].returnDate).TotalDays;
                //    penalty += days * 5;
                //}
            }

            return penalty;
        }
    }
}
