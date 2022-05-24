using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask = default;
    [SerializeField] private float gravityScale;
    public float fallGravityMultiflier;

    public float maxSpeed;
    public float jumpPower;
    public bool isHurting = false;

    Rigidbody2D rigid;    

    private CapsuleCollider2D capsuleCollider2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Color materialTintColor;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    public float jumpTime;
    private float jumpTimeCounter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            rigid.gravityScale = gravityScale;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            rigid.gravityScale = gravityScale * fallGravityMultiflier;
        }

        //Jump

        if(coyoteTimeCounter > 0f && Input.GetButtonDown("Jump"))
        {
            rigid.velocity = Vector2.up * jumpPower;
            //jumpTimeCounter = jumpTime;
        }

        if(Input.GetButtonUp("Jump") && rigid.velocity.y > 0f)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }


        //누른시간에 따라 점프 높이 달라짐
        /*if(Input.GetKey(KeyCode.Space))
        {
            if(jumpTimeCounter >0)
            {
                rigid.velocity = Vector2.up * jumpPower;
                jumpTimeCounter -= Time.deltaTime;
            }
        }*/

        //Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if(Input.GetButtonDown("Horizontal"))
        {
            Vector2 offset = capsuleCollider2D.offset;
            spriteRenderer.flipX = !(Input.GetAxisRaw("Horizontal") == -1);
            if(Input.GetAxisRaw("Horizontal") == -1)
                offset.x = -0.15f;
            else
                offset.x = 0.15f;
            capsuleCollider2D.offset = offset;

        }

    }

    void FixedUpdate()
    {
        //Move By Key Control
        float moveInput = Input.GetAxisRaw("Horizontal");

        rigid.velocity = new Vector2(moveInput * maxSpeed, rigid.velocity.y);

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

    public void DamageFlash()
    {
        materialTintColor = new Color(1, 1, 1, 0.5f);
        spriteRenderer.material.SetColor("_Color", materialTintColor);
    }

    public void DamageKnockBack(Vector3 knockbackDir, float knockbackDistance, int damageAmount)
    {
        transform.position += knockbackDir * knockbackDistance;
        DamageFlash();
        HeartsHealthVisual.heartHealthSystemStatic.Damage(damageAmount);
        StartCoroutine(CoEnableDamage());
    }

    public IEnumerator CoEnableDamage()
    {
        isHurting = true;
        if(isHurting)
        {
            yield return new WaitForSeconds(2f);
            materialTintColor = new Color(1, 1, 1, 1f);
            spriteRenderer.material.SetColor("_Color", materialTintColor);
            isHurting = false;
        }
    }    
}
