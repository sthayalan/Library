﻿
///* this file is skeleton code for Task 2 and Task 3. Given just as a guide.*/
///* you may directly copy the skeleton code into your project(program.cs file)*/
///* and write  codes for algorithms given in assignment brief                 */
///* wrritten by Manish Singh mansih.singh@weltec.ac.nz*/

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;                                    //add this 

//namespace Search
//{

//    class SearchBinary
//    {
//        static void Main(string[] args)
//        {
//            //create a folder called 'datafile' under the project folder(whatever name you have chosen when creating the project)
//            //put all data files (unsorted_data.csv or sorted_data.csv) inside that the 'datafiles' folder

//            var path = "../../datafiles/sorted_data.csv"; //change file name accordingly

//            // checking if file exists

//            if (!File.Exists(path))
//            {

//                Console.WriteLine("File not found, Check path");

//            }

//            //reading data from the file.
//            string[] lines = System.IO.File.ReadAllLines(path);

//            //declaring two strings arrays to hold lastname and firstname
//            string[] lastNames = new string[lines.Length];
//            string[] firstNames = new string[lines.Length];

//            //break lines into lastnames and firstnames
//            for (int i = 0; i < lines.Length; i++)
//            {

//                firstNames[i] = lines[i].Split(",")[0];
//                lastNames[i] = lines[i].Split(",")[1];
//            }

//            Console.WriteLine("Please enter the Last Name to search: ");
//            string Name = Console.ReadLine();
//            int found = 0;

//            //now that you have first names and last names seprated in two diffrent arrays you can write codes for algorithms
//            //Searching(Sequential or Binary) Part1I Task2 and Sorting PartII Task3
//            //The tasks also asks you to measure runtime performance for algorithms you will code/write
//            //you can measure runtime in miiliseconds or Ticks or anything else you like

//            var watch = new System.Diagnostics.Stopwatch();

//            watch.Start();

//            found = binarySearch(lastNames, Name);

//            if (found > -1)
//            {
//                Console.WriteLine("Name found: " + Name);
//            }
//            else
//            {
//                Console.WriteLine("Name not found!");
//            }
//            /* 
//             * 
//             * write codes for your searching for Task 2 or sorting for Task 3 algorithms here
//             * 
//             *  
//             */


//            watch.Stop();

//            //print ElapsedTicks or EllampsedMilliseconds
//            Console.WriteLine($"Execution Time: {watch.ElapsedTicks} Ticks");


//        }

//        static int binarySearch(String[] arr, String x)
//        {
//            int l = 0, r = arr.Length - 1;
//            while (l <= r)
//            {
//                int m = l + (r - l) / 2;

//                int res = x.CompareTo(arr[m]);

//                if (res == 0)
//                    return m;

//                if (res > 0)
//                    l = m + 1;

//                else
//                    r = m - 1;
//            }

//            return -1;
//        }
//    }
//}
