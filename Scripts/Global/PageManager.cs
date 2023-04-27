using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    private bool flag = true;

    void Update() {
        if(GameManager.Instance && flag) {
            GameManager.Instance.SetGameState(EGameState.GameStart);
            flag = false;
        }
    }
}
