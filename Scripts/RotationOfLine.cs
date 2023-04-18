using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfLine : MonoBehaviour
{
    public GameObject line;

    void Update()
    {
        ChangeLineRotation();
    }

    private void ChangeLineRotation() {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        float angle = Vector2.SignedAngle(transform.up, mousePosition - (Vector2)transform.position);
        line.GetComponent<Line>().SetLineRotation(angle);
    }
}
