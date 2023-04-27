using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosBasicClass : MonoBehaviour
{
    private string objectName = "Mos"; // 对象名。
    protected float speed = 1; // 初始化速度。

    // 设置速度。
    public void SetSpeed(float _speed) {
        speed = _speed;
    }

    public string GetName() {
        return objectName;
    }

    public void SetName(string _name) {
        objectName = _name;
    }

}

public interface IMosBasicClass {
    void Action();
}
