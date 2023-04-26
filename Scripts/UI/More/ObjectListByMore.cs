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

    private Mask mask;
    private Image image;

    void Start() {
        GetChildsObjectAndOldPosition();
        image = GetComponent<Image>();
        mask = GetComponent<Mask>();
    }

    void OnEnable() {
        ResetData();
    }

    void OnDisable() {
        childsResetPosition();
        EnabledMaskAttr();
    }
    
    void Update()
    {
        float dt = Time.deltaTime;
        showListTimer += dt;
        if(showListTimer < showListTime && openMoveDistance < objectsWillMoveDistance) {
            openMoveDistance += dt;
            for(int i = 0; i < transform.childCount; i++) {
                childs[i].GetComponent<RectTransform>().anchoredPosition -= new Vector2(0.0f, dt * objectsWillMoveDistance / showListTime);
            }
        } else {
            DisableMaskAttr();
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

    private void EnabledMaskAttr() {
        mask.enabled = true;
        image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    private void DisableMaskAttr() {
        mask.enabled = false;
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    
}
