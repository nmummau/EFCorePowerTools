using Microsoft.EntityFrameworkCore;
using PostgresTester.Models;

namespace PostgresTester;

internal static class Program
{
    private static async Task Main()
    {
        var options = new DbContextOptionsBuilder<NorthwindContext>()
            .UseNpgsql("Host=localhost;Database=Northwind;Username=postgres;Password=postgres")
            .Options;

        using var db = new NorthwindContext(options);
        var sum = new OutputParameter<int?>();

        var res1 = await db.Functions.sum_xyAsync(1, 2, sum);

        if (sum.Value != 3)
        {
            Console.WriteLine($"AssertEqual failed. Expected: \"3\". Actual: {sum.Value}.");
        }

        var result = await db.Functions.CustOrderHistAsync("ALFKI");
        if (result.Count != 11)
        {
            Console.WriteLine($"AssertEqual failed. Expected: \"11\". Actual: {result.Count}.");
        }
    }
}