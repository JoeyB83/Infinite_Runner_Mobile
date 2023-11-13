using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float backForce;
    public float returnSpeed;

    public Vector3 orPos;

    public Animator anim;

    public bool grounded;

    public Rigidbody2D rb_Player;    

    // Start is called before the first frame update
    void Start()
    {
        rb_Player = GetComponent<Rigidbody2D>();
        orPos = transform.position;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       if (!grounded) return;

        Move();
        
    }


    void Move()
    {
        rb_Player.velocity = new Vector2(moveSpeed, rb_Player.velocity.y);

        if (Input.touchCount < 1) return;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            grounded = false;
            rb_Player.velocity = new Vector2(rb_Player.velocity.x, jumpForce);
            anim.Play("Jump");
            AudioManager.instance.PlaySFXPitched(0);
        }

        //if (Input.GetKeyDown(KeyCode.Space)) 
        //{
        //    grounded = false;
        //    rb_Player.velocity = new Vector2(rb_Player.velocity.x, jumpForce);
        //    anim.Play("Jump");
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            grounded = true;
            anim.Play("Walk");
        }       
    }

    

   
}
