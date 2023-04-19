using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfLine : MonoBehaviour
{
    public GameObject line; // 辅助线对象

    void Update()
    {
        // 改变辅助线角度
        ChangeLineAngle();
    }

    private void ChangeLineAngle() {
        // 获取鼠标在世界坐标上的位置
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // 得到角度点和鼠标位置的距离与角度点的正上方的夹角
        float angle = Vector2.SignedAngle(transform.up, mousePosition - (Vector2)transform.position);
        // 设置辅助线新的角度
        line.GetComponent<Line>().SetLineNewAngle(angle);
    }
}
