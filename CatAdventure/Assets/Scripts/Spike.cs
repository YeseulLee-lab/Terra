using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Life life;
    private PlayerMove player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpikeHurtsPlayer();
        }
    }

    private void SpikeHurtsPlayer()
    {
        if(!player.isHurting)
        {
            life.LifeNum--;
            life.ActiveLife();
            player.isHurting = true;
        }        
    }
}
