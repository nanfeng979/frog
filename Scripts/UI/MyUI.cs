using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUI : MonoBehaviour
{
    public bool CantUseWithPopUp() {
        if(GameManager.Instance.GameState == EGameState.PopUp) {
            return true;
        }
        return false;
    }
}
