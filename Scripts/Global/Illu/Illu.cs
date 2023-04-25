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
}