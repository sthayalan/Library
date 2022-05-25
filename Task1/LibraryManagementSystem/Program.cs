using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryManagementSystem
{
    class Program
    {
        public static List<Contents> Books = new List<Contents>();
        public static List<Contents> Articles = new List<Contents>();
        public static List<Contents> DigitalMedia = new List<Contents>();
        public static List<Student> students = new List<Student>();
        public static List<Staff> staff = new List<Staff>();

        static void Main(string[] args)
        {
            GetLibraryData();
            students.Add(new Student("John Smith"));
            staff.Add(new Staff("Peter Parker"));

            Console.WriteLine("Welcome to Library System!");
            Console.WriteLine("1. Continue as Admin");
            Console.WriteLine("2. Continue as User");

            string input = Console.ReadLine();
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Invalid Choice!");
                Console.WriteLine("1. Continue as Admin");
                Console.WriteLine("2. Continue as User");
                input = Console.ReadLine();
            }

            if (input == "1")
                AdminMenu();
            else
            {
                User user = null;
                Console.WriteLine("Please Enter your Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Please Enter your Role (Student/Staff): ");
                string role = Console.ReadLine();
                while (role != "Student" && role != "student" && role != "Staff" && role != "staff")
                {
                    Console.WriteLine("Invalid Choice!");
                    Console.WriteLine("Please Enter your Role (Student/Staff): ");
                    role = Console.ReadLine();
                }

                if (role == "Student" || role == "student")
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].Name == name)
                        {
                            user = students[i];
                        }
                    }
                    if (user == null)
                    {
                        user = new Student(name);
                    }

                }
                else if (role == "Staff" || role == "staff")
                {
                    for (int i = 0; i < staff.Count; i++)
                    {
                        if (staff[i].Name == name)
                        {
                            user = staff[i];
                        }
                    }
                    if (user == null)
                    {
                        user = new Staff(name);
                    }

                }
                UserMenu(user);
            }
        }

        public static void AdminMenu()
        {
            Console.WriteLine("\n\n1. Show all Library Contents");
            Console.WriteLine("2. Add Library Contents");
            Console.WriteLine("3. Remove Library Contents");

            string input = Console.ReadLine();
            while (input != "1" &&input != "2" && input != "3")
            {
                Console.WriteLine("Invalid Choice!");
                Console.WriteLine("1. Show all Library Contents");
                Console.WriteLine("2. Add Library Contents");
                Console.WriteLine("3. Remove Library Contents");
                input = Console.ReadLine();
            }
            if(input == "1")
            {
                Console.WriteLine("Books: ");
                for(int i = 0; i < Books.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Books[i].Name + " by " + Books[i].Author);
                }

                Console.WriteLine("\nArticles: ");
                for (int i = 0; i < Articles.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Articles[i].Name + " by " + Articles[i].Author);
                }

                Console.WriteLine("\nDigitalMedia: ");
                for (int i = 0; i < DigitalMedia.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + DigitalMedia[i].Name + " by " + DigitalMedia[i].Author);
                }
            }
            else if(input == "2")
            {
                Console.WriteLine("Please enter Name of the Content: ");
                string name = Console.ReadLine();

                Console.WriteLine("Please enter author name of the content: ");
                string author = Console.ReadLine();

                Console.WriteLine("Please select type: ");
                Console.WriteLine("1. Book");
                Console.WriteLine("2. Article");
                Console.WriteLine("3. Digital Media");

                string choice = Console.ReadLine();
                while (choice != "1" && choice != "2" && choice != "3")
                {
                    Console.WriteLine("Invalid Choice!");
                    Console.WriteLine("Please select type: ");
                    Console.WriteLine("1. Book");
                    Console.WriteLine("2. Article");
                    Console.WriteLine("3. Digital Media");

                    choice = Console.ReadLine();
                }
                if (choice == "1")
                {
                    Books.Add(new Contents(name, author));
                }
                else if (choice == "2")
                {
                    Articles.Add(new Contents(name, author));
                }
                else if (choice == "3")
                {
                    DigitalMedia.Add(new Contents(name, author));
                }
            }
            else if(input == "3")
            {
                Console.WriteLine("Please select type which you want to delete: ");
                Console.WriteLine("1. Book");
                Console.WriteLine("2. Article");
                Console.WriteLine("3. Digital Media");

                string choice = Console.ReadLine();
                while (choice != "1" && choice != "2" && choice != "3")
                {
                    Console.WriteLine("Invalid Choice!");
                    Console.WriteLine("Please select type which you want to delete: ");
                    Console.WriteLine("1. Book");
                    Console.WriteLine("2. Article");
                    Console.WriteLine("3. Digital Media");

                    choice = Console.ReadLine();
                }
                if (choice == "1")
                {
                    Console.WriteLine("Enter name of the Content: ");
                    string name = Console.ReadLine();

                    int index = -1;
                    for(int i = 0; i < Books.Count; i++)
                    {
                        if(Books[i].Name == name)
                        {
                            index = i;
                            break;
                        }
                    }

                    if(index != -1)
                    {
                        Books.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("No Book found against the given Name.");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter name of the Content: ");
                    string name = Console.ReadLine();

                    int index = -1;
                    for (int i = 0; i < Articles.Count; i++)
                    {
                        if (Articles[i].Name == name)
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index != -1)
                    {
                        Articles.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("No Article found against the given Name.");
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Enter name of the Content: ");
                    string name = Console.ReadLine();

                    int index = -1;
                    for (int i = 0; i < DigitalMedia.Count; i++)
                    {
                        if (DigitalMedia[i].Name == name)
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index != -1)
                    {
                        DigitalMedia.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("No Digital Media found against the given Name.");
                    }
                }
            }
            AdminMenu();
        }

        public static void UserMenu(User user)
        {
            Console.WriteLine("\n\n1. Borrow");
            Console.WriteLine("2. Return");
            Console.WriteLine("3. Borrowing History");

            string input = Console.ReadLine();
            while (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("Invalid Choice!");
                Console.WriteLine("1. Borrow");
                Console.WriteLine("2. Return");
                Console.WriteLine("3. Borrowing History");
                input = Console.ReadLine();
            }

            if(input == "1")
            {
                Console.WriteLine("Please select type: ");
                Console.WriteLine("1. Book");
                Console.WriteLine("2. Article");
                Console.WriteLine("3. Digital Media");

                string choice = Console.ReadLine();
                while (choice != "1" && choice != "2" && choice != "3")
                {
                    Console.WriteLine("Invalid Choice!");
                    Console.WriteLine("Please select type: ");
                    Console.WriteLine("1. Book");
                    Console.WriteLine("2. Article");
                    Console.WriteLine("3. Digital Media");

                    choice = Console.ReadLine();
                }
                if (choice == "1")
                {
                    for (int i = 0; i < Books.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + Books[i].Name + " by " + Books[i].Author);
                    }
                    Console.WriteLine("Enter choice you want to borrow: ");
                    string index = Console.ReadLine();
                    while(tryParse(index) < 0 || tryParse(index) >= Books.Count + 1)
                    {
                        Console.WriteLine("Invalid Choice!");
                        for (int i = 0; i < Books.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + Books[i].Name + " by " + Books[i].Author);
                        }
                        Console.WriteLine("Enter choice you want to borrow: ");
                        index = Console.ReadLine();
                    }

                    user.addBorrowing(Books[int.Parse(index) - 1].Name);
                }
                else if (choice == "2")
                {
                    for (int i = 0; i < Articles.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + Articles[i].Name + " by " + Articles[i].Author);
                    }
                    Console.WriteLine("Enter choice you want to borrow: ");
                    string index = Console.ReadLine();
                    while (tryParse(index) < 0 || tryParse(index) >= Articles.Count + 1)
                    {
                        Console.WriteLine("Invalid Choice!");
                        for (int i = 0; i < Articles.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + Articles[i].Name + " by " + Articles[i].Author);
                        }
                        Console.WriteLine("Enter choice you want to borrow: ");
                        index = Console.ReadLine();
                    }

                    user.addBorrowing(Articles[int.Parse(index) - 1].Name);
                }
                else if (choice == "3")
                {
                    for (int i = 0; i < DigitalMedia.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + DigitalMedia[i].Name + " by " + DigitalMedia[i].Author);
                    }
                    Console.WriteLine("Enter choice you want to borrow: ");
                    string index = Console.ReadLine();
                    while (tryParse(index) < 0 || tryParse(index) >= DigitalMedia.Count + 1)
                    {
                        Console.WriteLine("Invalid Choice!");
                        for (int i = 0; i < DigitalMedia.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + DigitalMedia[i].Name + " by " + DigitalMedia[i].Author);
                        }
                        Console.WriteLine("Enter choice you want to borrow: ");
                        index = Console.ReadLine();
                    }

                    user.addBorrowing(DigitalMedia[int.Parse(index) - 1].Name);
                }
            }
            else if(input == "2")
            {
                int counter = 0;
                Console.WriteLine("Your borrowings for return: ");
                for(int i = 0; i < user.ContentsBorrowed.Count; i++)
                {
                    if (!user.ContentsBorrowed[i].returned)
                    {
                        Console.WriteLine((i + 1) + ". " + user.ContentsBorrowed[i]);
                        counter++;
                    }
                    
                }
                if (counter >0)
                {
                    Console.WriteLine("Please enter a choice: ");
                    string choice = Console.ReadLine();
                
                    while (tryParse(choice) < 0 || tryParse(choice) >= user.ContentsBorrowed.Count + 1)
                    {
                        Console.WriteLine("Invalid Choice!");
                        Console.WriteLine("Please enter a choice: ");
                        choice = Console.ReadLine();
                    }
                    user.returnBorrowing(int.Parse(choice) - 1);
                }
                else
                {
                    Console.WriteLine("Hurray!! - Nothing to Return");
                }
            }
            else if(input == "3")
            {
                Console.WriteLine("Your borrowings: ");
                for (int i = 0; i < user.ContentsBorrowed.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + user.ContentsBorrowed[i]);
                }
                Console.WriteLine("Penalty Amount: $" + user.getPenalty());
                if(user.ContentsBorrowed.Count > 0)
                {
                    Console.WriteLine("Would you like to renew a book? (Y/N)");
                    string in1 = Console.ReadLine();
                    while (in1 != "Y" && in1 != "y" && in1 != "N" && in1 != "n"){
                        Console.WriteLine("Invalid Choice!");
                        in1 = Console.ReadLine();
                    }
                    if(in1 == "Y" || in1 == "y")
                    {
                        Console.WriteLine("Please enter book (#) for renewal! ");
                        string str = Console.ReadLine();
                        while (int.Parse(str) < 0 && int.Parse(str) > user.ContentsBorrowed.Count)
                        {
                            Console.WriteLine("Invalid Choice!");
                            str = Console.ReadLine();
                        }
                        user.renewBorrowing(int.Parse(str) - 1);
                    }
                }
             
            }
            UserMenu(user);
        }

        public static void GetLibraryData()
        {
            string[] lines = File.ReadAllLines(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "../../../../Data.txt");

            foreach (string line in lines)
            {
                string[] arr = line.Split(',');
                string name = arr[1];
                string author = arr[2];
                if (arr[0] == "Book")
                    Books.Add(new Contents(name, author));
                else if (arr[0] == "Article")
                    Articles.Add(new Contents(name, author));
                else if (arr[0] == "Digital Media")
                    DigitalMedia.Add(new Contents(name, author));
                else
                    Console.WriteLine("Invalid Data format found in File");
            }
            Console.WriteLine("Library Data Import Sucessful");
        }

        public static int tryParse(string input)
        {
            try
            {
                return int.Parse(input);
            } catch(Exception e)
            {
                return -1;
            }
        }
    }
}
