using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectListByMore : MonoBehaviour
{
    private List<GameObject> childs = new List<GameObject>();
    private List<Vector3> childsOldPosition = new List<Vector3>();

    private float openMoveDistance = 0.0f;
    private float objectsWillMoveDistance = 300.0f;
    private float showListTime = 0.6f;
    private float showListTimer = 0.0f;

    void Awake() {
        GetChildsObjectAndOldPosition();
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
                childs[i].transform.position -= new Vector3(0.0f, step * objectsWillMoveDistance / showListTime, 0.0f);
            }
        }
    }

    private void GetChildsObjectAndOldPosition() {
        for(int i = 0; i < transform.childCount; i++) {
            childs.Add(transform.GetChild(i).gameObject);
            childsOldPosition.Add(transform.GetChild(i).position);
        }
    }

    private void ResetData() {
        openMoveDistance = 0.0f;
        showListTimer = 0.0f;
    }

    private void childsResetPosition() {
        for(int i = 0; i < transform.childCount; i++) {
            childs[i].transform.position = childsOldPosition[i];
        }
    }

    
}
