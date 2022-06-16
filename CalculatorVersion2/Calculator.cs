using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CalculatorVersion2
{
    public class Calculator
    {
        public static Calculator myCal = new Calculator();

        public static List<double> userInputs = new List<double>();
        public static List<string> CalculationHistory = new List<string>();
        public static List<double> numbersList = new List<double>();
        public static List<string> operatorList = new List<string>();

        public static int oneNumberCatch;

        public static double input;
        public static double input1;
        public static double input2;
        public static double result;
        public static double resultSavedInMemory = 0;
        public static double calculationBreakdown;


        public static double storeNumber1 = 0;
        public static double storeNumber2 = 0;
        public static double storeNumber3 = 0;
        public static double storeNumber4 = 0;

        public static string operatorString;
        public static string calculationInput;
        public static string resultString;
        public static string calcFormString;
        public static string numberHolder;
        public static string saveResult;

        public static bool mainMenu = true;
        public static bool calcFormMenu = true;
        public static bool userInputBool = true;
        public static bool SaveResultMeny = true;
        public static bool storedResults = true;


        public static void MainMenu()
        {

            while (mainMenu)
            {

                Console.WriteLine("-----------------------   Calculator   -----------------------\n\n1. Calculate \n2. Calculate History\n3. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        UserInputs();
                        CalculationMenu();
                        break;
                    case "2":
                        PrintCalcHistory();
                        break;
                    case "3":
                        Exit();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
        public static void UserInputs()
        {
            Console.Clear();
            storedResults = true;
            oneNumberCatch = 0;
            while (userInputBool)
            {
                if (resultSavedInMemory != 0 && storedResults)
                {

                    while (storedResults)
                    {


                        Console.WriteLine($"Would you like to use your stored result ({resultSavedInMemory}) in this calculation?\n1. Yes\n2. No");
                        string UseSavedResult = Console.ReadLine();

                        if (UseSavedResult == "1")
                        {

                            Console.WriteLine($"You pressed yes, adding {resultSavedInMemory} to you current calculation and clearing the saved result from the stored memory");

                            userInputs.Add(resultSavedInMemory);
                            resultSavedInMemory = 0;
                            oneNumberCatch = 1;
                            storedResults = false;
                        }
                        else if (UseSavedResult == "2")
                        {
                            storedResults = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Try again...\n");
                        }

                    }
                }


                Console.Write("Enter a number: ");

                string inputUSer = Console.ReadLine();

                if (inputUSer == "" && (oneNumberCatch > 1))
                {
                    userInputBool = false;

                }
                if (double.TryParse(inputUSer, out input))
                {
                    oneNumberCatch++;
                    userInputs.Add(input);

                }
                if (!double.TryParse(inputUSer, out input))
                {
                    Console.WriteLine("Please enter a number!");
                }

                else if (oneNumberCatch < 1)
                {
                    Console.WriteLine("Please enter aleast 2 numbers");
                }


            }
            Console.Clear();
            userInputBool = true;


        }
        public static void UserInputsWithStrings()
        {
            Console.Clear();
            Console.Write("Please write your whole calculation: ");
            calculationInput = Console.ReadLine();

        } // Not finnished
        public static void CalculationStringHandler()
        {

            numberHolder = "";

            for (int i = 0; i < calculationInput.Length; i++)
            {
                Console.WriteLine(i + " = antal loopar");
                Console.WriteLine(calculationInput[i]);
                if (char.IsDigit(calculationInput, i))
                {
                    numberHolder += calculationInput[i];

                }
                if (calculationInput[i] == 43
                 || calculationInput[i] == 45
                 || calculationInput[i] == 47
                 || calculationInput[i] == 42
                 || calculationInput.Length - 1 == i)

                {
                    numbersList.Add(Convert.ToDouble(numberHolder));
                    numberHolder = "";
                    if (calculationInput[i] == 43)
                    {
                        operatorList.Add(Convert.ToString("+"));
                    }
                    else if (calculationInput[i] == 45)
                    {
                        operatorList.Add(Convert.ToString("-"));
                    }
                    else if (calculationInput[i] == 47)
                    {
                        operatorList.Add(Convert.ToString("/"));
                    }
                    else if (calculationInput[i] == 42)
                    {
                        operatorList.Add(Convert.ToString("*"));
                    }
                }
            }

            foreach (var item in numbersList)
            {
                Console.WriteLine(item);
            }

            foreach (var item in operatorList)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
            for (int i = 0; i < operatorList.Count; i++)
            {
                storeNumber1 = 0;
                storeNumber2 = 0;
                storeNumber3 = 0;
                storeNumber4 = 0;

                switch (operatorList[i])
                {
                    case "+":
                        storeNumber1 = numbersList[i] + numbersList[i + 1];
                        numbersList.RemoveAt(i);
                        break;
                    case "-":
                        storeNumber2 = numbersList[i] - numbersList[i + 1];
                        numbersList.RemoveAt(i);
                        numbersList.RemoveAt(i + 1);
                        break;
                    case "/":
                        storeNumber3 = numbersList[i] / numbersList[i + 1];
                        numbersList.RemoveAt(i);
                        numbersList.RemoveAt(i + 1);
                        break;
                    case "*":
                        storeNumber4 = numbersList[i] * numbersList[i + 1];
                        numbersList.RemoveAt(i);
                        numbersList.RemoveAt(i + 1);
                        break;
                    default:
                        break;
                }

                double resultTest = storeNumber1;
            }








            Console.ReadLine();

        } // Not finnished
        public static void CalculationMenu()
        {
            
            while (calcFormMenu)
            {
                Console.WriteLine("Choose your from of calculation\n1. Addition (+)\n2. Subtraction (-)\n3. Division(/)\n4. Multiplication(*)");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        myCal.Addition(userInputs);
                        myCal.StoreCalculation("+", userInputs,result);
                        PrintResult();
                        calcFormMenu = false;

                        break;
                    case "2":
                        Console.Clear();
                        myCal.Subtraction(userInputs);
                        myCal.StoreCalculation("-", userInputs, result);
                        PrintResult();
                        calcFormMenu = false;
                        break;
                    case "3":
                        Console.Clear();
                        myCal.Division(userInputs);
                        myCal.StoreCalculation("/", userInputs, result);
                        PrintResult();
                        calcFormMenu = false;
                        break;
                    case "4":
                        Console.Clear();
                        myCal.Multiplication(userInputs);
                        myCal.StoreCalculation("*", userInputs, result);
                        PrintResult();
                        calcFormMenu = false;
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            }
            calcFormMenu = true;
        }
        //----------------------------------------------------------
        public double Addition(List<double> inputList)
        {
            userInputs = inputList;


            foreach (var item in userInputs)
            {
                result += item;
            }
            return result;

        }
        public double Subtraction(List<double> inputList)
        {
            userInputs = inputList;

            result = userInputs[0];

            for (int i = 1; i < userInputs.Count; i++)
            {
                result -= userInputs[i];
            }
            return result;
        }
        public double Multiplication(List<double> inputList)
        {
            userInputs = inputList;
            result = userInputs[0];

            for (int i = 1; i < userInputs.Count; i++)
            {
                result *= userInputs[i];
            }
            return result;
        }
        public double Division(List<double> inputList)
        {
            userInputs = inputList;
            result = userInputs[0];

            for (int i = 1; i < userInputs.Count; i++)
            {
                result /= userInputs[i];
            }
            return result;
        }
        //----------------------------------------------------------
        public static void PrintResult()
        {
            Console.WriteLine($"Your calculation: {resultString} \nPress enter to go back to menu...");
            Console.ReadLine();

            myCal.SaveResultInMemory(result);




            resultString = "";
            userInputs.Clear();
            result = 0;
            Console.Clear();
        }
        public string StoreCalculation(string calcOperator, List<double> inputList, double tempResult)
        {
            userInputs = inputList;
            calcFormString = calcOperator;
            result = tempResult;

            for (int i = 0; i < userInputs.Count; i++)
            {
                if (i < (userInputs.Count - 1))
                {
                    operatorString = calcFormString;
                }
                else
                {
                    operatorString = "";
                }

                resultString += $"{userInputs[i]} {operatorString} ";
            }

            resultString += $"= {result}";
            CalculationHistory.Add(resultString);

            return resultString;


        }
        public double SaveResultInMemory(double tempResult)
        {
            result = tempResult;

            if (resultSavedInMemory == 0)
            {
                while (SaveResultMeny)
                {
                    Console.WriteLine($"By the way!\nWould you like to save this result to use for later?\n1. Yes\n2. No");
                    saveResult = Console.ReadLine();
                    if (saveResult == "1")
                    {
                        resultSavedInMemory = result;
                        Console.WriteLine($"You pressed yes, saving result ({resultSavedInMemory}) in memory...\nPress Enter to go back to menu");
                        Console.ReadLine();

                        break;
                    }
                    else if (saveResult == "2")
                    {
                        Console.WriteLine($"You pressed no, going back to meny...");
                        Thread.Sleep(2000);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Try again...\n");

                    }
                }
            }

            return result;
        }
        public static void PrintCalcHistory()
        {
            Console.Clear();
            if (CalculationHistory.Count > 0)
            {
                Console.WriteLine("Calculation History \n");
                foreach (string item in CalculationHistory)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\nPress enter to go back to menu...");
            }
            else
            {
                Console.WriteLine("No results was found!\nPress enter to go back to menu...");
            }
            Console.ReadLine();
            Console.Clear();
        }
        public static void Exit()
        {
            mainMenu = false;
            Console.WriteLine("The application is shutting down...");
            Thread.Sleep(3000);
        }



    }
}
