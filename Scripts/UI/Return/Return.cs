using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    [SerializeField] private GameObject returnConfirm;

    public void EnableReturnConfirm() {
        if(returnConfirm.gameObject.activeSelf == false) {
            returnConfirm.gameObject.SetActive(true);
            GameManager.Instance.SetGameStatePrev(GameManager.Instance.GameState);
            GameManager.Instance.SetGameState(EGameState.UI);
        }
    }

}
