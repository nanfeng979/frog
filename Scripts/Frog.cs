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

    private Vector2 jumpDiration; // 跳跃方向
    private float jumpTime; // 跳跃完成所需要的时间
    private float jumpDistance; // 跳跃完成所需要的距离


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
            case EFrogState.Jump:
                OnJump();
                break;
        }

        if(frogState == EFrogState.None &&
            tongue.GetComponent<Tongue>().GetTongueState() == ETongueState.None &&
            !line.GetComponent<Line>().isMouseDown) {
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                frogState = EFrogState.Jump;
                jumpDiration = Vector2.up;
            } else if(Input.GetKeyDown(KeyCode.DownArrow)) {
                frogState = EFrogState.Jump;
                jumpDiration = Vector2.down;
            } else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                frogState = EFrogState.Jump;
                jumpDiration = Vector2.left;
            } else if(Input.GetKeyDown(KeyCode.RightArrow)) {
                frogState = EFrogState.Jump;
                jumpDiration = Vector2.right;
            }
        }
    }

    private void OnJump() {
        StartCoroutine(Jump(jumpDiration));
        frogState = EFrogState.None;
    }

    IEnumerator Jump(Vector2 dir) {
        float timer = 0.0f;
        while(timer < jumpTime) {
            timer += Time.deltaTime;
            transform.Translate(dir * jumpDistance * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
