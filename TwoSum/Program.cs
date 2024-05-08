// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Console.WriteLine("Hello, World!");

int[] nums = new int[] { 2, 7, 11, 15, 3, 6, 8, 9, 5, 123, 232, 23, 4 };

Stopwatch stopwatch = Stopwatch.StartNew();
var result = TwoSum(nums, 9);
long milliseconds = stopwatch.ElapsedMilliseconds;

Console.WriteLine($"Result is {string.Join(",",result)}, expecting is [0, 1]");

Console.WriteLine($"Runtime : {milliseconds} ms");



int[] TwoSum(int[] nums, int target) {
    
    List<int> results = new List<int>();

    results = results.Where(v => v <= target).ToList();

    for(int i = 0;i < nums.Count(); i++)
    {
        for(int j = 0; j < nums.Count(); j++)
        {
            if(i != j && nums[i] + nums[j] == target) results.Add(i);
        }
    }

    return results.ToArray();
}