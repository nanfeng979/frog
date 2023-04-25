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

    public IlluObjectClass FindIlluObject(string name) {
        for(int i = 0; i < objects.Count; i++) {
            if(objects[i].GetName() == name) {
                return objects[i];
            }
        }
        return null;
    }

    public void AddIlluObject(string illuName) {
        IlluObjectClass illuObject = FindIlluObject(illuName);
        if(illuObject == null) {
            Debug.Log("图鉴没有该对象");
        } else {
            illuObject.SetIsActivation(true);
        }
    }
}