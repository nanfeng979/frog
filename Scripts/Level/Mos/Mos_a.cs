using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mos_a : MosBasicClass, IMosBasicClass
{
    private Vector2 oldPosition; // 旧的位置。
    private Vector2 offsetPostion; // 新旧位置的偏移量。

    private float anglePerSecond; // 每秒转动的角度。

    void Start()
    {
        Init();
    }

    void Update()
    {
        Action();
    }

    private void Init() {
        // 初始化位置。
        SetName("Mos");
        transform.position = InitPosition(); // 重定义新的位置。
        anglePerSecond = 90.0f; // 设置每秒转动的角度。
    }

    private Vector2 InitPosition() {
        oldPosition = transform.position; // 旧的位置为初始位置。
        offsetPostion = new Vector2(0, 0.3f); // 设置位置的便宜量。
        Vector2 newPosition = new Vector2(oldPosition.x + offsetPostion.x, oldPosition.y + offsetPostion.y); // 调整新的位置。
        return newPosition;
    }

    public void Action() {
        // 围绕oldPosition旋转。
        transform.RotateAround(oldPosition, Vector3.forward, anglePerSecond * speed * Time.deltaTime);
    }
}
