// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

GC.Collect();
GC.WaitForPendingFinalizers();
long memoryBefore = GC.GetTotalMemory(true);

var strs = new[] { "flower", "flow", "flight" };

var result = LongestCommonPrefix(strs);
Console.WriteLine($"Result is {result == "fl"} {result}, expecting is [fl]");

long memoryAfter = GC.GetTotalMemory(true);

Console.WriteLine("Başlangıç Bellek: {0} bytes", memoryBefore);
Console.WriteLine("Bitiş Bellek: {0} bytes", memoryAfter);
Console.WriteLine("Kullanılan Bellek: {0} bytes", memoryAfter - memoryBefore);

stopwatch.Stop();
double milliseconds = stopwatch.ElapsedMilliseconds;


Console.WriteLine($"Runtime : {milliseconds} ms");

string LongestCommonPrefix(string[] prefixes) 
{
    if (prefixes.Length == 0) return "";
    string prefix = prefixes[0];
    for (int i = 1; i < prefixes.Length; i++)
    {
        while (prefixes[i].IndexOf(prefix, StringComparison.Ordinal) != 0)
        {
            prefix = prefix.Substring(0, prefix.Length - 1);
            if (prefix == "") return "";
        }
    }
    return prefix;        
}