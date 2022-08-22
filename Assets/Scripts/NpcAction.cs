using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAction : MonoBehaviour
{
    public GameObject dialogueUIObject;
    //npc 위 위치
    public GameObject dialogueUIPoint;

    private Canvas canvas;
    private RectTransform dialogueUIRectTranform;

    private void Start()
    {
        dialogueUIRectTranform = dialogueUIObject.GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
    }

    public void ShowDialogueUIObject()
    {
        //npc가 있는 위치 가져와서 말풍선 띄움 https://answers.unity.com/questions/799616/unity-46-beta-19-how-to-convert-from-world-space-t.html
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector2 pos = dialogueUIPoint.transform.position;  // get the game object position
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(pos);  //convert game object position to VievportPoint
        Vector2 canvasPosition = new Vector2
                                        (((viewportPoint.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
                                         ((viewportPoint.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));

        dialogueUIRectTranform.anchoredPosition = canvasPosition;
        Instantiate(dialogueUIObject, canvas.transform);
    }
}
