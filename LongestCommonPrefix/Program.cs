// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

int[] nums = new int[] { 2, 7, 11, 15 };

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

GC.Collect();
GC.WaitForPendingFinalizers();
long memoryBefore = GC.GetTotalMemory(true);

var strs = new string[] { "flower", "flow", "flight" };

var result = LongestCommonPrefix(strs);
Console.WriteLine($"Result is {result == "fl"} {result}, expecting is [fl]");

long memoryAfter = GC.GetTotalMemory(true);

Console.WriteLine("Başlangıç Bellek: {0} bytes", memoryBefore);
Console.WriteLine("Bitiş Bellek: {0} bytes", memoryAfter);
Console.WriteLine("Kullanılan Bellek: {0} bytes", memoryAfter - memoryBefore);

stopwatch.Stop();
double milliseconds = stopwatch.ElapsedMilliseconds;


Console.WriteLine($"Runtime : {milliseconds} ms");

string LongestCommonPrefix(string[] strs) 
{
    if (strs.Length == 0) return "";
    string prefix = strs[0];
    for (int i = 1; i < strs.Length; i++)
    {
        while (strs[i].IndexOf(prefix, StringComparison.Ordinal) != 0)
        {
            prefix = prefix.Substring(0, prefix.Length - 1);
            if (prefix == "") return "";
        }
    }
    return prefix;        
}