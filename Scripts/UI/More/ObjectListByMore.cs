using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectListByMore : MonoBehaviour
{
    private List<GameObject> childs = new List<GameObject>();
    private List<Vector2> childsOldPosition = new List<Vector2>();

    private float openMoveDistance = 0.0f;
    private float objectsWillMoveDistance = 300.0f;
    private float showListTime = 0.6f;
    private float showListTimer = 0.0f;

    void Awake() {
        GetChildsObjectAndOldPosition();
        Mask mask = GetComponent<Mask>();
        // 禁用mask
        // mask.enabled = false;
    }

    void OnEnable() {
        ResetData();
    }

    void OnDisable() {
        childsResetPosition();
    }
    
    void Update()
    {
        float step = Time.deltaTime;
        showListTimer += step;
        if(showListTimer < showListTime && openMoveDistance < objectsWillMoveDistance) {
            openMoveDistance += step;
            for(int i = 0; i < transform.childCount; i++) {
                childs[i].GetComponent<RectTransform>().anchoredPosition -= new Vector2(0.0f, step * objectsWillMoveDistance / showListTime);
            }
        }
    }

    private void GetChildsObjectAndOldPosition() {
        for(int i = 0; i < transform.childCount; i++) {
            childs.Add(transform.GetChild(i).gameObject);
            childsOldPosition.Add(transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition);
        }
    }

    private void ResetData() {
        openMoveDistance = 0.0f;
        showListTimer = 0.0f;
    }

    private void childsResetPosition() {
        for(int i = 0; i < transform.childCount; i++) {
            childs[i].transform.GetComponent<RectTransform>().anchoredPosition = childsOldPosition[i];
        }
    }

    
}
