using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class More : MonoBehaviour
{
    [SerializeField] private GameObject ObjectListByMore; // 更多
    [SerializeField] private GameObject MoreButton; // 更多

    private bool isShow = false;

    public void OnClick() {
        // 切换状态。
        isShow = !isShow;

        // 当前对象根据Z轴翻转90度。
        TranslateZ(90);
        ShowOrHideMore();
    }

    private void TranslateZ(float angle) {
        if(isShow) {
            MoreButton.transform.Rotate(0, 0, -angle);
        } else {
            MoreButton.transform.Rotate(0, 0, angle);
        }
    }

    private void ShowOrHideMore() {
        ObjectListByMore.SetActive(isShow);
    }
}
