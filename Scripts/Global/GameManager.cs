using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
    None,
    GameStart,
    LevelSelect,
    Loading,
    Playing,
    GameOver,
    Stop,
    UI,
    PopUp
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public EGameState GameState { get; private set; }
    public EGameState GameStatePrev { get; private set; }

    void Awake() {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update() {
        switch(GameState) {
            case EGameState.Playing:
                OnPlaying();
                break;
            case EGameState.LevelSelect:
                break;
            case EGameState.Loading:
                break;
            case EGameState.GameOver:
                OnGameOver();
                break;
            case EGameState.Stop:
                OnStop();
                break;
            case EGameState.UI:
                OnUI();
                break;
            case EGameState.PopUp:
                OnPopUp();
                break;
        }
    }

    private void OnPlaying() {
        Time.timeScale = 1;
    }

    private void OnGameOver() {
        Time.timeScale = 0;
        Debug.Log("GameOver");
    }

    private void OnStop() {
        Time.timeScale = 0;
    }

    private void OnUI() {
        Time.timeScale = 0;
    }

    private void OnPopUp() {
        Time.timeScale = 0;
    }

    public void SetGameState(EGameState state) {
        GameStatePrev = GameState;
        GameState = state;
        Debug.Log("Current GameState: " + state);
    }

    public void SetGameStateUsePrev() {
        SetGameState(GameStatePrev);
    }

}
