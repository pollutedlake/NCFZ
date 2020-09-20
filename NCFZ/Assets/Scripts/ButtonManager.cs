using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Sprite[] activeSprites;      // 버튼들의 활성화 이미지
    public Sprite[] inactiveSprites;      // 버튼들의 비활성화 이미지
    public GameObject[] buttons;
    /// <summary>
    /// 버튼의 종류(fight, act, item, mercy)
    /// </summary>
    public enum button
    {
        fight, act, item, mercy
    }
    public button onButton;     // 활성화하고 있는 버튼의 종류

    /// <summary>
    /// onButton 초기화
    /// </summary>
    void Start()
    {
        onButton = button.fight;        // 시작은 fight 버튼 선택 중
    }

    /// <summary>
    /// 활성화 중인 버튼과 비활성화 중인 버튼의 sprite 변경
    /// </summary>
    void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == (int)onButton)
            {
                buttons[i].GetComponent<SpriteRenderer>().sprite = activeSprites[i];        // 버튼 활성화
                continue;
            }
            buttons[i].GetComponent<SpriteRenderer>().sprite = inactiveSprites[i];        // 버튼 비활성화
        }
    }

    /// <summary>
    /// 활성화 할 버튼 바꾸는 함수
    /// </summary>
    /// <param name="distance"> 얼마만큼 바꿀 것인지에 대한 변수 </param>
    public void ChangeButton(int distance)
    {
        onButton = (button)((int)onButton + distance);
    }
}