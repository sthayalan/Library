using System;
namespace LibraryManagementSystem
{
    public class Contents
    {
        public string Name;
        public string Author;

        public Contents()
        {
            
        }

        public Contents(string n, string a)
        {
            this.Name = n;
            this.Author = a;
        }
    }
}
