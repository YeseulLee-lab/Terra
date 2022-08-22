using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private FallDetector fallDetector;
    private Animator animator;
    private bool isChecked = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        fallDetector = FindObjectOfType<FallDetector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isChecked)
        {
            if(AudioManager.instance != null)
                AudioManager.instance.PlaySound("stage_clear_01");
            if (collision.gameObject.name == "player")
            {
                fallDetector.CheckPoint = gameObject.transform;
                //animator.SetTrigger("Move");
            }
            isChecked = true;
        }        
    }
}
