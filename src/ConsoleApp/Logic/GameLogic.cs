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

    public IGame Start()
    {
        return _curGame;
    }

    public IGame Play(int curNum)
    {
        _curGame.Count--;

        if (_curGame.Count > 0)
        {
            if (curNum > _curGame.Num)
            {
                _curGame.State = GameState.More;
                return _curGame;
            }
            else if (curNum < _curGame.Num)
            {
                _curGame.State = GameState.Less;
                return _curGame;
            }
            else
            {
                _curGame.State = GameState.Win;
                return _curGame;
            }
        }
        else
        {
            if (curNum == _curGame.Num)
            {
                _curGame.State = GameState.Win;
                return _curGame;
            }
            else
            {
                _curGame.State = GameState.Fail;
                return _curGame;
            }
        }
    }

    public
}
