using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    /// <summary>
    /// 전투 페이즈
    /// choiceButton : Player이 fight, act, item, mercy 중 버튼을 고르는 페이즈
    /// </summary>
    public enum Phase
    {
        choiceButton
    }

    public Phase battlePhase;        // 전투 페이즈

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
        
    }
}
