using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayingManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetGameState(EGameState.Playing);
        GamePageManager.Instance.SetCurrentPage(EGamePage.Playing);
    }
}
