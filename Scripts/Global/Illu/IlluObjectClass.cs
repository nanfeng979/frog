using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IlluObjectClass", menuName = "IlluObjectClass")]
public class IlluObjectClass : ScriptableObject
{
    public string objectName; // 图鉴对象名。
    public Sprite objectSprite; // 图鉴对象的图片。
    public bool isActivation = false; // 图鉴对象是否激活。

    public string GetName() {
        return objectName;
    }

    public Sprite GetSprite() {
        return objectSprite;
    }

    public bool GetIsActivation() {
        return isActivation;
    }
}
