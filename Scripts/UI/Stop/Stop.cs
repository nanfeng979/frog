using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public GameObject On;
    public GameObject Off;

    public void OnCliCkByOn() {
        On.gameObject.SetActive(false);
        Off.gameObject.SetActive(true);
        GameManager.Instance.SetGameState(EGameState.Stop);
    }

    public void OnCliCkByOff() {
        On.gameObject.SetActive(true);
        Off.gameObject.SetActive(false);
        GameManager.Instance.SetGameState(EGameState.Playing);
    }
}
