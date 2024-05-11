// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Hello, World!");


Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

GC.Collect();
GC.WaitForPendingFinalizers();
long memoryBefore = GC.GetTotalMemory(true);

int x = 1211218;

var result = IsPalindrome(x);
Console.WriteLine($"Result is {result}, expecting is true");

long memoryAfter = GC.GetTotalMemory(true);

Console.WriteLine("Başlangıç Bellek: {0} bytes", memoryBefore);
Console.WriteLine("Bitiş Bellek: {0} bytes", memoryAfter);
Console.WriteLine("Kullanılan Bellek: {0} bytes", memoryAfter - memoryBefore);

stopwatch.Stop();
double milliseconds = stopwatch.ElapsedMilliseconds;


Console.WriteLine($"Runtime : {milliseconds} ms");


bool IsPalindrome(int x)
{
    if (x < 0) return false;

    string reversed = string.Empty;
    
    for (int i = x.ToString().Length - 1; i >= 0; i--)
    {
        reversed += x.ToString()[i];
    }
    return reversed == x.ToString();
}