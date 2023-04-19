using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private GameObject frog; // 青蛙对象
    [SerializeField] private GameObject tongue; // 舌头对象

    Vector3 lineScaleOld; // 舌头当前的大小
    private float extendTheLineSpeed = 2.0f; // 舌头伸出的速度
    private readonly float lineScaleMaxY = 2.0f; // 舌头最大大小

    Vector3 lineAngleOld; // 舌头当前的角度
    Vector3 lineAngleNew; // 舌头新的角度
    private float lineRotationMaxRange = 30.0f;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) {
            ChangeLineScale();
            ChangeLineAngle();
            tongue.GetComponent<Tongue>().SetTongueNewAngle(lineAngleNew.z);
        }

        if(Input.GetMouseButtonUp(0)) {
            tongue.GetComponent<Tongue>().IsCheckTongueState(true);
        }
    }

    private void Init() {
        lineScaleOld = gameObject.transform.localScale;
        lineAngleOld = gameObject.transform.localRotation.eulerAngles;
    }

    public void Reset() {
        gameObject.transform.localScale = lineScaleOld;
        gameObject.transform.localRotation = Quaternion.Euler(lineAngleOld);
    }

    public float GetLineScale() {
        return gameObject.transform.localScale.y;
    }

    public void ResetLineScale() {
        transform.localScale = lineScaleOld;
    }

    private void ChangeLineScale() {
        float tempLineScaleY = transform.localScale.y;
        tempLineScaleY += Time.deltaTime * extendTheLineSpeed;
        tempLineScaleY = tempLineScaleY > lineScaleMaxY ? lineScaleMaxY : tempLineScaleY;
        transform.localScale = new Vector3(
            transform.localScale.x,
            tempLineScaleY,
            transform.localScale.z);
    }

    public void SetLineNewAngle(float angle) {
        float tempLineRotationZ = angle;
        tempLineRotationZ = Mathf.Clamp(tempLineRotationZ, -lineRotationMaxRange, lineRotationMaxRange);
        lineAngleNew = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, tempLineRotationZ);
    }

    private void ChangeLineAngle() {
        transform.localRotation = Quaternion.Euler(lineAngleNew);
    }

}
