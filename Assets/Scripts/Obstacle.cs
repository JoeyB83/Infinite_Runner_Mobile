using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //public float moveSpeed;

    public bool hit;

    PlayerController playerController;

    Rigidbody2D rb_Obstacle;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        rb_Obstacle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            hit = true;             
            playerController.grounded = false;            
            playerController.rb_Player.velocity = (Vector2.up + Vector2.left).normalized * playerController.backForce;
            transform.position = Vector2.MoveTowards(transform.position, playerController.orPos, playerController.returnSpeed * Time.deltaTime);
            playerController.anim.Play("Hit");
            AudioManager.instance.PlaySFXPitched(2);
        }
    }
}
