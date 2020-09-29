using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    private int attackNum = 0;
    private string[] attackedDialog = { "부부싸움은 칼로\n물베기라고\n한다지?" };
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(Typing(text, attackedDialog, 0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Typing(Text typingText, string[] message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            for (int j = 0; j < message[i].Length; j++)
            {
                typingText.text += message[i][j];
                yield return new WaitForSeconds(speed);
            }
        }

    }
}
