using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonList : MonoBehaviour
{
    public Monster[] monList;        // 몬스터 이름 리스트
    public int yellowIdx;       // 노란색으로 활성화될 monList의 string index
    public Text text;

    /// <summary>
    /// yellowIdx 초기화
    /// </summary>
    void Start()
    {
        yellowIdx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(BattleManager.battlePhase == BattleManager.Phase.choiceMonster)
        {
            text.text = "";
            for (int i = 0; i < monList.Length; i++){
                if (i == yellowIdx)
                {
                    text.text += "<color=#ffff00>" + monList[i].name + "</color>" + "\n";        // 활성화중인 원소만 노란색으로
                }
                else
                {
                    text.text += monList[i].name+ "\n";
                }
            }
        }
    }

    /// <summary>
    /// yellowIdx를 바꾸는 함수
    /// </summary>
    /// <param name="distance"> 얼마만큼 바꿀 것인가에 대한 매개변수 </param>
    public void ChangeMon(int distance)
    {
        yellowIdx = (yellowIdx + distance + monList.Length) % monList.Length;
    }
}
