using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItem : MonoBehaviour
{
    private Sprite sprite;
    public bool haveSprite = false;

    void Update()
    {
        // if(haveSprite) {
            GetComponent<Image>().sprite = sprite;
        // }
    }

    public void SetSprite(Sprite sprite) {
        this.sprite = sprite;
    }

    public void SetHaveSprite(bool haveSprite) {
        this.haveSprite = haveSprite;
    }
}
