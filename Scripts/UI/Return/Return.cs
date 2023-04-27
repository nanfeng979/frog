using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    [SerializeField] private GameObject returnConfirm;

    public void EnableReturnConfirm() {
        if(CantContinue()) {
            return;
        }

        if(returnConfirm.gameObject.activeSelf == false) {
            returnConfirm.gameObject.SetActive(true);
            GameManager.Instance.SetGameState(EGameState.PopUp);
        }
    }

    private bool CantContinue() {
        if(GameManager.Instance.GameState == EGameState.PopUp) {
            return true;
        }
        return false;
    }

}
