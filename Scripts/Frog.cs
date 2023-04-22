using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EFrogState {
    None,
    Jump
}

public class Frog : MonoBehaviour
{
    private EFrogState frogState; // 青蛙状态量

    [SerializeField] private GameObject tongue; // 舌头对象

    [SerializeField] private GameObject line; // 辅助线对象

    private Vector2 jumpDir; // 跳跃方向


    void Start()
    {
        
    }

    void Update()
    {
        switch(frogState) {
            case EFrogState.None:
                break;
            case EFrogState.Jump:
                OnJump();
                break;
        }

        if(frogState == EFrogState.None && tongue.GetComponent<Tongue>().GetTongueState() == ETongueState.None && !line.GetComponent<Line>().isMouseDown) {
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                frogState = EFrogState.Jump;
                jumpDir = Vector2.up;
            } else if(Input.GetKeyDown(KeyCode.DownArrow)) {
                frogState = EFrogState.Jump;
                jumpDir = Vector2.down;
            } else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                frogState = EFrogState.Jump;
                jumpDir = Vector2.left;
            } else if(Input.GetKeyDown(KeyCode.RightArrow)) {
                frogState = EFrogState.Jump;
                jumpDir = Vector2.right;
            }
        }
    }

    private void OnJump() {
        if(jumpDir == Vector2.up) {
            Debug.Log("向上跳");
        } else if(jumpDir == Vector2.down) {
            Debug.Log("向下跳");
        } else if(jumpDir == Vector2.left) {
            Debug.Log("向左跳");
        } else if(jumpDir == Vector2.right) {
            Debug.Log("向右跳");
        }

        frogState = EFrogState.None;
    }
}
