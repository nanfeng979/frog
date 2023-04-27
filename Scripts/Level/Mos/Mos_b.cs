using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mos_b : MosBasicClass, IMosBasicClass
{
    private Vector2 oldPosition; // 旧的位置。
    private float movePosition = 0;
    private float moveDistanceMax; // 最大移动距离。

    void Start()
    {
        moveDistanceMax = 1; // 定义最大移动距离。
        oldPosition = transform.position; // 旧的位置为初始位置。
        
        SetSpeed(0.5f); // 设置速度。
    }

    void Update()
    {
        Action();
    }

    public void Action() {
        // 更新位置。
        float nextStep = speed * Time.deltaTime;
        transform.position += new Vector3(0, nextStep, 0);

        // 限定只能在一段距离内来回移动。
        RestrictMovement(nextStep);
    }

    // 限定只能在一段距离内来回移动。
    private void RestrictMovement(float _nextStep) {
        movePosition += _nextStep; 
        if(movePosition > moveDistanceMax) {
            movePosition = moveDistanceMax;
            speed *= -1;
        } else if(movePosition < 0) {
            movePosition = 0;
            speed *= -1;
        }
    }
}
