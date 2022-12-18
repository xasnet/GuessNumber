using ConsoleApp.Enums;
using ConsoleApp.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

public static class Menu
{
    public static void Show(IServiceProvider serviceProvider)
    {
        Console.WriteLine();
        Console.WriteLine("<<< Play the game! >>>");
        Console.WriteLine();

        while (true)
        {
            var serviceGame = serviceProvider.GetService<IGameLogic>()!;

            serviceGame.Start();
            serviceGame.Play();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Do you want to play the game again (Y/N) ?");

                var cmd = Console.ReadLine()!.Trim().ToUpper();

                if (cmd != "Y" && cmd != "N")
                {
                    Console.WriteLine("Enter correct command of : Y:(Yes), N:(No)");
                }
                else if (cmd == "Y")
                {
                    break;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
