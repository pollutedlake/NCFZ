using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    private static BattleManager instance = null;
    public static BattleManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    public GameObject AttackBoard;
    public GameObject AttackBar;
    public GameObject Player;
    public Text Text;

    /// <summary>
    /// 전투 페이즈
    /// choiceButton : Player이 fight, act, item, mercy 중 버튼을 고르는 페이즈
    /// choiceMonster : Player가 선택한 행동의 대상이 되는 몬스터를 고르는 페이즈
    /// playerAttack : Player가 공격하는 페이즈
    /// enemyAattack : 적이 공격하는 페이즈
    /// </summary>
    public enum Phase
    {
        choiceButton, choiceMonster, playerAttack, enemyAttack
    }

    public Phase battlePhase;        // 전투 페이즈

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// 전투 시작 시 변수 초기화 작업
    /// 전투 페이즈는 choiceButton, 
    /// </summary>
    void Start()
    {
        battlePhase = Phase.choiceButton;    
    }

    // Update is called once per frame
    void Update()
    {
        if(battlePhase == Phase.playerAttack)
        {
            AttackBar.SetActive(true);
            AttackBoard.SetActive(true);
            Player.SetActive(false);
            Text.gameObject.SetActive(false);
        }
    }

    public void ChangechoiceButton()
    {
        battlePhase = Phase.choiceButton;
    }


    public void ChangechoiceMonster()
    {
        battlePhase = Phase.choiceMonster;
    }

    public void ChangeplayerAttack()
    {
        battlePhase = Phase.playerAttack;
    }

    public void ChangeenemyAttack()
    {
        battlePhase = Phase.enemyAttack;
    }
}
