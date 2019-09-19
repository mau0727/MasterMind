using System;
using System.Collections.Generic;

namespace MasterMind
{
    class Program
    {
        private int CorrectNumbers;
        private int MidCorrectNumbers;
        private int Lives;
        private string UserInput;
        private bool DidUserWin;
        public Program()
        {
            CorrectNumbers = 0;
            MidCorrectNumbers = 0;
            Lives = 10;
            UserInput = string.Empty;
            DidUserWin = false;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.RunProgram();

        }

        public void RunProgram()
        {
            Console.WriteLine("Press a Key To Generate the four numbers Master Code");
            Console.ReadKey();Console.WriteLine();
            var listOfNumbers = GenerateNumbers();
            while(Lives > 0)
            {
                bool isInputValid = false;
                while (!isInputValid)
                {
                    Console.WriteLine("Enter The four Digit you think were generated you Have {0} lives",Lives);
                    UserInput = Console.ReadLine();
                    isInputValid = ValidateInput(UserInput);
                }
                CalculateResults(listOfNumbers, UserInput);
                PrintResults(MidCorrectNumbers, false);
                PrintResults(CorrectNumbers);
                DidUserWin = CheckResults();
                Console.WriteLine();
            }

            string result  = DidUserWin ?"You Won!":"You Lost!";
            Console.WriteLine(result);

        }

        private bool ValidateInput(string code)
        {
            int intValue;
            if (code.Length == 4 && Int32.TryParse(code, out intValue))
            { return true; }

            Console.WriteLine("Incorrect Input -> The Input can only be numeric and it has to be exactly 4 digits");
            return false;

        }

        private List<string> GenerateNumbers()
        {
            var listOfRandomNumbers = new List<string>();
            Random randomGenerator = new Random();

            for (int x = 0; x < 4; x++)
            {
                listOfRandomNumbers.Add(randomGenerator.Next(1, 7).ToString());
            }
            return listOfRandomNumbers;
        }

        private void CalculateResults(List<string> numberCodes, string CodeEnteredByUser)
        {

            for (int i = 0; i < numberCodes.Count; i++)
            {
                var t = CodeEnteredByUser[i].ToString();
                var y = numberCodes[i];
                if (CodeEnteredByUser[i].ToString().Equals(numberCodes[i]))
                {
                    CorrectNumbers++;
                }
                else if (numberCodes.Contains(CodeEnteredByUser[i].ToString()))
                {
                    MidCorrectNumbers++;
                }
            }
        }

        private void PrintResults(int amountOfTimes, bool correct = true)
        {
            string stringToPrint = correct ? "+ " : "- ";
            for(int x = amountOfTimes; x > 0; x -- )
            {
                Console.Write(stringToPrint);
            }
        }

        private bool CheckResults()
        {
            if (CorrectNumbers == 4)
            {
                Lives = 0;
                return true;
            }

            Lives--;
            MidCorrectNumbers = 0;
            CorrectNumbers = 0;
            UserInput = string.Empty;
            return false;
        }


        
    }
}
