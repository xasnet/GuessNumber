using ConsoleApp.Enums;

namespace ConsoleApp.Models;

public class NewGame : Game
{
    public NewGame(int minVal, int maxVal, int count, GameState state) : base(minVal, maxVal, count, state)
    {
    }
}
