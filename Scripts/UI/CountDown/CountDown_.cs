using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown_ : MonoBehaviour
{
    private Image image;
    private float PercentagePerSecond;


    void Start()
    {
        image = GetComponent<Image>();
        
        PercentagePerSecond = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // 修改Image的FillAmout，用于倒计时的时间流逝
        image.fillAmount -= (1 / PercentagePerSecond) * Time.deltaTime;
    }
}
