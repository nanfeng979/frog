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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Frog") {
            // 被捕食时，增加图鉴。
            AddIllu();
            // 增加背包此对象的数量。
            BagData bagData = new BagData(objectName, 1, GetComponent<SpriteRenderer>().sprite);
            BagDataManager.Instance.AddBagData(bagData);
            // 蚊子碰到青蛙本体时，摧毁自己。
            Destroy(gameObject);
            // 减少当前关卡的敌人数。
            LevelManager.Instance.KillEnemy();
        }
    }

    private void AddIllu() {
        // 激活图鉴。
        Illu.Instance.AddIlluObject(objectName);
    }

}

public interface IMosBasicClass {
    void Action();
}
