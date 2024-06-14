using System;
using System.Collections.Generic;

public class Player
{
    public Player(int userId, string name)
    {
        UserId = userId;
        Name = name;
        Level = 0;
    }

    public int UserId { get; private set; }
    public string Name { get; set; }
    public int Level { get; set; }
}

public class GameLogicManager
{
    private static GameLogicManager _instance = null;
    private int _curSelectedPlayerId = 0;

    private static Dictionary<int, Player> _playerDic = new Dictionary<int, Player>();
    private Action<int, int> _levelUpCallback;
    private Action<int, string> _renameCallback;

    public static GameLogicManager Inst
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameLogicManager();
                TempInitPlayerList();
            }
            return _instance;
        }
    }

    public static void TempInitPlayerList()
    {
        _playerDic.Add(1, new Player(1, "죠스바"));
        _playerDic.Add(2, new Player(2, "쌍쌍바"));
        _playerDic.Add(3, new Player(3, "바밤바"));
    }

    public void RegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback += levelupCallback;
    }

    public void UnRegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback -= levelupCallback;
    }


    //=====
    public void RegisterReNameCallback(Action<int, string> renameCallback)
    {
        _renameCallback += renameCallback;
    }
    public void UnRegisterReNameCallback(Action<int, string> renameCallback)
    {
        _renameCallback -= renameCallback;
    }



    public void RequestLevelUp()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Level++;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }

    public void RequestLevelUpDouble()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Level ++;
            curPlayer.Level ++;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }

    public void RequestRename()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Name = "쿵야";
            _renameCallback.Invoke(reqUserId, curPlayer.Name);
        }
    }

    public void RefreshCharacterInfo(int requestId, Action<int, string, int> callback)
    {
        _curSelectedPlayerId = requestId;
        if (_playerDic.ContainsKey(requestId))
        {
            var curPlayer = _playerDic[requestId];
            callback.Invoke(curPlayer.UserId, curPlayer.Name, curPlayer.Level);
        }
    }
}
