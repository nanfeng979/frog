using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public GameObject shetou;
    private float shetouScale;
    Vector3 shetouScaleOld;

    private bool test = false;

    void Start()
    {

    }

    void Update()
    {

        
        // if(Input.GetMouseButtonUp(0)) {
        //     // shetou.transform.localScale = line.transform.localScale;
        //     // StartCoroutine(SetShetouSCale());
        //     test = true;

        // }

        // if(test) {
        //     StartCoroutine(SetShetouSCale());
        // }

    }

    // private void ChangeLineScale() {
    //     lineScale += Time.deltaTime;
    //     Vector3 lineScaleNew = lineScaleOld;
    //     lineScaleNew.y = lineScale;
    //     line.transform.localScale = lineScaleNew;
    // }

    // private void InitLineAndShetouScale() {
    //     lineScale = lineScaleOld.y;
    //     shetouScale = shetouScaleOld.y;
    // }

    // IEnumerator SetShetouSCale() {
    //     if(shetou.transform.localScale.y < line.transform.localScale.y) {
    //         shetouScale += Time.deltaTime * 3;
    //         shetou.transform.localScale = new Vector3(shetou.transform.localScale.x, shetouScale, shetou.transform.localScale.z);
    //         yield return new WaitForFixedUpdate();
    //     }
    // }


}
