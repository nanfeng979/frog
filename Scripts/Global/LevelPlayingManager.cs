using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayingManager : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameManager.Instance.SetGameState(EGameState.Playing);
    }

    void Update()
    {
        
    }
}
