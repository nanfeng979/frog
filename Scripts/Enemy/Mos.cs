using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Frog") {
            // 蚊子碰到青蛙本体时，摧毁自己
            Destroy(gameObject);
        }
    }
}
