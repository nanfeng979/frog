using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnConfirm : MonoBehaviour
{
    public void YesReturnToLevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void NoReturn() {
        GameManager.Instance.SetGameState(GameManager.Instance.GameStatePrev);
        gameObject.SetActive(false);
    }
}
