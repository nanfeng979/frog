using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    [SerializeField] private GameObject BagFrame;

    public void OnClick() {
        BagFrame.SetActive(true);
    }

    public void CloseBag() {
        BagFrame.SetActive(false);
    }
}
