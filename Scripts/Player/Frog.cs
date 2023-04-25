using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EFrogState {
    None,
    StartJump,
    Jumping,
    EndJump
}

public class Frog : MonoBehaviour
{
    private EFrogState frogState; // 青蛙状态量。

    [SerializeField] private GameObject tongue; // 舌头对象。

    [SerializeField] private GameObject line; // 辅助线对象。

    private Vector2 jumpDiration; // 跳跃方向。
    private float jumpTime; // 跳跃完成所需要的时间。
    private float jumpDistance; // 跳跃完成所需要的距离。
    private bool isJumping = false; // 判断青蛙是否在跳跃中。


    void Start()
    {
        jumpTime = 1.0f;
        jumpDistance = 1.0f;
    }

    void Update()
    {
        switch(frogState) {
            case EFrogState.None:
                break;
            case EFrogState.StartJump:
                OnStartJump();
                break;
            case EFrogState.Jumping:
                OnJumping();
                break;
            case EFrogState.EndJump:
                OnEndJump();
                break;
        }

        CheckFrogStateToJump();
        
    }

    private void OnStartJump() {
        frogState = EFrogState.Jumping;
    }

    private void OnJumping() {
        StartCoroutine(Jump(jumpDiration));
        frogState = EFrogState.EndJump;
    }

    private void OnEndJump() {
        if(!isJumping) {
            frogState = EFrogState.None;
        }
    }

    IEnumerator Jump(Vector2 dir) {
        isJumping = true;
        float timer = 0.0f;
        while(timer < jumpTime) {
            timer += Time.deltaTime;
            transform.Translate(dir * jumpDistance * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        isJumping = false;
    }

    private void CheckFrogStateToJump() {
        if(frogState == EFrogState.None &&
            tongue.GetComponent<Tongue>().GetTongueState() == ETongueState.None &&
            !line.GetComponent<Line>().isMouseDown) {
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
                frogState = EFrogState.StartJump;
                jumpDiration = Vector2.up;
            } else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
                frogState = EFrogState.StartJump;
                jumpDiration = Vector2.down;
            } else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
                frogState = EFrogState.StartJump;
                jumpDiration = Vector2.left;
            } else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
                frogState = EFrogState.StartJump;
                jumpDiration = Vector2.right;
            }
        }
    }
}
