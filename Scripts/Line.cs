using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private GameObject tongue;

    private float lineScale;
    Vector3 lineScaleOld;

    void Start()
    {
        lineScaleOld = gameObject.transform.localScale;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) {
            lineScale += Time.deltaTime;
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
        Vector3 lineScaleNew = lineScaleOld;
        lineScaleNew.y = lineScale;
        gameObject.transform.localScale = lineScaleNew;
    }

    public void ResetLineScale() {
        gameObject.transform.localScale = lineScaleOld;
    }

    public float GetLineScale() {
        return lineScale;
    }

}
