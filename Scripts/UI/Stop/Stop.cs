using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MyUI
{
    public GameObject On;
    public GameObject Off;

    public void OnCliCkByOn() {
        if(CantUseWithPopUp()) {
            return;
        }
        On.gameObject.SetActive(false);
        Off.gameObject.SetActive(true);
        GameManager.Instance.SetGameState(EGameState.Stop);
    }

    public void OnCliCkByOff() {
        if(CantUseWithPopUp()) {
            return;
        }
        On.gameObject.SetActive(true);
        Off.gameObject.SetActive(false);
        GameManager.Instance.SetGameState(EGameState.Playing);
    }
}
