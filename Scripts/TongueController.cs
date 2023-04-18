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

public class TongueController : MonoBehaviour
{
    private ETongueState tongueState = ETongueState.None;

    [SerializeField] private GameObject line;

    Vector3 tongueScaleOld;
    private float extendTheTongueSpeed = 3.0f;

    private Vector3 tongueRotationOld;
    private Vector3 tongueRotationNew;

    private bool startCheckTongueState = false;

    void Start()
    {
        tongueScaleOld = gameObject.transform.localScale;
        tongueRotationOld = gameObject.transform.localRotation.eulerAngles;
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
            ChangeTongueRotation();
        } else if(transform.localScale.y > line.transform.localScale.y) {
            SetTongueState(ETongueState.Return);
            line.GetComponent<Line>().ResetLineScale();
        }

        // 舌头长度小于最小值时，恢复舌头长度，改成None，不再检查状态
        if(transform.localScale.y < tongueScaleOld.y) {
            line.GetComponent<Line>().Init();
            SetTongueState(ETongueState.None);
            IsCheckTongueState(false);
        }
    }

    public void IsCheckTongueState(bool yesOrNo) {
        startCheckTongueState = yesOrNo;
    }

    public void SetTongueState(ETongueState state) {
        tongueState = state;
    }

    public ETongueState GetTongueState() {
        return tongueState;
    }

    public void SetTongueRotation(float angle) {
        tongueRotationNew = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
    }

    private void ChangeTongueRotation() {
        transform.localRotation = Quaternion.Euler(tongueRotationNew);
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
        Init();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name.Substring(0, 3) == "Mos") {
            Destroy(other.gameObject);
            line.GetComponent<Line>().ResetLineScale();
        }
    }

    private void Init() {
        transform.localRotation = Quaternion.Euler(tongueRotationOld);
    }

}
