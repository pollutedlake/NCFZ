using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBar : MonoBehaviour
{
    public float speed;     // AttackBar가 이동하는 속도
    bool pressZ;        // Z가 눌렸는지 확인하는 변수
    Animator animator;
    public GameObject speechBubble;
    public Dialog dialog;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(BattleManager.Instance.battlePhase == BattleManager.Phase.playerAttack)
        {
            if (Input.GetKeyDown(KeyCode.Z))        // Z를 누르면 멈춤
            {
                pressZ = true;
                animator.SetTrigger("Attack");
                speechBubble.SetActive(true);
                dialog.gameObject.SetActive(true);
            }
            if (transform.position.x < 7.7f && !pressZ)     // 오른쪽 끝에 도달하거나 Z를 누를때까지 오른쪽으로 이동
            {
                transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
            }
            else
            {

            }
        }
        // 초기화
        else
        {
            pressZ = false;
            transform.position = new Vector3(-7.7f, -1.55f, 0);
            gameObject.SetActive(false);
        }
    }
}
