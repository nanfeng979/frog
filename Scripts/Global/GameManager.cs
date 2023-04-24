using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
    None,
    LevelSelect,
    Loading,
    Playing,
    GameOver,
    Stop,
    UI
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public EGameState GameState { get; private set; }

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        Instance = this;
        GameState = EGameState.None;
    }

    public void SetGameState(EGameState state) {
        GameState = state;
        Debug.Log(state);
    }
}
