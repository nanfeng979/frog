using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluIcon : MonoBehaviour
{
    [SerializeField] private GameObject IlluFrameObject;

    public void OnClick() {
        IlluFrameObject.SetActive(IlluFrameObject.activeSelf ? false : true);
    }
}
