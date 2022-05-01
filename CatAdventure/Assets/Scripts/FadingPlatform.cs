using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatform : MonoBehaviour
{
    [SerializeField] private float fadingSpeed;
    [SerializeField] private float showPlatformTime;

    private BoxCollider2D boxCol2D;
    private SpriteRenderer spriteRend;
    private bool isFading;
    private Color platformAlpha;


    private void Start()
    {
        platformAlpha = gameObject.GetComponent<SpriteRenderer>().material.color;
        platformAlpha.a = 0;      

        boxCol2D = gameObject.GetComponent<BoxCollider2D>();
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
            boxCol2D.enabled = false;            
            spriteRend.enabled = false;
            isFading = false;       
            //StartCoroutine(nameof(CoFadeInPlatform));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player")
            isFading = true;
    }

    public IEnumerator CoFadeInPlatform()
    {
        yield return new WaitForSeconds(showPlatformTime);
        gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        boxCol2D.enabled = true;
        spriteRend.enabled = true;
    }

}
