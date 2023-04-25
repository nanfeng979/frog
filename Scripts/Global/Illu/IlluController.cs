using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluController : MonoBehaviour
{
    [SerializeField] private GameObject IlluFrame;

    public void OnClick() {
        IlluFrame.SetActive(true);
    }
}
