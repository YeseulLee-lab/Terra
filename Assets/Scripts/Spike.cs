using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
        if(player != null)
        {
            if(!player.isHurting)
            {
                Vector3 knockbackDir = (player.transform.position - transform.position).normalized;
                player.DamageKnockBack(knockbackDir, 1.5f, damageAmount);
            }            
        }
    }
}
