using ConsoleApp.Configuration;
using ConsoleApp.Enums;

namespace ConsoleApp.Models;

public class Game : IGame
{
    public int Count { get; set; }

    public int MinVal { get; }

    public int MaxVal { get; }

    public int Num { get; }

    public GameFlag Flag { get; set; }

    public Game(int minValm, int maxVal, int count, GameFlag flag)
    {
        MinVal = minValm;
        MaxVal = maxVal;
        Count = count;
        Num = Generate(minValm, maxVal);
        Flag = flag;
    }

    private static int Generate(int minVal, int maxVal)
    {
        return Random.Shared.Next(minVal, maxVal);
    }
}
