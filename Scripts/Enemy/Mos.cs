using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Frog") {
            // 被捕食时，增加图鉴。
            AddIllu();
            // 蚊子碰到青蛙本体时，摧毁自己。
            Destroy(gameObject);
        }
    }

    private void AddIllu() {
        // 从基类拿到名字后，添加到图鉴中。TODO: 设置为在每个子类获取名字比较合理。
        MosBasicClass mos = GetComponent<MosBasicClass>();
        // 激活图鉴。
        Illu.Instance.AddIlluObject(mos.GetName());
    }
}
