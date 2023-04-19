using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETongueState {
    // 静止
    None,
    // 伸出舌头
    Extend,
    // 缩回舌头
    Return,
    
}

public class Tongue : MonoBehaviour
{
    private ETongueState tongueState = ETongueState.None;

    [SerializeField] private GameObject line;

    Vector3 tongueScaleOld;
    private float extendTheTongueSpeed = 3.0f;

    private Vector3 tongueAngleOld;
    private Vector3 tongueAngleNew;

    private bool startCheckTongueState = false;

    void Start()
    {
        Init();
    }

    void Update()
    {
        switch(tongueState)  {
            case ETongueState.Extend:
                OnExtend();
                break;
            case ETongueState.Return:
                OnReturn();
                break;
            case ETongueState.None:
                OnNone();
                break;
        }

        if(startCheckTongueState) {
            CheckTongueState();
        }
    }

    private void CheckTongueState() {
        if(transform.localScale.y < line.transform.localScale.y) {
            SetTongueState(ETongueState.Extend);
            ChangeTongueAngle();
        } else if(transform.localScale.y > line.transform.localScale.y) {
            SetTongueState(ETongueState.Return);
            line.GetComponent<Line>().ResetLineScale();
        }

        // 舌头长度小于最小值时，恢复舌头长度，改成None，不再检查状态
        if(transform.localScale.y < tongueScaleOld.y) {
            SetTongueState(ETongueState.None);
            line.GetComponent<Line>().Reset();
            IsCheckTongueState(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name.Substring(0, 3) == "Mos") {
            Destroy(other.gameObject);
            line.GetComponent<Line>().ResetLineScale();
        }
    }

    private void OnExtend() {
        transform.localScale = new Vector3(
            transform.localScale.x,
            transform.localScale.y + (Time.deltaTime * extendTheTongueSpeed),
            transform.localScale.z);
    }

    private void OnReturn() {
        transform.localScale = new Vector3(
            transform.localScale.x,
            transform.localScale.y - (Time.deltaTime * extendTheTongueSpeed),
            transform.localScale.z);
    }

    private void OnNone() {
        transform.localScale = tongueScaleOld;
        Reset();
    }

    private void Init() {
        tongueScaleOld = gameObject.transform.localScale;
        tongueAngleOld = gameObject.transform.localRotation.eulerAngles;
    }

    private void Reset() {
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
        if(tongueState == ETongueState.None) {
            tongueAngleNew = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
        }
    }

    private void ChangeTongueAngle() {
        transform.localRotation = Quaternion.Euler(tongueAngleNew);
    }

}
