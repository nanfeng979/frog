using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluController : MonoBehaviour
{
    [SerializeField] private GameObject IlluFrame;

    public void OnClick() {
        if(CantContinue()) {
            return;
        }

        IlluFrame.SetActive(true);
        GameManager.Instance.SetGameState(EGameState.PopUp);
    }

    public void OnClickClose() {

        IlluFrame.SetActive(false);
        GameManager.Instance.SetGameStateUsePrev();
    }

    private bool CantContinue() {
        if(GameManager.Instance.GameState == EGameState.PopUp) {
            return true;
        }

        return false;
    }
}
