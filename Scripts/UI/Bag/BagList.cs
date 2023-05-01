using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagList : MonoBehaviour
{

    void Awake()
    {
        
    }

    void Update()
    {
        for(int i = 0; i < BagDataManager.Instance.GetBagDatas().Count; i++) {
            // transform.GetChild(i)
            transform.GetChild(i).GetComponent<BagItem>().SetSprite(BagDataManager.Instance.GetBagDatas()[i].sprite);
        }
    }
}
