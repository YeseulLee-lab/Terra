using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    int dialogueIdx = 0;

    private void Update()
    {
        if(gameObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogueWithNPC();
            }
        }        
    }

    public void DialogueWithNPC()
    {
        string id = new List<string>(TableData.instance.GetMainDataDic().Keys)[dialogueIdx];
        string stringId = TableData.instance.GetMainDataList(id)[dialogueIdx].string_id;
        string dialogueString = TableData.instance.GetDialogue(stringId);
        dialogueText.text = dialogueString;
        dialogueIdx++;
    }
}
