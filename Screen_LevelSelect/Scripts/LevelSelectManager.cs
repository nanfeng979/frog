using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    void Awake() {
        GameManager.Instance.SetGameState(EGameState.LevelSelect);
    }
}
