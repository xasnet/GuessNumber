using ConsoleApp.Enums;
using ConsoleApp.Models;

namespace ConsoleApp.Logic;

public class GameLogic : IGameLogic
{
    private readonly IGame _curGame;

    public GameLogic(IGame curGame)
    {
        _curGame = curGame;
    }

    public void Start()
    {
        Console.WriteLine();
        Console.WriteLine("<<< Guess The Number! >>>");
        Console.WriteLine("--> New game starting... >>>");
        Console.WriteLine();

        _curGame.State = GameState.Play;
    }

    public void Play()
    {
        if (_curGame.State != GameState.Play)
        {
            Console.WriteLine(@"Game ""Guess The Number"" has incorrect state");
            return;
        };

        while (true)
        {

            Console.WriteLine(@$"Enter the number between {_curGame.MinVal} and {_curGame.MaxVal}.
The number of attempts is {_curGame.Count}:        {_curGame.Num}");

            var curNumStr = Console.ReadLine()!;

            if (curNumStr.Any(char.IsLetter))
            {
                Console.WriteLine($"Enter correct number!");
                continue;
            }

            var curNum = Convert.ToInt32(curNumStr);

            _curGame.Count--;

            if (curNum == _curGame.Num)
            {
                _curGame.State = GameState.Win;
                Console.WriteLine($"YOU ARE WIN!!! THE NUMBER IS {curNum}");
                break;

            }

            if (_curGame.Count > 0)
            {
                if (curNum > _curGame.Num)
                {
                    _curGame.State = GameState.More;
                    Console.WriteLine($"The number {curNum} is more than guess number");
                }
                else
                {
                    _curGame.State = GameState.Less;
                    Console.WriteLine($"The number {curNum} is less than guess number");
                }
            }
            else
            {
                _curGame.State = GameState.Fail;
                Console.WriteLine($"You are lose. The number is {_curGame.Num}");
                break;
            }
        }
    }
}
