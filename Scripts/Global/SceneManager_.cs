using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_ : MonoBehaviour
{
    [SerializeField] private EGamePage gamePage;
    [SerializeField] private EGameState gameState;

    void Awake() {
        StartCoroutine(SetCurrentPage());
        StartCoroutine(SetGameState());
    }

    IEnumerator SetCurrentPage() {
        while(!GamePageManager.Instance) {
            yield return null;
        }
        GamePageManager.Instance.SetCurrentPage(gamePage);
    }

    IEnumerator SetGameState() {
        while(!GameManager.Instance) {
            yield return null;
        }
        GameManager.Instance.SetGameState(gameState);
    }
}
