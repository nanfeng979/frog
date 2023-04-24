using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosBasicClass : MonoBehaviour
{
    protected float speed = 1; // 初始化速度

    // 设置速度
    public void SetSpeed(float _speed) {
        speed = _speed;
    }

}

public interface IMosBasicClass {
    void Action();
}
