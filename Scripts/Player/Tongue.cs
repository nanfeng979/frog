using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETongueState {
    // 静止状态，即无状态。
    None,
    // 伸出舌头状态。
    Extend,
    // 缩回舌头状态。
    Return,
    
}

public class Tongue : MonoBehaviour
{
    private ETongueState tongueState; // 舌头状态变量。

    [SerializeField] private GameObject line; // 辅助线对象。
    [SerializeField] private Transform tongueHead; // 舌头头部位置

    Vector3 tongueScaleOld; // 舌头当前的大小。
    private float extendTheTongueSpeed; // 舌头伸出的速度。

    private Vector3 tongueAngleOld; // 舌头当前的角度。
    private Vector3 tongueAngleNew; // 舌头新的角度。

    private bool startCheckTongueState; // 是否要检查舌头状态。

    void Start()
    {
        Init();
    }

    void Update()
    {
        switch(tongueState) {
            case ETongueState.Extend: // 舌头伸出时。
                OnExtend();
                break;
            case ETongueState.Return: // 舌头缩回时。
                OnReturn();
                break;
            case ETongueState.None: // 没有状态时。
                OnNone();
                break;
        }

        // 判断 是否要检查舌头状态。
        if(startCheckTongueState) {
            CheckTongueState();
        }
    }

    // 检查舌头状态。
    private void CheckTongueState() {
        // 舌头长度小于最小值时，恢复舌头长度，改成None，不再检查状态。
        if(transform.localScale.y < tongueScaleOld.y) {
            SetTongueState(ETongueState.None);
            // 重置辅助线的长度和角度。
            line.GetComponent<Line>().Reset();
            // 停止检查舌头状态。
            IsCheckTongueState(false);
            return;
        }

        // 当 舌头长度比辅助线短。
        if(transform.localScale.y < line.transform.localScale.y) {
            // 设置舌头状态为Extend伸出。
            SetTongueState(ETongueState.Extend);
            // 改变舌头角度。
            ChangeTongueAngle();
        } 
        // 当 舌头长度比辅助线长
        else if(transform.localScale.y > line.transform.localScale.y) {
            // 设置舌头状态为Return缩回。
            SetTongueState(ETongueState.Return);
            // 重置辅助线的长度为初始状态。
            line.GetComponent<Line>().ResetLineScale();
        }
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        // 当 触碰的对象是蚊子("Mos_"开头的对象)时。
        if(other.name.Substring(0, 4) == "Mos_") {
            // 蚊子位置始终跟随舌头头部位置。
            other.transform.position = tongueHead.position;
            // 重置辅助线的长度。
            line.GetComponent<Line>().ResetLineScale();
        }
    }

    private void OnExtend() {
        // 增大舌头的长度，主要修改舌头的Y轴。
        transform.localScale = new Vector3(
            transform.localScale.x,
            transform.localScale.y + (Time.deltaTime * extendTheTongueSpeed),
            transform.localScale.z);
    }

    private void OnReturn() {
        // 减小舌头的长度，主要修改舌头的Y轴。
        transform.localScale = new Vector3(
            transform.localScale.x,
            transform.localScale.y - (Time.deltaTime * extendTheTongueSpeed),
            transform.localScale.z);
    }

    private void OnNone() {
        Reset();
    }

    private void Init() {
        tongueState = ETongueState.None;
        extendTheTongueSpeed = 3.0f;
        startCheckTongueState = false;

        tongueScaleOld = gameObject.transform.localScale;
        tongueAngleOld = gameObject.transform.localRotation.eulerAngles;
    }

    // 重置舌头的长度和角度为最初状态。
    private void Reset() {
        transform.localScale = tongueScaleOld;
        transform.localRotation = Quaternion.Euler(tongueAngleOld);
    }

    public void IsCheckTongueState(bool yesOrNo) {
        startCheckTongueState = yesOrNo;
    }

    public ETongueState GetTongueState() {
        return tongueState;
    }

    public void SetTongueState(ETongueState state) {
        tongueState = state;
    }

    public void SetTongueNewAngle(float angle) {
        // 修改舌头角度，主要修改舌头的Z轴。
        tongueAngleNew = new Vector3(
            transform.localEulerAngles.x,
            transform.localEulerAngles.y,
            angle);
    }

    private void ChangeTongueAngle() {
        transform.localRotation = Quaternion.Euler(tongueAngleNew);
    }

}
