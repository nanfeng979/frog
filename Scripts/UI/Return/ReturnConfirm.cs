using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnConfirm : MonoBehaviour
{
    public void YesReturnToLevelSelect() {
        switch(GamePageManager.Instance.CurrentPage) {
            case EGamePage.LevelSelect:
                ReturnToGameStart();
                break;
            case EGamePage.Playing:
                ReturnToLevelSelect();
                break;
        }
        
    }

    public void NoReturn() {
        GameManager.Instance.SetGameState(GameManager.Instance.GameStatePrev);
        gameObject.SetActive(false);
    }

    private void ReturnToLevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }

    private void ReturnToGameStart() {
        SceneManager.LoadScene("GameStart");
    }
}
