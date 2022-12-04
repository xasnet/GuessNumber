using ConsoleApp.Enums;

namespace ConsoleApp.Models;

public interface IGame
{
    int Count { get; set; }
    GameFlag Flag { get; set; }
    int MaxVal { get; }
    int MinVal { get; }
    int Num { get; }
}
