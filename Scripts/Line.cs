using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private GameObject frog;
    [SerializeField] private GameObject tongue;

    Vector3 lineScaleOld;
    private float extendTheLineSpeed = 2.0f;
    private readonly float lineScaleMaxY = 2.0f;


    Vector3 lineRotationOld;
    Vector3 lineRotationNew;
    private float lineRotationMaxRange = 30.0f;

    void Start()
    {
        lineScaleOld = gameObject.transform.localScale;
        lineRotationOld = gameObject.transform.localRotation.eulerAngles;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) {
            ChangeLineScale();
            ChangeLineRotation();
            tongue.GetComponent<TongueController>().SetTongueRotation(lineRotationNew.z);
        }

        if(Input.GetMouseButtonUp(0)) {
            tongue.GetComponent<TongueController>().IsCheckTongueState(true);
        }
    }

    public void Init() {
        gameObject.transform.localScale = lineScaleOld;
        gameObject.transform.localRotation = Quaternion.Euler(lineRotationOld);
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

    public void SetLineRotation(float angle) {
        float tempLineRotationZ = angle;
        tempLineRotationZ = Mathf.Clamp(tempLineRotationZ, -lineRotationMaxRange, lineRotationMaxRange);
        lineRotationNew = new Vector3(lineRotationNew.x, lineRotationNew.y, tempLineRotationZ);
    }

    private void ChangeLineRotation() {
        transform.localRotation = Quaternion.Euler(lineRotationNew);
    }

    public void ResetLineScale() {
        transform.localScale = lineScaleOld;
    }

    public float GetLineScale() {
        return gameObject.transform.localScale.y;
    }

}
