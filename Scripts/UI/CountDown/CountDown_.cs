using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown_ : MonoBehaviour
{
    [SerializeField] private GameObject enableTipsGameOver; // 游戏结束提示框对象
    private Image image;
    private float PercentagePerSecond; // 每秒百分比变量


    void Start()
    {
        image = GetComponent<Image>();
        
        PercentagePerSecond = 2;
    }

    void Update()
    {
        // 修改Image的FillAmout，用于倒计时的时间流逝，每秒流逝百分之X。
        image.fillAmount -= (PercentagePerSecond / 100) * Time.deltaTime;

        // 当倒计时结束时，显示TipsGameOver界面。
        if(image.fillAmount == 0) {
            EnableTipsGameOver();
        }
    }

    private void EnableTipsGameOver() {
        enableTipsGameOver.SetActive(true);
    }
}
