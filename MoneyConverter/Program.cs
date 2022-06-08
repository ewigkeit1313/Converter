using MoneyConverter;

Console.WriteLine("Hello! Please enter a number between 0 and 2 billion. Possible with two decimal places. \n \n");

string InputData = Console.ReadLine();

Int64[] arrayValues = Converter.PreparingNumber(InputData);
Int64[] arrayIntegerPart = Converter.GetArray(arrayValues[0]);
Int64[] arrayDecimalPart = Converter.GetArray(arrayValues[1]);

string result = "";

for (int i = 0; i < 4; i++)
{
    if (arrayIntegerPart[i] != 0)
    {
        result += Converter.GetHungreds(arrayIntegerPart[i]);
        if (Converter.GetHungreds(arrayIntegerPart[i]) != "" && Converter.GetTens(arrayIntegerPart[i]) != "") 
        {
            result += " and ";
        }
        result += Converter.GetTens(arrayIntegerPart[i]);  
        result += Converter.arrayDigit[i, 0];
    }
}

if (string.IsNullOrEmpty(result))
    result += "0 DOLLARS ";
else
    result += " DOLLARS ";

result += Converter.GetTens(arrayDecimalPart[3]) != "" ? " AND " + Converter.GetTens(arrayDecimalPart[3]) + " CENTS " : "";

Console.WriteLine(result);
Converter.GoExitFromThisApp();
