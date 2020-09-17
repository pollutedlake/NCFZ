using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public BattleManager battleManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (battleManager.battlePhase)      // 전투페이즈마다 행동이 다르다.
        {
            // choiceButton일 때는 양옆으로만 이동하며 이동 시 옆 버튼으로 이동하며 해당 버튼이 활성화 된다.
            case BattleManager.Phase.choiceButton:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.position -= new Vector3(4.5f, 0, 0);      // 버튼 간의 간격 만큼 왼쪽으로 이동
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(4.5f, 0, 0);      // 버튼 간의 간격만큼 오른쪽으로 이동
                }
                else if (Input.GetKeyDown(KeyCode.Z))       // 버튼 선택
                {

                }
                break;
        }
    }
}
