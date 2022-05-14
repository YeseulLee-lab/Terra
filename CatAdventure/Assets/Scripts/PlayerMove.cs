using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    [SerializeField] private LayerMask platformLayerMask = default;
    public Spike spike;
    public bool isHurting = false;

    Rigidbody2D rigid;    

    private CapsuleCollider2D capsuleCollider2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Jump
        if(IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        //Stop Speed
        if(Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if(Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = !(Input.GetAxisRaw("Horizontal") == -1);

        if(isHurting)
        {            
            StartCoroutine("CoBlinkingPlayer");
        }
    }

    void FixedUpdate()
    {
        //Move By Key Control
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed) //Right Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed*(-1)) //Left Max Speed
        {
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
        }
             
    }

    private bool IsGrounded()
    {
        float extraHeightText = .3f;

        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider2D.bounds.center, Vector2.down, capsuleCollider2D.bounds.extents.y + extraHeightText, platformLayerMask);
        Color rayColor;
        if(raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(capsuleCollider2D.bounds.center, Vector2.down * (capsuleCollider2D.bounds.extents.y + extraHeightText), rayColor);     

        return raycastHit.collider != null;
    }

    IEnumerable CoBlinkingPlayer()
    {
        spriteRenderer.material.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(2f);
        spriteRenderer.material.color = new Color(1, 1, 1, 1);
        isHurting = false;
    }
}
