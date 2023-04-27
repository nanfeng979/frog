using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int EnemyCount = 5;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if(EnemyCount <= 0) {
            Debug.Log("GameEnd");
            GameManager.Instance.SetGameState(EGameState.GameOver);
            Invoke("ToLevelSelect", 2);
        }
    }

    public void KillEnemy() {
        EnemyCount--;
        Debug.Log("剩下" + EnemyCount + "个敌人");
    }

    private void ToLevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }
}
