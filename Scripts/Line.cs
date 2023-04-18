using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private GameObject tongue;

    private float lineScale;
    Vector3 lineScaleOld;
    private float extendTheLineSpeed = 2.0f;
    private readonly float lineScaleMaxY = 3.0f;

    void Start()
    {
        lineScaleOld = gameObject.transform.localScale;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) {
            ChangeLineScale();
        }

        if(Input.GetMouseButtonUp(0)) {
            tongue.GetComponent<TongueController>().IsCheckTongueState(true);
        }
    }

    public void Init() {
        lineScale = lineScaleOld.y;
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

    public void ResetLineScale() {
        transform.localScale = lineScaleOld;
    }

    public float GetLineScale() {
        return lineScale;
    }

}
