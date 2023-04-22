using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private GameObject frog; // 青蛙对象。
    [SerializeField] private GameObject tongue; // 舌头对象。

    Vector3 lineScaleOld; // 辅助线当前的大小。
    private float extendTheLineSpeed = 2.0f; // 辅助线伸出的速度。
    private readonly float lineScaleMaxY = 2.0f; // 辅助线Y轴最大长度。

    Vector3 lineAngleOld; // 辅助线当前的角度。
    Vector3 lineAngleNew; // 辅助线新的角度。
    private float lineRotationMaxRange = 30.0f; // 辅助线能够向左右每边旋转的最大角度。

    public bool isMouseDown = false;

    void Start()
    {
        Init();
    }

    void Update()
    {
        // 鼠标按住时。
        if(Input.GetMouseButton(0)) {
            isMouseDown = true;

            if(tongue.GetComponent<Tongue>().GetTongueState() == ETongueState.None) {
                // 改变辅助线的长度。
                ChangeLineScale();
                // 改变辅助线的角度。
                ChangeLineAngle();
                // 设置舌头新的角度。
                tongue.GetComponent<Tongue>().SetTongueNewAngle(lineAngleNew.z);
            }
        }

        // 鼠标抬起时。
        if(Input.GetMouseButtonUp(0)) {
            isMouseDown = false;
            
            // 开始检查舌头状态。
            tongue.GetComponent<Tongue>().IsCheckTongueState(true);
        }
    }

    private void Init() {
        lineScaleOld = transform.localScale;
        lineAngleOld = transform.localRotation.eulerAngles;
    }

    // 重置辅助线的长度和角度为最初状态。
    public void Reset() {
        transform.localScale = lineScaleOld;
        transform.localRotation = Quaternion.Euler(lineAngleOld);
    }

    public float GetLineScale() {
        return transform.localScale.y;
    }

    public void ResetLineScale() {
        transform.localScale = lineScaleOld;
    }

    private void ChangeLineScale() {
        // 根据速度(extendTheLineSpeed)改变辅助线的长度。
        float tempLineScaleY = transform.localScale.y;
        tempLineScaleY += Time.deltaTime * extendTheLineSpeed;
        // 限定辅助线的长度为lineScaleMaxY。
        tempLineScaleY = tempLineScaleY > lineScaleMaxY ? lineScaleMaxY : tempLineScaleY;
        // 改变辅助线的大小，主要修改辅助线的Y轴。
        transform.localScale = new Vector3(
            transform.localScale.x,
            tempLineScaleY,
            transform.localScale.z);
    }
    public void SetLineNewAngle(float angle) {
        float tempLineRotationZ = angle;
        // 限定辅助线的角度在-lineRotationMaxRange到lineRotationMaxRange之间。
        tempLineRotationZ = Mathf.Clamp(tempLineRotationZ, -lineRotationMaxRange, lineRotationMaxRange);
        // 修改辅助线的角度，主要修改辅助线的Z轴。
        lineAngleNew = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, tempLineRotationZ);
    }

    private void ChangeLineAngle() {
        transform.localRotation = Quaternion.Euler(lineAngleNew);
    }

}
