using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TipsGameOver : MonoBehaviour
{
    public void ReturnToLevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }
}
