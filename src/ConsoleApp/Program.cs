using ConsoleApp;
using ConsoleApp.Enums;
using ConsoleApp.Logic;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine();
Console.WriteLine("<<< Guess The Number! >>>");
Console.WriteLine();

IServiceProvider serviceProvider = AppService.Register();

while (true)
{
    var serviceGame = serviceProvider.GetService<IGameLogic>();

    var curGame = serviceGame!.Start();

    bool isPlay = true;

    while (isPlay)
    {
        Console.WriteLine();
        Console.WriteLine("--> New game starting... >>>");

        Console.WriteLine(@$"Enter the number between {curGame.MinVal} and {curGame.MaxVal}.
The number of attempts is {curGame.Count}:");

        var curNum = Console.ReadLine()!;

        if (curNum.Any(Char.IsLetter))
        {
            Console.WriteLine($"Enter correct number!");
            continue;
        }

        curGame = serviceGame!.Play(Convert.ToInt32(curNum));

        switch (curGame.Flag)
        {
            case GameFlag.Win:
                Console.WriteLine($"YOU ARE WIN!!! THE NUMBER IS {curNum}");
                isPlay = false;
                break;
            case GameFlag.Fail:
                Console.WriteLine($"You are lose. The number is {curGame.Num}");
                isPlay = false;
                break;
            case GameFlag.Less:
                Console.WriteLine($"The numer {curNum} is less then guess number");
                isPlay = true;
                break;
            case GameFlag.More:
                Console.WriteLine($"The number {curNum} is more then guess number");
                isPlay = true;
                break;
            default:
                isPlay = true;
                break;
        }
    }

    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("Do you want to play the game again (Y/N) ?");

        var cmd = Console.ReadLine()!.Trim().ToUpper();

        if ((cmd != "Y") && (cmd != "N"))
        {
            Console.WriteLine("Enter correct command of : Y:(Yes), N:(No)");
            continue;
        }
        else if (cmd == "Y")
        {
            break;
        }
        else
        {
            return;
            break;
        }
    }

}