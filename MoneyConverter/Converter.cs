namespace MoneyConverter
{
    public abstract class Converter
    {
        static Dictionary<int, string> Hundreds = new Dictionary<int, string>()
        {
            { 0, " "},
            { 1, " one hundred"},
            { 2, " two hundred"},
            { 3, " three hundred"},
            { 4, " four hundred"},
            { 5, " five hundred"},
            { 6, " six hundred"},
            { 7, " seven hundred"},
            { 8, " eight hundred"},
            { 9, " nine hundred"}
        };

        public static Dictionary<int, string> TenToNineteen = new Dictionary<int, string>()
        {
            { 0, ""},
            { 10, " ten " },
            { 11, " eleven " },
            { 12, " twelve " },
            { 13, " thitrteen " },
            { 14, " fourteen " },
            { 15, " fiveteen " },
            { 16, " sixteen " },
            { 17, " seventeen " },
            { 18, " eightteen " },
            { 19, " nineteen " }
        };

        public static Dictionary<int, string> OneToNine = new Dictionary<int, string>()
        {
            { 0, ""},
            { 1, " one" },
            { 2, " two" },
            { 3, " three" },
            { 4, " four" },
            { 5, " five" },
            { 6, " six" },
            { 7, " seven" },
            { 8, " eight" },
            { 9, " nine" },
        };

        public static Dictionary<int, string> Tens = new Dictionary<int, string>()
        {
            { 0, ""},
            { 2, "twenty" },
            { 3, "thirty" },
            { 4, "forty" },
            { 5, "fifty" },
            { 6, "sixty" },
            { 7, "seventy" },
            { 8, "eighty" },
            { 9, "ninety" },
        };

        public static string[,] arrayDigit = new string[4, 1] {
            { " billion, " },
            { " million, " },
            { " thousand, "},
            { "" }
        };

        public static string GetTens(Int64 value)
        {
            string resultString = "";
            if (((value % 100) - ((value % 100) % 10)) / 10 != 1)
            {
                resultString += Tens.Single(x => x.Key == ((value % 100) - ((value % 100) % 10)) / 10).Value;
                resultString += OneToNine.Single(x => x.Key == value % 10).Value;
            }
            else
            {
                resultString += TenToNineteen.Single(x => x.Key == value % 100).Value;
            }
            return resultString;
        }

        public static string GetHungreds(Int64 value)
        {
            string resultString = "";
            if (((value - (value % 100)) / 100) != 0)
                resultString += Hundreds.Single(x => x.Key == ((value - (value % 100)) / 100)).Value;

            return resultString;
        }

        public static void GoExitFromThisApp()
        {
            Console.WriteLine(" \n \n \n Press any key to exit! Have a nice day =)");
            Console.ReadKey();
        }

        public static void ReturnError() 
        {
            Console.WriteLine("You can only enter numbers from 0 to 2 billion with two decimal places.");
            GoExitFromThisApp();
            Environment.Exit(-1);
        }


        public static Int64[] PreparingNumber(string InputData)
        {
            float number = 0;

            if (!String.IsNullOrEmpty(InputData))
            {
                if (InputData.Contains('.'))
                    InputData = InputData.Replace('.', ',');

                if (!InputData.Contains(','))
                {
                    InputData = InputData += ",00";
                }

                InputData = InputData.Replace(" ", "");
            }
            else
            {
                ReturnError();
            }

            if (!float.TryParse(InputData, out number))
            {
                ReturnError();
            }

            if (number == 0)
            {
                Console.WriteLine("zero. Sorry...");
                GoExitFromThisApp();
                Environment.Exit(0);
            }

            String[] resultArray = InputData.Split(",");

            if (resultArray[0] == "")
            {
                resultArray[0] = "0";
            }

            if (resultArray[1].Length > 2)
            {
                ReturnError();
            }

            Int64 integerPart = Int64.Parse(resultArray[0]);
            Int64 decimalPart = int.Parse(resultArray[1]);

            if (integerPart > 2000000000 || integerPart < 0)
            {
                ReturnError();
            }

            Int64[] ArrayIntegerAndDecimal = new Int64[2];
            ArrayIntegerAndDecimal[0] = integerPart;
            ArrayIntegerAndDecimal[1] = decimalPart;

            return ArrayIntegerAndDecimal;
        }

        public static Int64[] GetArray(Int64 number)
        {
            Int64[] arrayInt = new Int64[4];
            arrayInt[0] = (number - (number % 1000000000)) / 1000000000;
            arrayInt[1] = ((number % 1000000000) - (number % 1000000)) / 1000000;
            arrayInt[2] = ((number % 1000000) - (number % 1000)) / 1000;
            arrayInt[3] = number % 1000;

            return arrayInt;
        }
    }
}
