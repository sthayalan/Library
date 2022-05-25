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

//namespace BubbleSort
//{

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //create a folder called 'datafile' under the project folder(whatever name you have chosen when creating the project)
//            //put all data files (unsorted_data.csv or sorted_data.csv) inside that the 'datafiles' folder

//            var path = "../../datafiles/unsorted_data.csv"; //change file name accordingly

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

//            //now that you have first names and last names seprated in two diffrent arrays you can write codes for algorithms
//            //Searching(Sequential or Binary) Part1I Task2 and Sorting PartII Task3
//            //The tasks also asks you to measure runtime performance for algorithms you will code/write
//            //you can measure runtime in miiliseconds or Ticks or anything else you like

//            var watch = new System.Diagnostics.Stopwatch();

//            watch.Start();
//            string temp;

//            for (int j = 0; j < firstNames.Length - 1; j++)
//            {
//                for (int i = j + 1; i < firstNames.Length; i++)
//                {
//                    if (firstNames[j].CompareTo(firstNames[i]) > 0)
//                    {
//                        temp = firstNames[j];
//                        firstNames[j] = firstNames[i];
//                        firstNames[i] = temp;
//                    }
//                }
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


//            //Console.Write("\nSorted Array is: ");
//            //for (int m = 0; m < firstNames.Length; m++)
//            //{
//            //    Console.WriteLine(firstNames[m] + " ");
//            //}
//        }
//    }
//}
