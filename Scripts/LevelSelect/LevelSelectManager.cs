using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    void Start() {
        GameManager.Instance.SetGameState(EGameState.LevelSelect);
        GamePageManager.Instance.SetCurrentPage(EGamePage.LevelSelect);
    }
}
