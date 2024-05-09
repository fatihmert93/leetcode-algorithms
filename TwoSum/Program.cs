// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Hello, World!");

int[] nums = new int[] { 2, 7, 11, 15 };

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

GC.Collect();
GC.WaitForPendingFinalizers();
long memoryBefore = GC.GetTotalMemory(true);

var result = TwoSum(nums, 9);
Console.WriteLine($"Result is {string.Join(",",result)}, expecting is [0, 1]");

long memoryAfter = GC.GetTotalMemory(true);

Console.WriteLine("Başlangıç Bellek: {0} bytes", memoryBefore);
Console.WriteLine("Bitiş Bellek: {0} bytes", memoryAfter);
Console.WriteLine("Kullanılan Bellek: {0} bytes", memoryAfter - memoryBefore);

stopwatch.Stop();
double milliseconds = stopwatch.ElapsedMilliseconds;


Console.WriteLine($"Runtime : {milliseconds} ms");



int[] TwoSum(int[] nums, int target) {
    
    Dictionary<int, int> map = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];
        if (map.ContainsKey(complement)) {
            return new int[] { map[complement], i };
        }

        map[nums[i]] = i;
    }

    return null;
}