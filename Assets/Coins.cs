using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    public int valueCoin;

    ScoreManager scoreManager;

    Rigidbody2D rb_Coins;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        rb_Coins = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            scoreManager.scoreCount += valueCoin;
            gameObject.SetActive(false);
            AudioManager.instance.PlaySFXPitched(1);
        }
    }
}
