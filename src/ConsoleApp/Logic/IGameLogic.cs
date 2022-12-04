using ConsoleApp.Models;

namespace ConsoleApp.Logic;

public interface IGameLogic
{
    IGame Play(int curNum);
    IGame Start();
}
