using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,      // ゲーム起動状態
    Prepare,    // スタート前準備状態
    Playing,    // ゲームスタート状態
    End         // ゲーム終了状態
}

public class GameManagerBase : SingletonMonoBehavior<GameManagerBase>
{
    private GameState _currentGameState = GameState.End;
    public GameState CurrentGameState { get { return _currentGameState; } }

    public virtual void Start()
    {
        SetCurrentState(GameState.Start);
    }

    public void SetCurrentState(GameState state)
    {
        if(state == _currentGameState)
        {
            return;
        }

        _currentGameState = state;
        OnGameStateChanged(_currentGameState);
    }

    private void OnGameStateChanged(GameState state)
    {
        switch(state)
        {
            case GameState.Start:
                DoStartAction();
                break;
            case GameState.Prepare:
                DoPrepareAction();
                break;
            case GameState.Playing:
                DoPlayingAction();
                break;
            case GameState.End:
                DoEndAction();
                break;
            default:
                break;
        }
    }

    public virtual void DoStartAction()
    {

    }

    public virtual void DoPrepareAction()
    {

    }

    public virtual void DoPlayingAction()
    {

    }

    public virtual void DoEndAction()
    {

    }
}
