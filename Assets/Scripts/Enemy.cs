using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;   

    Rigidbody2D rb_Enemy;
    // Start is called before the first frame update
    void Start()
    {        
        rb_Enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb_Enemy.velocity = Vector2.left * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("End");
            
        }
    }
}
