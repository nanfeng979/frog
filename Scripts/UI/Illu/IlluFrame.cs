using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IlluFrame : MonoBehaviour
{
    [SerializeField] private GameObject Illu_smallFrame_Pre; // 图鉴中每个对象的预设体。

    void OnEnable() {
        // TODO: 将图鉴个数确定好，只遍历是否激活，不增加图鉴对象。
        // 每次启用时移除上一次加载的图鉴，即当前对象的所有的子对象。
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        // 拿到图鉴列表。
        List<IlluObjectClass> IlluList = Illu.Instance.GetIlluObjects();
        for(int i = 0; i < IlluList.Count; i++) {
            // 在图鉴框下生成图鉴对象。
            GameObject Illu_smallFrame = Instantiate(Illu_smallFrame_Pre, transform.position, Quaternion.identity, transform);
            Image Ill_Image = Illu_smallFrame.transform.GetChild(0).GetComponent<Image>();
            // 更改图鉴对应的图片。
            Ill_Image.sprite = IlluList[i].GetSprite();
            if(!IlluList[i].GetIsActivation()) {
                // 当图鉴没有激活时，降低透明度。
                Ill_Image.color = new Color(1, 1, 1, 0.2f);
            }
        }
    }
}
