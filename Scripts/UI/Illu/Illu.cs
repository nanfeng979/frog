using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Illu : MonoBehaviour
{
    static public Illu Instance;

    public List<IlluObjectClass> objects = new List<IlluObjectClass>();

    void Start()
    {
        Instance = this;
    }

    public List<IlluObjectClass> GetIlluObjects() {
        return objects;
    }

    // 根据图鉴名称查找图鉴对象。
    public IlluObjectClass FindIlluObject(string name) {
        for(int i = 0; i < objects.Count; i++) {
            if(objects[i].GetName() == name) {
                return objects[i];
            }
        }
        return null;
    }

    // 激活与添加图鉴。
    public void AddIlluObject(string illuName) {
        IlluObjectClass illuObject = FindIlluObject(illuName);
        // TODO: 当拿到的对象没有在图鉴中时，添加到图鉴中，并且赋予图鉴名字、精灵图并设置为激活状态。
        if(illuObject == null) {
            Debug.Log("图鉴没有该对象");
        } else {
            illuObject.SetIsActivation(true);
        }
    }
}