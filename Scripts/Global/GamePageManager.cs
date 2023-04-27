using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGamePage {
    GameStart,
    LevelSelect,
    Playing

}

public class GamePageManager : MonoBehaviour
{
    public static GamePageManager Instance { get; private set; }
    public EGamePage CurrentPage { get; private set; }

    void Start()
    {
        Instance = this;
    }

    public void SetCurrentPage(EGamePage page) {
        CurrentPage = page;
    }
}
