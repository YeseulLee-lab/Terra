using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatform : MonoBehaviour
{
    [SerializeField] private float fadingSpeed;
    [SerializeField] private float showPlatformTime;

    private BoxCollider2D[] boxCol2D;
    private SpriteRenderer spriteRend;
    private bool isFading;
    private Color platformAlpha;


    private void Start()
    {
        platformAlpha = gameObject.GetComponent<SpriteRenderer>().material.color;
        platformAlpha.a = 0;      

        boxCol2D = gameObject.GetComponents<BoxCollider2D>();
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(isFading)
        {            
            gameObject.GetComponent<SpriteRenderer>().material.color = 
            Color.Lerp(gameObject.GetComponent<SpriteRenderer>().material.color, platformAlpha, fadingSpeed * Time.deltaTime);
        }
          
        if(gameObject.GetComponent<SpriteRenderer>().material.color.a < 0.1f)
        {
            for(int i = 0; i < boxCol2D.Length; i++)
                boxCol2D[i].enabled = false;
            spriteRend.enabled = false;
            isFading = false;       
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
            isFading = true;
    }

    public void ShowFadingPlatform()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        for (int i = 0; i < boxCol2D.Length; i++)
            boxCol2D[i].enabled = true;
        spriteRend.enabled = true;
    }

}
