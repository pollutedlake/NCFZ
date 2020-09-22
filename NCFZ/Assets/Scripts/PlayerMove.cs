using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public ButtonManager buttonManager;
    public MonList monList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (BattleManager.battlePhase)      // 전투페이즈마다 행동이 다르다.
        {
            // choiceButton일 때는 양옆으로만 이동하며 이동 시 옆 버튼으로 이동하며 해당 버튼이 활성화 된다.
            case BattleManager.Phase.choiceButton:
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if ((int)buttonManager.onButton != 0)
                    {
                        transform.position -= new Vector3(4.5f, 0, 0);      // 버튼 간의 간격 만큼 왼쪽으로 이동
                    }
                    else
                    {
                        transform.position = new Vector3(6, -4.42f, 0);     // 제일 왼쪽의 버튼일 경우 제일 오른쪽의 버튼으로 이동
                    }
                    buttonManager.ChangeButton(-1);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if ((int)buttonManager.onButton != buttonManager.buttons.Length - 1)
                    {
                        transform.position += new Vector3(4.5f, 0, 0);      // 버튼 간의 간격만큼 오른쪽으로 이동
                    }
                    else
                    {
                        transform.position = new Vector3(-7.5f, -4.42f, 0);     // 제일 오른쪽의 버튼일 경우 제일 왼쪽의 버튼으로 이동
                    }
                    buttonManager.ChangeButton(1);
                }
                else if (Input.GetKeyDown(KeyCode.Z))       // 버튼 선택
                {
                    switch (buttonManager.onButton)
                    {
                        case ButtonManager.button.fight:
                            BattleManager.battlePhase = BattleManager.Phase.choiceMonster;
                            transform.position = new Vector3(-6.74f, -0.63f, 0);
                            break;
                    }
                }
                break;
            case BattleManager.Phase.choiceMonster:
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (monList.yellowIdx != 0)
                        {
                            transform.position += new Vector3(0, 0.9f, 0);      // text 줄 간격 만큼 위로 이동
                        }
                        else
                        {
                            transform.position = new Vector3(-6.74f, -2.43f, 0);        // 맨 윗줄일 경우 맨 아랫줄로 이동
                        }
                        monList.ChangeMon(-1);
                    }
                    else if(Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        if (monList.yellowIdx != monList.monList.Length - 1)
                        {
                            transform.position -= new Vector3(0, 0.9f, 0);      // text 줄 간격 만큼 아래로 이동
                        }
                        else
                        {
                            transform.position = new Vector3(-6.74f, -0.63f, 0);        // 맨 아랫줄일 경우 맨 윗줄로 이동
                        }
                        monList.ChangeMon(1);
                    }
                    else if (Input.GetKeyDown(KeyCode.X))
                    {
                        if(buttonManager.onButton == ButtonManager.button.fight)
                        {
                            transform.position = new Vector3(-7.5f, -4.42f, 0);
                            BattleManager.battlePhase = BattleManager.Phase.choiceButton;
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.Z))
                    {
                        switch (buttonManager.onButton)
                        {
                            case ButtonManager.button.fight:
                                BattleManager.battlePhase = BattleManager.Phase.playerAttack;
                                break;
                        }
                    }
                }
                break;
        }
    }
}
