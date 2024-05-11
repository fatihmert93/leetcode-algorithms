// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Hello, World!");

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

GC.Collect();
GC.WaitForPendingFinalizers();
long memoryBefore = GC.GetTotalMemory(true);

string x = "MCMXCIV";

var result = RomanToInt(x);
Console.WriteLine($"Result is {result == 1994} {result}, expecting is 1994");

long memoryAfter = GC.GetTotalMemory(true);

Console.WriteLine("Başlangıç Bellek: {0} bytes", memoryBefore);
Console.WriteLine("Bitiş Bellek: {0} bytes", memoryAfter);
Console.WriteLine("Kullanılan Bellek: {0} bytes", memoryAfter - memoryBefore);

stopwatch.Stop();
double milliseconds = stopwatch.ElapsedMilliseconds;


Console.WriteLine($"Runtime : {milliseconds} ms");


int RomanToInt(string s)
{
    // Dictionary<string, int> romanMap = new Dictionary<string, int>()
    // {
    //     { "I", 1 },
    //     { "V", 5 },
    //     { "X", 10 },
    //     { "L", 50 },
    //     { "C", 100 },
    //     { "D", 500 },
    //     { "M", 1000 },
    //     { "IV", 4 },
    //     { "IX", 9 },
    //     { "XL", 40 },
    //     { "XC", 90 },
    //     { "CD", 400 },
    //     { "CM", 900 }
    // };

    int sum = 0;
    int prevValue = GetValue(s[0]);

    for (int i = 1; i < s.Length; i++)
    {
        int currentValue = GetValue(s[i]);
        if (prevValue < currentValue)
        {
            sum -= prevValue;
        }
        else
        {
            sum += prevValue;
        }
        prevValue = currentValue;
    }
    sum += prevValue; // Son elemanı eklemeyi unutma

    return sum;
}

int GetValue(char c)
{
    switch (c)
    {
        case 'I': return 1;
        case 'V': return 5;
        case 'X': return 10;
        case 'L': return 50;
        case 'C': return 100;
        case 'D': return 500;
        case 'M': return 1000;
        default: throw new ArgumentOutOfRangeException("Unknown Roman numeral: " + c);
    }
}