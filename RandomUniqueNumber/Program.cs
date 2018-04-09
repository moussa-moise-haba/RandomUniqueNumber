/*
 * Problem: Write a program that generates a list of 10,000 
 * numbers in random order each time it is run. 
 * Each number in the list must be unique and be between 1 and 10,000 (inclusive).
 * 
 * Author:Moussa Moise Haba
 * Date:2018-03-29
*/

#region using references
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion


namespace RandomNumberList
{

    /// <summary>
    /// Console application 
    /// </summary>
    /// <param name="args"></param>
    class Program
    {
        /// <summary>
        /// Program that generates 10,000 unique integers
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //GetUserInput();
            int methodToImplement = 0;
            //Prompt the user for which  method they wish to use
            while (methodToImplement == 0)
            {
                methodToImplement = GetUserInput();
                if (methodToImplement == -1)
                {
                    //we Exit the Program
                    System.Environment.Exit(1);
                }
            }


            //I'm using a collection instead of an array because 
            //I want to be able to search the collection to see if a number is already present

            List<Int32> listOfNumbers = new List<Int32>();
            int maximumNumber = 10000;

            switch (methodToImplement)
            {
                case 1:
                    GenerateUsingDuplicateCheck(ref listOfNumbers, maximumNumber);
                    break;
                case 2:
                    GenerateUsingRemoveBallFromBowl(ref listOfNumbers, maximumNumber);
                    break;

                default:
                    // Do nothing
                    break;
            }

            //Now that we have the collection of unique,randomly generated numbers,
            //we can ouput them for String.Format
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
            Console.WriteLine("Here is the collection of " + maximumNumber.ToString() + " random numbers");

            foreach (int number in listOfNumbers)
            {
                Console.WriteLine("\t" + String.Format(CultureInfo.InvariantCulture, "{0:0,0}", number));
            }

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nPlease press return to finish the program\n");
            Console.ReadLine();
        }

        /// <summary>
        /// this method will add a random number in the list after each itteration
        /// it will take a time, a lot of time specialy for 10.000 numbers
        /// that why I use a second method 
        /// </summary>
        /// <param name="listOfNumbers">List collection of numbers that have been picked randomly</param>
        /// <param name="maximumNumber">Maximum number</param>
        private static void GenerateUsingDuplicateCheck(ref List<Int32> listOfNumbers, int maximumNumber)

        {

            Random randomNumberSequenceTimeBased = new Random();      // Random number based upon a timestamp  changed every 16 MS

            // The program is run on two different computers, at the same time, the output will be the same on both computers



            // Since the GUID is unique within the world even on different computers, and is still based upon the time generated along with a

            // machine unique identifier (the MAC address of the computer)

            // in the case of V1 of GUID renerators, , etc.

            // we will guarantee that that GUID is absolutely unique.  We can then get an absoluely unique sequence by using the Hash Code of the GUID

            // even if two computers run this program within 16 MS of each other.

            // see    Reference https://en.wikipedia.org/wiki/Universally_unique_identifier

            Random randomNumberSequenceSeedBased = new Random(Guid.NewGuid().GetHashCode());

            int randomNumber = 0;



            // Output a message so the user knows we doing something

            Console.WriteLine("\nPlease wait while I generate " + maximumNumber.ToString() + @" numbers in a random order, and eliminate duplicates");





            for (int idx = 0; idx < maximumNumber; idx++)
            {



                // Get the next random number in the random number sequence

                randomNumber = randomNumberSequenceTimeBased.Next(1, maximumNumber);



                // We wish to add the generated number to the collection, ensuring that it does not already exist in the collection



                // Check to see that the number we generated is not already in the collection

                while (listOfNumbers.Contains(randomNumber) == true)
                {

                    // Output a dot to show the user we are working

                    Console.Write(".");



                    // find another number, this one is already in the collection

                    randomNumber = randomNumberSequenceTimeBased.Next(1, maximumNumber);

                }



                Console.WriteLine("");

                // This number is not in the collection already, so add it

                listOfNumbers.Insert(idx, randomNumber);



            }

        }
        /// <summary>
        /// This method generate numbers by placing all the numbers into a bowl, and then removing a number one at time.
        /// By using this method we will elimenate a possibility of duplicate,and having to check for duplicates in returned array
        /// </summary>
        /// <param name="listOfNumbers">List collection of numbers that have been picked randomly</param>
        /// <param name="maximumNumber">Maximum number of balls to place in the bowl</param>
        private static void GenerateUsingRemoveBallFromBowl(ref List<Int32> listOfNumbers, int maximumNumber)

        {

            //  We need a collection of all the possible numbers to place into the simulated "bowl"

            List<Int32> possibleValues = new List<Int32>();



            // Generate all possible values from 1 to maximum and place them in the "bowl"

            for (Int32 index = 0; index < maximumNumber; index++)
            {

                possibleValues.Add(index + 1);

            }





            Random randomNumberSequenceTimeBased = new Random();      // Random number based upon a timestamp  changed every 16 MS

            // The program is run on two different computers, at the same time, the output will be the same on both computers



            // Since the GUID is unique within the world even on different computers, and is still based upon the time generated along with a

            // machine unique identifier (the MAC address of the computer)

            // in the case of V1 of GUID renerators, , etc.

            // we will guarantee that that GUID is absolutely unique.  We can then get an absoluely unique sequence by using the Hash Code of the GUID

            // even if two computers run this program within 16 MS of each other.

            Random randomNumberSequenceSeedBased = new Random(Guid.NewGuid().GetHashCode());

            int randNumber = 0;



            // Output a message so the user knows we doing something

            Console.WriteLine("\nPlease wait while I pick " + maximumNumber.ToString() + @" random balls from the bowl");



            // Iterate through the process by removing a random ball from the bowl, and placing it in the listOfNumbers collection

            //  As we remove balls, the number of balls remaining in the bowl gets less until it is empty and all the balls have

            //  been moved to the listOfNumbers

            for (int idx = 0; idx < maximumNumber; idx++)
            {



                // Get the next random number in the random number sequence

                randNumber = randomNumberSequenceTimeBased.Next(0, possibleValues.Count - 1);

                // the value in randomNumber represents an index into the possibleValues array



                // We want to add the generated number to the collection, ensuring that it does not already exist in the collection

                // Which we can simply do by using the randomNumber as an index into the array of possible values

                //   Once we grab that value, we'll add it to the listOfNumbers array, and then delete it from the array of possible values

                //   This will decrease the number of possible values by one, and the random number maximum by one



                // Add this number (the ball we removed from the bowl), indicated by the index to the list, to the listOfNumbers

                listOfNumbers.Add(possibleValues[randNumber]);

                // Remove the ball from the "bowl" so it can't be picked again

                possibleValues.RemoveAt(randNumber);



            }

        }

        /// <summary>
        /// This method will hep user to test the two method and display the output
        /// The user will see the differences between both of them
        /// </summary>
        /// <returns></returns>
        private static int GetUserInput()

        {

            int methodSelected = 0;

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"==========RANDOM NUMBER PROGRAM==========");

            Console.WriteLine(@"  Which method to you wish to use? ");

            Console.ResetColor();

            Console.WriteLine(@" 1) Random numbers with duplicate checking (really slow)");

            Console.WriteLine(@" 2) Random numbers with duplicate checking array usage (faster)");

            Console.WriteLine();

            Console.WriteLine(@" X) Exit program");

            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.Write(@"Please select: ");

            Console.ResetColor();

            string methodSelectedChr = Console.ReadLine();

            switch (methodSelectedChr.ToLower().Substring(0, 1))
            {

                case "1":

                case "2":

                    methodSelected = Int32.Parse(methodSelectedChr);

                    break;



                case "x":

                    methodSelected = -1;

                    break;



                default:

                    methodSelected = 0;

                    break;

            }



            return methodSelected;

        }

    }

}



